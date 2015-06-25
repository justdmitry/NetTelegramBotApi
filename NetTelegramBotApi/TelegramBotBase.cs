using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetTelegramBotApi
{
    public abstract class TelegramBotBase
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Util.JsonLowerCaseUnderscoreContractResolver()
        };

        private string accessToken;

        public TelegramBotBase(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            this.accessToken = accessToken;
        }

        protected T MakeRequest<T>(string methodName)
        {
            var webRequest = WebRequest.CreateHttp("https://api.telegram.org/bot" + accessToken + "/" + methodName);
            using (var webResponse = webRequest.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    using (var responseReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var responseText = responseReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<BotResponse<T>>(responseText, JsonSettings);

                        if (result.Ok)
                        {
                            return result.Result;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }

        protected async Task<T> MakeRequestAsync<T>(string methodName)
        {
            var webRequest = WebRequest.CreateHttp("https://api.telegram.org/bot" + accessToken + "/" + methodName);
            using (var webResponse = webRequest.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    using (var responseReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var responseText = await responseReader.ReadToEndAsync();
                        var result = JsonConvert.DeserializeObject<BotResponse<T>>(responseText, JsonSettings);

                        if (result.Ok)
                        {
                            return result.Result;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }
    }
}
