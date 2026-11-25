namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to stream a partial rich message to a user while the message is being generated.
    /// Note that the streamed draft is ephemeral and acts as a temporary 30-second preview - once the output is finalized, you must call sendRichMessage with the complete message to persist it in the user's chat.
    /// Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendrichmessagedraft"/>
    /// </remarks>
    public class SendRichMessageDraft() : RequestBase<Message>("sendRichMessageDraft")
    {
        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required long DraftId { get; set; }

        public required InputRichMessage RichMessage { get; set; }

        public bool? CanStop { get; set; }

        public bool? KeepOnStop { get; set; }

        protected override bool HaveFiles()
        {
            return RichMessage.HaveFiles();
        }

        protected override void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            RichMessage.CreateAttachments(multipartFormDataContent);
        }
    }
}
