using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetTelegramBotApi.Util
{
    public class UnixDateTimeConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DateTimeOffset);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var t = reader.GetInt64();
            return DateTimeOffset.UnixEpoch.AddSeconds(t).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
