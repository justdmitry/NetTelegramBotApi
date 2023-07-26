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
        /// Optional. Unique identifier of a message thread to which the message belongs; for supergroups only
        /// </summary>
        public long? MessageThreadId { get; set; }

        /// <summary>
        /// Optional. Sender, can be empty for messages sent to channels
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
        public Chat Chat { get; set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
        public User ForwardFrom { get; set; }

        /// <summary>
        /// Optional. For messages forwarded from a channel, information about the original channel
        /// </summary>
        public Chat ForwardFromChat { get; set; }

        /// <summary>
        /// Optional. For forwarded channel posts, identifier of the original message in the channel
        /// </summary>
        public long? ForwardFromMessageId { get; set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        public DateTimeOffset? ForwardDate { get; set; }

        /// <summary>
        /// Optional. For replies, the original message.
        /// Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        public Message ReplyToMessage { get; set; }

        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        public DateTimeOffset? EditDate { get; set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message, 0-4096 characters.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        /// </summary>
        public MessageEntity[] Entities { get; set; }

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
        /// Optional. Message is a voice message, information about the file
        /// </summary>
        public Voice Voice { get; set; }

        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Optional. Message is a venue, information about the venue
        /// </summary>
        public Venue Venue { get; set; }

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be the bot itself)
        /// </summary>
        public User NewChatMember { get; set; }

        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be the bot itself)
        /// </summary>
        public User LeftChatMember { get; set; }

        /// <summary>
        /// Optional. A group title was changed to this value
        /// </summary>
        public string NewChatTitle { get; set; }

        /// <summary>
        /// Optional. A group photo was change to this value
        /// </summary>
        public PhotoSize[] NewChatPhoto { get; set; }

        /// <summary>
        /// Optional. Service message: the chat photo was deleted
        /// </summary>
        public bool DeleteChatPhoto { get; set; }

        /// <summary>
        /// Optional. Service message: the group has been created
        /// </summary>
        public bool GroupChatCreated { get; set; }

        /// <summary>
        /// Optional. Service message: the supergroup has been created
        /// </summary>
        /// <remarks>
        /// This field can‘t be received in a message coming through updates,
        /// because bot can’t be a member of a supergroup when it is created.
        /// It can only be found in reply_to_message if someone replies to a very first message
        /// in a directly created supergroup.
        /// </remarks>
        public bool SupergroupChatCreated { get; set; }

        /// <summary>
        /// Optional. Service message: the channel has been created
        /// </summary>
        /// <remarks>
        /// This field can‘t be received in a message coming through updates,
        /// because bot can’t be a member of a channel when it is created.
        /// It can only be found in reply_to_message if someone replies to a very first message in a channel.
        /// </remarks>
        public bool ChannelChatCreated { get; set; }

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier
        /// </summary>
        public long MigrateToChatId { get; set; }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier
        /// </summary>
        public long MigrateFromChatId { get; set; }

        /// <summary>
        /// Optional. Specified message was pinned
        /// </summary>
        /// <remarks>
        /// Note that the Message object in this field will not contain further reply_to_message fields
        /// even if it is itself a reply.
        /// </remarks>
        public Message PinnedMessage { get; set; }
    }
}
