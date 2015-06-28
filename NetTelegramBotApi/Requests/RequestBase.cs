using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace NetTelegramBotApi.Requests
{
    public abstract class RequestBase<T>
    {
        public RequestBase(string methodName)
        {
            this.MethodName = methodName;
        }

        public string MethodName { get; protected set; }
        
        public abstract HttpContent CreateHttpContent();

        protected string JsonSerialize(object value)
        {
            return JsonConvert.SerializeObject(value, TelegramBot.JsonSettings);
        }
    }
}
