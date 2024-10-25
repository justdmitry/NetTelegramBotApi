namespace NetTelegramBotApi.Util
{
    public class InputFileOrStringConverter : JsonConverter<InputFileOrString>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(InputFileOrString);
        }

        public override InputFileOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, InputFileOrString value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.String);
        }
    }
}
