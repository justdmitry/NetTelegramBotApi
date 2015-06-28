using System;
using System.IO;

namespace NetTelegramBotApi.Requests
{
    public class FileToSend
    {
        public FileToSend(string existingFileId)
        {
            this.AlreadyUploaded = true;
            this.ExistingFileId = existingFileId;
        }

        public FileToSend(Stream fileContent, string fileName)
        {
            this.AlreadyUploaded = false;
            this.NewFileContent = fileContent;
            this.NewFileName = fileName;
        }

        /// <summary>
        /// True, if file is already uploaded to server, only <see cref="ExistingFileId"/> is used.
        /// Otherwise, <see cref="NewFileContent"/> and <see cref="NewFileName"/> are used;
        /// </summary>
        public bool AlreadyUploaded { get; private set; }

        public string ExistingFileId { get; private set; }

        public Stream NewFileContent { get; private set; }

        public string NewFileName { get; private set; }
    }
}
