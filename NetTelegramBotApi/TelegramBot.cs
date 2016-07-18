using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Util;
using NetTelegramBotApi.Types;
using Newtonsoft.Json;

namespace NetTelegramBotApi
{
    public class TelegramBot
    {
        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Util.JsonLowerCaseUnderscoreContractResolver()
        };

        private string accessToken;

        private Uri baseAddress;

        static TelegramBot()
        {
            JsonSettings.Converters.Add(new UnixDateTimeConverter());
        }

        /// <summary>
        /// Proxy information for internet access
        /// </summary>
        public IWebProxy WebProxy { get; set; }

        public TelegramBot(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            this.accessToken = accessToken;
            this.baseAddress = new Uri("https://api.telegram.org/bot" + accessToken + "/");
        }

        public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
        {
            using (var client = new HttpClient(MakeHttpMessageHandler()))
            {
                client.BaseAddress = baseAddress;
                using (var httpMessage = new HttpRequestMessage(HttpMethod.Get, request.MethodName))
                {
                    var postContent = request.CreateHttpContent();
                    if (postContent != null)
                    {
                        httpMessage.Method = HttpMethod.Post;
                        httpMessage.Content = postContent;
                    }

                    using (var response = await client.SendAsync(httpMessage).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result = DeserializeMessage<BotResponse<T>>(responseText);
                            if (result.Ok)
                            {
                                var retVal = result.Result;
                                var forPostProcessing = retVal as IPostProcessingRequired;
                                if (forPostProcessing != null)
                                {
                                    forPostProcessing.PostProcess(accessToken);
                                }
                                return retVal;
                            }
                        }
                        return default(T);
                    }
                }
            }
        }

        protected virtual HttpClientHandler MakeHttpMessageHandler()
        {
            return new HttpClientHandler
            {
                Proxy = WebProxy,
                UseProxy = (WebProxy != null)
            };
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

        protected T DeserializeMessage<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }
    }
}
