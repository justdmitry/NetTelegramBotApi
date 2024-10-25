namespace NetTelegramBotApi
{
    using System;
    using System.Net;

    public class RequestFailedException(string message) : Exception(message)
    {
        /// <summary>
        /// HTTP Status Code retuned by server.
        /// </summary>
        public required HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Response body text.
        /// </summary>
        public required string ResponseBody { get; set; }

        /// <summary>
        /// Optional. Human-readable description of the result (by Telegram).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Contents are subject to change in the future (by Telegram).
        /// </summary>
        public long? ErrorCode { get; set; }

        /// <summary>
        /// Optional. Can help to automatically handle the error (by Telegram).
        /// </summary>
        public ResponseParameters? Parameters { get; set; }
    }
}
