namespace NetTelegramBotApi
{
    using System;
    using System.Net;
    using NetTelegramBotApi.Types;

    public class BotRequestException : Exception
    {
        public BotRequestException() : base() { }

        public BotRequestException(string message) : base(message) { }

        public BotRequestException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// HTTP Status Code retuned by server
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Response body text
        /// </summary>
        public string ResponseBody { get; set; }

        /// <summary>
        /// Optional. Human-readable description of the result (by Telegram)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Contents are subject to change in the future (by Telegram)
        /// </summary>
        public long? ErrorCode { get; set; }

        /// <summary>
        /// Optional. Can help to automatically handle the error
        /// </summary>
        public ResponseParameters Parameters { get; set; }
    }
}
