namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum ChatMemberStatus
    {
        Unknown,
        Creator,
        Administrator,
        Member,
        Restricted,
        Left,
        Kicked,
    }
}
