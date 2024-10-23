using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using NetTelegramBotApi.Util;

namespace NetTelegramBotApi
{
    public class TelegramBot : ITelegramBot
    {
        public static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonLowerCaseUnderscoreNamingPolicy(),
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        private readonly string accessToken;
        private readonly HttpClient httpClient;

        static TelegramBot()
        {
            JsonOptions.Converters.Add(new UnixDateTimeConverter());
        }

        public TelegramBot(string accessToken, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.accessToken = accessToken;
            this.httpClient = httpClient ?? new HttpClient();
        }

        /// <exception cref="BotRequestException">When non-Ok response returned from server.</exception>
        public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
        {
            var uri = new Uri("https://api.telegram.org/bot" + accessToken + "/" + request.MethodName);
            using var httpMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var postContent = request.CreateHttpContent();
            if (postContent != null)
            {
                httpMessage.Method = HttpMethod.Post;
                httpMessage.Content = postContent;
            }

            using var response = await httpClient.SendAsync(httpMessage).ConfigureAwait(false);
            if ((int)response.StatusCode >= 500)
            {
                // Let's throw exception. It's server fault
                response.EnsureSuccessStatusCode();
            }

            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = DeserializeMessage<BotResponse<T>>(responseText);
            if (!result.Ok || !response.IsSuccessStatusCode)
            {
                var exceptionMessage = $"Request failed (status code {(int)response.StatusCode}): {result.Description}";
                throw new BotRequestException(exceptionMessage)
                {
                    StatusCode = response.StatusCode,
                    ResponseBody = responseText,
                    Description = result.Description,
                    ErrorCode = result.ErrorCode,
                    Parameters = result.Parameters,
                };
            }

            var retVal = result.Result;
            if (retVal is IPostProcessingRequired forPostProcessing)
            {
                forPostProcessing.PostProcess(accessToken);
            }

            return retVal;
        }

        /// <summary>
        /// Use this method to deserialize <see cref="Update">Update</see> object, sent to <see cref="SetWebhook">your webhook</see> by Telegram server.
        /// </summary>
        /// <param name="json">Json-string with Update (body of HTTP POST to your webhook)</param>
        /// <returns>Deserialized <see cref="Update"/> message</returns>
        public Update DeserializeUpdate(string json)
        {
            return DeserializeMessage<Update>(json);
        }

        protected static T DeserializeMessage<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, JsonOptions);
        }
    }
}
