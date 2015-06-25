using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Unique message identifier
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// Conversation the message belongs to — <see cref="User"/> in case of a private message, <see cref="GroupChat"/> in case of a group
        /// </summary>
        public ChatBase Chat { get; set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
        public User ForwardFrom { get; set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        public long? ForwardDate { get; set; }

        /// <summary>
        /// Optional. For replies, the original message. 
        /// Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        public Message ReplyToMessage { get; set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
        public Audio Audio { get; set; }

        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        public PhotoSize[] Photo { get; set; }

        /// <summary>
        /// Optional. Message is a sticker, information about the sticker
        /// </summary>
        public Sticker Sticker { get; set; }

        /// <summary>
        /// Optional. Message is a video, information about the video
        /// </summary>
        public Video Video { get; set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself)
        /// </summary>
        public User NewChatParticipant { get; set; }

        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself)
        /// </summary>
        public User LeftChatParticipant { get; set; }

        /// <summary>
        /// Optional. A group title was changed to this value
        /// </summary>
        public string NewChatTitle { get; set; }

        /// <summary>
        /// Optional. A group photo was change to this value
        /// </summary>
        public PhotoSize[] NewChatPhoto { get; set; }

        /// <summary>
        /// Optional. Informs that the group photo was deleted
        /// </summary>
        public bool DeleteChatPhoto { get; set; }

        /// <summary>
        /// Optional. Informs that the group has been created
        /// </summary>
        public bool GroupChatCreated { get; set; }
    }
}
