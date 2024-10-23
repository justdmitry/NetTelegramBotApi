using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method when you need to tell the user that something is happening on the bot's side.
    /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
    /// </summary>
    /// <remarks>
    /// We only recommend using this method when a response from the bot will take a <b>noticeable</b> amount of time to arrive.
    /// </remarks>
    public class SendChatAction : RequestBase<object>
    {
        public SendChatAction(long chatId, string action)
            : base("sendChatAction")
        {
            this.ChatId = chatId;
            this.Action = action;
        }

        public SendChatAction(string channelName, string action)
            : base("sendChatAction")
        {
            this.ChannelName = channelName;
            this.Action = action;
        }

        public SendChatAction(long chatId, ChatActionEnum action)
            : this(chatId, ConvertChatAction(action))
        {
            // Nothing
        }

        public SendChatAction(string channelName, ChatActionEnum action)
            : this(channelName, ConvertChatAction(action))
        {
            // Nothing
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

        /// <summary>
        /// Type of action to broadcast.
        /// Choose one, depending on what the user is about to receive:
        ///   typing for text messages,
        ///   upload_photo for photos,
        ///   record_video or upload_video for videos,
        ///   record_audio or upload_audio for audio files,
        ///   upload_document for general files,
        ///   find_location for location data.
        /// </summary>
        public string Action { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new Exception("Use ChatId or ChannelName, not both.");
            }

            var dic = new Dictionary<string, string>();

            if (ChatId.HasValue)
            {
                dic.Add("chat_id", ChatId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(ChannelName))
            {
                dic.Add("chat_id", ChannelName);
            }

            if (MessageThreadId.HasValue)
            {
                dic.Add("message_thread_id", MessageThreadId.Value.ToString(CultureInfo.InvariantCulture));
            }

            dic.Add("action", Action);

            return new FormUrlEncodedContent(dic);
        }

        protected static string ConvertChatAction(ChatActionEnum action)
        {
            return action switch
            {
                ChatActionEnum.Typing => "typing",
                ChatActionEnum.UploadPhoto => "upload_photo",
                ChatActionEnum.RecordVideo => "record_video",
                ChatActionEnum.UploadVideo => "upload_video",
                ChatActionEnum.RecordVoice => "record_voice",
                ChatActionEnum.UploadVoice => "upload_voice",
                ChatActionEnum.UploadDocument => "upload_document",
                ChatActionEnum.ChooseSticker => "choose_sticker",
                ChatActionEnum.FindLocation => "find_location",
                ChatActionEnum.RecordVideoNote => "record_video_note",
                ChatActionEnum.UploadVideoNote => "upload_video_note",
                _ => string.Empty,
            };
        }

        public enum ChatActionEnum
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
}
