namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterCamelCase))]
    public enum ParseMode
    {
        Markdown,
        MarkdownV2,
        HTML,
    }
}
