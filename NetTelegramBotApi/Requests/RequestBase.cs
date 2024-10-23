using System.Net.Http;
using System.Text.Json;

namespace NetTelegramBotApi.Requests
{
    public abstract class RequestBase<T>
    {
        protected RequestBase(string methodName)
        {
            this.MethodName = methodName;
        }

        public string MethodName { get; protected set; }

        public abstract HttpContent CreateHttpContent();

        protected static string JsonSerialize(object value)
        {
            return JsonSerializer.Serialize(value, TelegramBot.JsonOptions);
        }
    }
}
