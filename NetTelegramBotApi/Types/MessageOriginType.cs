namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum MessageOriginType
    {
        Unknown,
        User,
        HiddenUser,
        Chat,
        Channel,
    }
}
