using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Unique identifier for this chat.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”. See also <seealso cref="GetChatType"/>.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Optional. Title, for supergroups, channels and group chats.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. First name of the other party in a private chat.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. True, if the supergroup chat is a forum (has topics enabled).
        /// </summary>
        public bool IsForum { get; set; }

        /// <summary>
        /// NOT IMPLEMENTED. Optional. Chat photo. Returned only in getChat.
        /// </summary>
        public object Photo { get; set; }

        /// <summary>
        /// Optional. If non-empty, the list of all active chat usernames; for private chats, supergroups and channels. Returned only in getChat.
        /// </summary>
        public string[] ActiveUsernames { get; set; }

        /// <summary>
        /// Optional. Custom emoji identifier of emoji status of the other party in a private chat. Returned only in getChat.
        /// </summary>
        public string EmojiStatusCustomEmojiId { get; set; }

        /// <summary>
        /// Optional. Bio of the other party in a private chat. Returned only in getChat.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Optional. True, if privacy settings of the other party in the private chat allows to use tg://user?id=&lt;user_id&gt; links only in chats with the user. Returned only in getChat.
        /// </summary>
        public bool HasPrivateForwards { get; set; }

        /// <summary>
        /// Optional. True, if the privacy settings of the other party restrict sending voice and video note messages in the private chat. Returned only in getChat.
        /// </summary>
        public bool HasRestrictedVoiceAndVideoMessages { get; set; }

        /// <summary>
        /// Optional. True, if users need to join the supergroup before they can send messages. Returned only in getChat.
        /// </summary>
        public bool JoinToSendMessages { get; set; }

        /// <summary>
        /// Optional. True, if all users directly joining the supergroup need to be approved by supergroup administrators. Returned only in getChat.
        /// </summary>
        public bool JoinByRequest { get; set; }

        /// <summary>
        /// Optional. Description, for groups, supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional. Primary invite link, for groups, supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string InviteLink { get; set; }

        /// <summary>
        /// Optional. The most recent pinned message (by sending date). Returned only in getChat.
        /// </summary>
        public Message PinnedMessage { get; set; }

        /// <summary>
        /// NOT IMPLEMENTED. Optional. Default chat member permissions, for groups and supergroups. Returned only in getChat.
        /// </summary>
        public object Permissions { get; set; }

        /// <summary>
        /// Optional. For supergroups, the minimum allowed delay between consecutive messages sent by each unpriviledged user; in seconds. Returned only in getChat.
        /// </summary>
        public int SlowModeDelay { get; set; }

        /// <summary>
        /// Optional. The time after which all messages sent to the chat will be automatically deleted; in seconds. Returned only in getChat.
        /// </summary>
        public int MessageAutoDeleteTime { get; set; }

        /// <summary>
        /// Optional. True, if aggressive anti-spam checks are enabled in the supergroup. The field is only available to chat administrators. Returned only in getChat.
        /// </summary>
        public bool HasAggressiveAntiSpamEnabled { get; set; }

        /// <summary>
        /// Optional. True, if non-administrators can only get the list of bots and administrators in the chat. Returned only in getChat.
        /// </summary>
        public bool HasHiddenMembers { get; set; }

        /// <summary>
        /// Optional. True, if messages from the chat can't be forwarded to other chats. Returned only in getChat.
        /// </summary>
        public bool HasProtectedContent { get; set; }

        /// <summary>
        /// Optional. For supergroups, name of group sticker set. Returned only in getChat.
        /// </summary>
        public string StickerSetName { get; set; }

        /// <summary>
        /// Optional. True, if the bot can change the group sticker set. Returned only in getChat.
        /// </summary>
        public bool CanSetStickerSet { get; set; }

        /// <summary>
        /// Optional. Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa; for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public long LinkedChatId { get; set; }

        /// <summary>
        /// NOT IMPLEMENTED. Optional. For supergroups, the location to which the supergroup is connected. Returned only in getChat.
        /// </summary>
        public object Location { get; set; }

        /// <summary>
        /// Returns one of 'ChatType' members, based on chat 'Type' value.
        /// </summary>
        public ChatType GetChatType()
        {
            return Type switch
            {
                "private" => ChatType.Private,
                "group" => ChatType.Group,
                "supergroup" => ChatType.Supergroup,
                "channel" => ChatType.Channel,
                _ => ChatType.Unknown,
            };
        }
    }
}
