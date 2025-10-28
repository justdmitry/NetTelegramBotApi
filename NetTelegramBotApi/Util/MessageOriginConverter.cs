using System.Text.Json.Nodes;

namespace NetTelegramBotApi.Util
{
    public class MessageOriginConverter : JsonConverter<MessageOrigin>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(MessageOrigin);
        }

        public override MessageOrigin? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var node = JsonNode.Parse(ref reader, new() { PropertyNameCaseInsensitive = true });
            if (node == null)
            {
                return null;
            }

            var typeText = node[nameof(MessageOrigin.Type)]?.GetValue<string>();
            if (string.IsNullOrWhiteSpace(typeText))
            {
                return null;
            }

            if (!Enum.TryParse<MessageOriginType>(typeText, true, out var status))
            {
                return null;
            }

            return status switch
            {
                MessageOriginType.User => JsonSerializer.Deserialize<MessageOriginUser>(node, options),
                MessageOriginType.HiddenUser => JsonSerializer.Deserialize<MessageOriginHiddenUser>(node, options),
                MessageOriginType.Chat => JsonSerializer.Deserialize<MessageOriginChat>(node, options),
                MessageOriginType.Channel => JsonSerializer.Deserialize<MessageOriginChannel>(node, options),
                _ => JsonSerializer.Deserialize<MessageOrigin>(node, options),
            };
        }

        public override void Write(Utf8JsonWriter writer, MessageOrigin? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
