namespace NetTelegramBotApi
{
    /// <summary>
    /// The response contains a JSON object.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#making-requests"/>
    /// </remarks>
    /// <typeparam name="TResult">Result of the query.</typeparam>
    public class ResponseBase<TResult>
    {
        public bool Ok { get; set; }

        public string? Description { get; set; }

        public TResult? Result { get; set; }

        public long? ErrorCode { get; set; }

        public ResponseParameters? Parameters { get; set; }
    }
}
