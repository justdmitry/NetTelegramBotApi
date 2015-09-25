using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Base class for all file-sending requests.
    /// </summary>
    public abstract class SendFileRequestBase<T> : RequestBase<T>
    {
        public SendFileRequestBase(string methodName, string fileParameterName)
            : base(methodName)
        {
            this.FileParameterName = fileParameterName;
        }

        /// <summary>
        /// Unique identifier for the message recipient — User or GroupChat id
        /// </summary>
        public long ChatId { get; protected set; }

        public FileToSend File { get; protected set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, 
        /// instructions to hide keyboard or to force a reply from the user.
        /// </summary>
        public ReplyMarkupBase ReplyMarkup { get; set; }

        /// <summary>
        /// Name of parameter (when calling server) with file info (eg 'photo', 'video', 'document')
        /// </summary>
        protected string FileParameterName { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (File == null || File.AlreadyUploaded)
            {
                var dic = new Dictionary<string, string>();
                if (File != null)
                {
                    dic.Add(FileParameterName, File.ExistingFileId);
                }
                AppendParameters((string name, string value) => dic.Add(name, value));
                return new FormUrlEncodedContent(dic);
            }
            else
            {
                var content = new MultipartFormDataContent();
                AppendParameters((string name, string value) => content.Add(new StringContent(value), name));

                // HACK, but utf-8 file names (issue #5) sent correctly now (in filename, not filename*),
                //   thanks to http://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
                var contentDispositionValue = string.Format(
                    "form-data; name={0}; filename=\"{1}\"",
                    FileParameterName,
                    string.Concat(Encoding.UTF8.GetBytes(File.NewFileName).Select(x => (char)x).Where(x => x != '"'))
                    );
                var fileContent = new StreamContent(File.NewFileContent);
                fileContent.Headers.Add("Content-Disposition",contentDispositionValue);
                content.Add(fileContent);

                return content;
            }
        }

        protected virtual void AppendParameters(Action<string, string> appendCallback)
        {
            appendCallback("chat_id", ChatId.ToString());
            if (ReplyToMessageId.HasValue)
            {
                appendCallback("reply_to_message_id", ReplyToMessageId.Value.ToString());
            }
            if (ReplyMarkup != null)
            {
                appendCallback("reply_markup", JsonSerialize(ReplyMarkup));
            }
        }
    }
}
