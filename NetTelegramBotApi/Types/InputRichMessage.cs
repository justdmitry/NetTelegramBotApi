namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes a rich message to be sent. Exactly one of the fields html, markdown, or blocks must be used.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputrichmessage"/>
    /// </remarks>
    public class InputRichMessage
    {
        public InputRichBlock[]? Blocks { get; set; }

        public string? Html { get; set; }

        public string? Markdown { get; set; }

        public InputRichMessageMedia[]? Media { get; set; }

        public bool? IsRtl { get; set; }

        public bool? SkipEntityDetection { get; set; }

        public bool HaveFiles()
        {
            return Media != null && Media.Length > 0;
        }

        public void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            if (Media != null && Media.Length > 0)
            {
                foreach (var media in Media)
                {
                    media.CreateAttachments(multipartFormDataContent);
                }
            }
        }
    }
}
