namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send rich messages.
    /// If the message contains a block with a media element, then the bot must have the right to send the media to the chat.
    /// On success, the sent Message is returned.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendrichmessage"/>
    /// </remarks>
    public class SendRichMessage() : RequestBase<Message>("sendRichMessage")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public long? DirectMessagesTopicId { get; set; }

        public EphemeralMessageParameters? EphemeralMessageParameters { get; set; }

        public required InputRichMessage RichMessage { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public bool? AllowPaidBroadcast { get; set; }

        public string? MessageEffectId { get; set; }

        public SuggestedPostParameters? SuggestedPostParameters { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }

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
