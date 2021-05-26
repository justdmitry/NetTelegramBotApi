using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetTelegramBotApi.Util
{
    public class UnixDateTimeConverter : JsonConverter<DateTimeOffset>
    {
        private static readonly DateTimeOffset ZeroDateTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var t = reader.GetInt64();
            return ZeroDateTime.AddSeconds(t).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
