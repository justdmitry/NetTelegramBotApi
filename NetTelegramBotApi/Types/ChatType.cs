namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Type of the chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chat"/>
    /// </remarks>
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum ChatType
    {
        Unknown,
        Private,
        Group,
        Supergroup,
        Channel,
    }
}
