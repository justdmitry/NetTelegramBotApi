namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a file ready to be downloaded.
    /// The file can be downloaded via the link https://api.telegram.org/file/bot<token>/<file_path>.
    /// It is guaranteed that the link will be valid for at least 1 hour.
    /// When the link expires, a new one can be requested by calling <see cref="NetTelegramBotApi.Requests.GetFile">getFile</see>.
    /// </summary>
    public class File : IPostProcessingRequired
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Optional. File size, if known
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Optional. File path. Use https://api.telegram.org/file/bot<token>/<file_path> to get the file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Full Url, where file body/content must be downloaded from.
        /// </summary>
        /// <remarks>Extension of Telegram type!</remarks>
        public string FileDownloadUrl { get; private set; }

        public void PostProcess(string botAccessToken)
        {
            FileDownloadUrl = "https://api.telegram.org/file/bot" + botAccessToken + "/" + FilePath;
        }
    }
}
