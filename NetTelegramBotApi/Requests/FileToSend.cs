using System.IO;

namespace NetTelegramBotApi.Requests
{
    public class FileToSend
    {
        /// <summary>
        /// If the file is already stored somewhere on the Telegram servers, you don't need to reupload it:
        /// each file object has a file_id field, simply pass this file_id as a parameter instead of uploading.
        /// There are no limits for files sent this way.
        /// </summary>
        /// <remarks>
        /// Since October 2016, provide Telegram with an HTTP URL for the file to be sent.
        /// Telegram will download and send the file. 5 MB max size for photos and 20 MB max for other types of content.
        /// </remarks>
        public FileToSend(string existingFileId)
        {
            this.AlreadyUploaded = true;
            this.ExistingFileId = existingFileId;
        }

        /// <summary>
        /// Post the file using multipart/form-data in the usual way that files are uploaded via the browser.
        /// 10 MB max size for photos, 50 MB for other files.
        /// </summary>
        public FileToSend(Stream fileContent, string fileName)
        {
            this.AlreadyUploaded = false;
            this.NewFileContent = fileContent;
            this.NewFileName = fileName;
        }

        /// <summary>
        /// True, if file is already uploaded to server, only <see cref="ExistingFileId"/> is used.
        /// Otherwise, <see cref="NewFileContent"/> and <see cref="NewFileName"/> are used.
        /// </summary>
        public bool AlreadyUploaded { get; private set; }

        public string ExistingFileId { get; private set; }

        public Stream NewFileContent { get; private set; }

        public string NewFileName { get; private set; }
    }
}
