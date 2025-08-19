namespace NetTelegramBotApi.Util
{
    public class IntegerOrStringConverter : JsonConverter<IntegerOrString>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(IntegerOrString);
        }

        public override IntegerOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, IntegerOrString value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
