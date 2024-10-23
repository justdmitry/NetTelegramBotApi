namespace NetTelegramBotApi.Types
{
    public enum MessageEntityType : byte
    {
        Unknown = 0,
        Mention = 1,
        Hashtag = 2,
        BotCommand = 3,
        Url = 4,
        Email = 5,
        Bold = 6,
        Italic = 7,
        Code = 8,
        Pre = 9,
        TextLink = 10,
        TextMention = 11,
    }
}
