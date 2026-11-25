namespace NetTelegramBotApi.Types
{
    [JsonDerivedType(typeof(InputMediaAnimation))]
    [JsonDerivedType(typeof(InputMediaAudio))]
    [JsonDerivedType(typeof(InputMediaDocument))]
    [JsonDerivedType(typeof(InputMediaPhoto))]
    [JsonDerivedType(typeof(InputMediaVideo))]
    [JsonDerivedType(typeof(InputMediaVoiceNote))]
    public abstract class InputMedia
    {
        public abstract string Type { get; }

        public abstract bool HaveFiles();

        public abstract void CreateAttachments(MultipartFormDataContent multipartFormDataContent, string? fixedId = null);
    }
}
