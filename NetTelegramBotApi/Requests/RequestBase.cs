using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetTelegramBotApi.Requests
{
    public abstract class RequestBase<T>
    {
        public RequestBase(string methodName)
        {
            this.MethodName = methodName;
        }

        public string MethodName { get; private set; }

        public abstract IDictionary<string, string> GetParameters();

        protected string JsonSerialize(object value)
        {
            return JsonConvert.SerializeObject(value, TelegramBot.JsonSettings);
        }
    }
}
