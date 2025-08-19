namespace NetTelegramBotApi.Types
{
    [JsonDerivedType(typeof(InputMediaPhoto))]
    [JsonDerivedType(typeof(InputMediaVideo))]
    [JsonDerivedType(typeof(InputMediaAnimation))]
    [JsonDerivedType(typeof(InputMediaAudio))]
    [JsonDerivedType(typeof(InputMediaDocument))]
    public abstract class InputMedia
    {
        public abstract string Type { get; }
    }
}
