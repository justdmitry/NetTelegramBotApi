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
        private readonly string _proxyUrl;

        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Util.JsonLowerCaseUnderscoreContractResolver()
        };

        private Uri baseAddress;

        static TelegramBot()
        {
            JsonSettings.Converters.Add(new ChatBaseConverter());
            JsonSettings.Converters.Add(new UnixDateTimeConverter());
        }

        /// <summary>
        /// Initialisiert eine neue Instanz des <see cref="TelegramBot"/>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="proxyUrl">optional: URL like </param>
        public TelegramBot(string accessToken, string proxyUrl = null)
        {
            _proxyUrl = proxyUrl;
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }


            this.baseAddress = new Uri("https://api.telegram.org/bot" + accessToken + "/");
        }

        public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
        {
            using (var client = new HttpClient(getHttpDefaultHandler()))
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
                                return result.Result;
                            }
                        }
                        return default(T);
                    }
                }
            }
        }

        private HttpClientHandler getHttpDefaultHandler()
        {
            if (_proxyUrl != null)
            {
                return new HttpClientHandler
                {
                    Proxy = new WebProxy(_proxyUrl, true),
                    UseProxy = true
                };
            }

            return null;
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
