using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Util;
using Newtonsoft.Json;

namespace NetTelegramBotApi
{
    public class TelegramBot
    {
        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Util.JsonLowerCaseUnderscoreContractResolver()
        };

        private Uri baseAddress;

        static TelegramBot()
        {
            JsonSettings.Converters.Add(new ChatBaseConverter());
        }

        public TelegramBot(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            this.baseAddress = new Uri("https://api.telegram.org/bot" + accessToken + "/");
        }

        public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                using (var httpMessage = new HttpRequestMessage(HttpMethod.Get, request.MethodName))
                {
                    var postContent = BuildRequestBody(request);
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
                            var result = JsonConvert.DeserializeObject<BotResponse<T>>(responseText, JsonSettings);
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

        protected HttpContent BuildRequestBody<T>(RequestBase<T> request)
        {
            if (request == null)
            {
                return null;
            }
            var content = request.CreateHttpContent();
            if (content != null)
            {
                return content;
            }

            var requestParams = request.GetParameters();
            if (requestParams == null || requestParams.Count == 0)
            {
                return null;
            }
            return new FormUrlEncodedContent(requestParams);
        }
    }
}
