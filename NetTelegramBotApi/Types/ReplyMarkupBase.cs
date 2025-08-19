namespace NetTelegramBotApi.Types
{
    [JsonDerivedType(typeof(InlineKeyboardMarkup))]
    [JsonDerivedType(typeof(ReplyKeyboardMarkup))]
    [JsonDerivedType(typeof(ReplyKeyboardRemove))]
    [JsonDerivedType(typeof(ForceReply))]
    public abstract class ReplyMarkupBase
    {
        // Nothing
    }
}
