using System.Text.Json.Nodes;

namespace NetTelegramBotApi.Util
{
    public class ChatMemberConverter : JsonConverter<ChatMember>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(ChatMember);
        }

        public override ChatMember? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var node = JsonNode.Parse(ref reader, new() { PropertyNameCaseInsensitive = true });
            if (node == null)
            {
                return null;
            }

            var statusText = node[nameof(ChatMember.Status)]?.GetValue<string>();
            if (string.IsNullOrWhiteSpace(statusText))
            {
                return null;
            }

            if (!Enum.TryParse<ChatMemberStatus>(statusText, true, out var status))
            {
                return null;
            }

            return status switch
            {
                ChatMemberStatus.Creator => JsonSerializer.Deserialize<ChatMemberOwner>(node, options),
                ChatMemberStatus.Administrator => JsonSerializer.Deserialize<ChatMemberAdministrator>(node, options),
                ChatMemberStatus.Member => JsonSerializer.Deserialize<ChatMemberMember>(node, options),
                ChatMemberStatus.Restricted => JsonSerializer.Deserialize<ChatMemberRestricted>(node, options),
                ChatMemberStatus.Left => JsonSerializer.Deserialize<ChatMemberLeft>(node, options),
                ChatMemberStatus.Kicked => JsonSerializer.Deserialize<ChatMemberBanned>(node, options),
                _ => JsonSerializer.Deserialize<ChatMember>(node, options),
            };
        }

        public override void Write(Utf8JsonWriter writer, ChatMember? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
