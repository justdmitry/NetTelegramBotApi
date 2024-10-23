using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Base class for all file-sending requests.
    /// </summary>
    public abstract class SendFileRequestBase<T> : RequestBase<T>
    {
        public SendFileRequestBase(long chatId, string methodName, string fileParameterName)
            : base(methodName)
        {
            this.ChatId = chatId;
            this.FileParameterName = fileParameterName;
        }

        public SendFileRequestBase(string channelName, string methodName, string fileParameterName)
            : base(methodName)
        {
            this.ChannelName = channelName;
            this.FileParameterName = fileParameterName;
        }

        /// <summary>
        /// Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public long? MessageThreadId { get; set; }

        public FileToSend File { get; protected set; }

        /// <summary>
        /// Sends the message silently.
        /// iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

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
                fileContent.Headers.Add("Content-Disposition", contentDispositionValue);
                content.Add(fileContent);

                return content;
            }
        }

        protected virtual void AppendParameters(Action<string, string> appendCallback)
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new Exception("Use ChatId or ChannelName, not both.");
            }

            if (ChatId.HasValue)
            {
                appendCallback("chat_id", ChatId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(ChannelName))
            {
                appendCallback("chat_id", ChannelName);
            }

            if (MessageThreadId.HasValue)
            {
                appendCallback("message_thread_id", MessageThreadId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (ReplyToMessageId.HasValue)
            {
                appendCallback("reply_to_message_id", ReplyToMessageId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (DisableNotification.HasValue)
            {
                appendCallback("disable_notification", DisableNotification.Value.ToString());
            }

            if (ReplyMarkup != null)
            {
                appendCallback("reply_markup", JsonSerialize(ReplyMarkup));
            }
        }
    }
}
