namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes a media element embedded in an outgoing rich message.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputrichmessagemedia"/>
    /// </remarks>
    public class InputRichMessageMedia
    {
        public required string Id { get; set; }

        public required InputMedia Media { get; set; }

        public void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            Media.CreateAttachments(multipartFormDataContent, Id);
        }
    }
}
