using System;
using Newtonsoft.Json;

namespace NetTelegramBotApi.Util
{
    public class UnixDateTimeConverter : JsonConverter
    {
        private static readonly DateTimeOffset ZeroDateTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var t = (long)reader.Value;
            return ZeroDateTime.AddSeconds(t).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
