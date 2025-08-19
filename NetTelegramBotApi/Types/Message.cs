namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#message"/>
    /// </remarks>
    public class Message
    {
        public long MessageId { get; set; }

        public long? MessageThreadId { get; set; }

        public User? From { get; set; }

        public Chat? SenderChat { get; set; }

        public long? SenderBoostCount { get; set; }

        public User? SenderBusinessBot { get; set; }

        public DateTimeOffset Date { get; set; }

        public string? BusinessConnectionId { get; set; }

        public Chat Chat { get; set; } = default!;

        public MessageOrigin? ForwardOrigin { get; set; }

        public bool? IsTopicMessage { get; set; }

        public bool? IsAutomaticForward { get; set; }

        public Message? ReplyToMessage { get; set; }

        public ExternalReplyInfo? ExternalReply { get; set; }

        public TextQuote? Quote { get; set; }

        public Story? ReplyToStory { get; set; }

        public User? ViaBot { get; set; }

        public DateTimeOffset? EditDate { get; set; }

        public bool? HasProtectedContent { get; set; }

        public bool? IsFromOffline { get; set; }

        public string? MediaGroupId { get; set; }

        public string? AuthorSignature { get; set; }

        public string? Text { get; set; }

        public MessageEntity[]? Entities { get; set; }

        public LinkPreviewOptions? LinkPreviewOptions { get; set; }

        public string? EffectId { get; set; }

        public Animation? Animation { get; set; }

        public Audio? Audio { get; set; }

        public Document? Document { get; set; }

        public PaidMediaInfo? PaidMedia { get; set; }

        public PhotoSize[]? Photo { get; set; }

        public Sticker? Sticker { get; set; }

        public Story? Story { get; set; }

        public Video? Video { get; set; }

        public VideoNote? VideoNote { get; set; }

        public Voice? Voice { get; set; }

        public string? Caption { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public bool? HasMediaSpoiler { get; set; }

        public Contact? Contact { get; set; }

        public Dice? Dice { get; set; }

        public Game? Game { get; set; }

        public Poll? Poll { get; set; }

        public Venue? Venue { get; set; }

        public Location? Location { get; set; }

        public User[]? NewChatMembers { get; set; }

        public User? LeftChatMember { get; set; }

        public string? NewChatTitle { get; set; }

        public PhotoSize[]? NewChatPhoto { get; set; }

        public bool? DeleteChatPhoto { get; set; }

        public bool? GroupChatCreated { get; set; }

        public bool? SupergroupChatCreated { get; set; }

        public bool? ChannelChatCreated { get; set; }

        // TODO: Add other fields
    }
}
