using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        private string accessToken;

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

            this.accessToken = accessToken;
        }

        public T MakeRequest<T>(RequestBase<T> request)
        {
            var webRequest = WebRequest.CreateHttp("https://api.telegram.org/bot" + accessToken + "/" + request.MethodName);
            var postBytes = BuildRequestBody(request);
            if (postBytes != null && postBytes.Length != 0)
            {
                webRequest.Method = "POST";
                webRequest.ContentLength = postBytes.Length;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                using (var requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(postBytes, 0, postBytes.Length);
                }
            }
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

        public async Task<T> MakeRequestAsync<T>(RequestBase<T> request)
        {
            var webRequest = WebRequest.CreateHttp("https://api.telegram.org/bot" + accessToken + "/" + request.MethodName);
            var postBytes = BuildRequestBody(request);
            if (postBytes != null && postBytes.Length != 0)
            {
                webRequest.Method = "POST";
                webRequest.ContentLength = postBytes.Length;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                using (var requestStream = await webRequest.GetRequestStreamAsync())
                {
                    await requestStream.WriteAsync(postBytes, 0, postBytes.Length);
                }
            } 
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

        protected byte[] BuildRequestBody<T>(RequestBase<T> request)
        {
            if (request == null)
            {
                return null;
            }
            var requestParams = request.GetParameters();
            if (requestParams == null || requestParams.Count == 0)
            {
                return null;
            }
            var postData = new StringBuilder();
            foreach (var pair in requestParams)
            {
                if (pair.Value == null)
                {
                    continue;
                }
                postData.Append(HttpUtility.UrlEncode(pair.Key));
                postData.Append("=");
                postData.Append(HttpUtility.UrlEncode(pair.Value));
                postData.Append("&");
            }
            if (postData.Length == 0)
            {
                return null;
            }
            return Encoding.UTF8.GetBytes(postData.ToString());
        }
    }
}
