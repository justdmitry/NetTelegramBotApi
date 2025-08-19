namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum ReactionTypeType
    {
        Emoji,
        CustomEmoji,
        Paid,
    }
}
