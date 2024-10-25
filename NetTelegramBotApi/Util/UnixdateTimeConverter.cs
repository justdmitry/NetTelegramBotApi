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
            return DateTimeOffset.FromUnixTimeSeconds(t);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            var t = value.ToUnixTimeSeconds();
            writer.WriteNumberValue(t);
        }
    }
}
