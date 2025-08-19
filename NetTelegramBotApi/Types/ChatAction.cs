namespace NetTelegramBotApi.Types
{
    [JsonConverter(typeof(JsonStringEnumConverterSnakeCaseLower))]
    public enum ChatAction
    {
        Typing,
        UploadPhoto,
        RecordVideo,
        UploadVideo,
        RecordVoice,
        UploadVoice,
        UploadDocument,
        ChooseSticker,
        FindLocation,
        RecordVideoNote,
        UploadVideoNote,
    }
}
