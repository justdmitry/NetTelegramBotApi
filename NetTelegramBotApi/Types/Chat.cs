using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Unique identifier for this chat
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Returns one of 'ChatType' members, based on chat 'Type' value
        /// </summary>
        /// <returns></returns>
        public ChatType GetChatType()
        {
            switch (Type)
            {
                case "private":
                    return ChatType.Private;
                case "group":
                    return ChatType.Group;
                case "supergroup":
                    return ChatType.Supergroup;
                case "channel":
                    return ChatType.Channel;
                default:
                    return ChatType.Unknown;
            }
        }

        /// <summary>
        /// Optional. Title, for channels and group chats
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. True if a group has ‘All Members Are Admins’ enabled.
        /// </summary>
        public bool AllMembersAreAdministrators { get; set; }
    }
}
