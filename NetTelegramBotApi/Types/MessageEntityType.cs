namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum MessageEntityType
    {
        Unknown,
        Mention,
        Hashtag,
        Cashtag,
        BotCommand,
        Url,
        Email,
        PhoneNumber,
        Bold,
        Italic,
        Underline,
        Strikethrough,
        Spoiler,
        Blockquote,
        ExpandableBlockquote,
        Code,
        Pre,
        TextLink,
        TextMention,
        CustomEmoji,
    }
}
