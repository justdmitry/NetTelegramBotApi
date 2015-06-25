using System;
using NetTelegramBotApi.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelegramBotApi.Util
{
    public class ChatBaseConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ChatBase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var title = (string)jo["title"];
            var firstName = (string)jo["first_name"];
            if (!string.IsNullOrEmpty(firstName))
            {
                return jo.ToObject<User>(serializer);
            }
            if (!string.IsNullOrEmpty(title))
            {
                return jo.ToObject<GroupChat>(serializer);
            }
            throw new ApplicationException("Can't decode");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
