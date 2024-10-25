namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#update"/>
    /// </remarks>
    public class Update
    {
        public long UpdateId { get; set; }

        public Message? Message { get; set; }

        public Message? EditedMessage { get; set; }

        public Message? ChannelPost { get; set; }

        public Message? EditedChannelPost { get; set; }

        public BusinessConnection? BusinessConnection { get; set; }

        public Message? BusinessMessage { get; set; }

        public Message? EditedBusinessMessage { get; set; }

        public BusinessMessagesDeleted? DeletedBusinessMessages { get; set; }

        public MessageReactionUpdated? MessageReaction { get; set; }

        public MessageReactionCountUpdated? MessageReactionCount { get; set; }

        public InlineQuery? InlineQuery { get; set; }

        public ChosenInlineResult? ChosenInlineResult { get; set; }

        public CallbackQuery? CallbackQuery { get; set; }

        public ShippingQuery? ShippingQuery { get; set; }

        public PreCheckoutQuery? PreCheckoutQuery { get; set; }

        public PaidMediaPurchased? PurchasedPaidMedia { get; set; }

        public Poll? Poll { get; set; }

        public PollAnswer? PollAnswer { get; set; }

        public ChatMemberUpdated? MyChatMember { get; set; }

        public ChatMemberUpdated? ChatMember { get; set; }

        public ChatJoinRequest? ChatJoinRequest { get; set; }

        public ChatBoostUpdated? ChatBoost { get; set; }

        public ChatBoostRemoved? RemovedChatBoost { get; set; }
    }
}
