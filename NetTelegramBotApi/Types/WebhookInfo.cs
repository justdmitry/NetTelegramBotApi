using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Contains information about the current status of a webhook.
    /// </summary>
    public class WebhookInfo
    {
        /// <summary>
        /// Webhook URL, may be empty if webhook is not set up
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// True, if a custom certificate was provided for webhook certificate checks
        /// </summary>
        public bool HasCustomCertificate { get; set; }

        /// <summary>
        /// Number of updates awaiting delivery
        /// </summary>
        public long PendingUpdateCount { get; set; }

        /// <summary>
        /// Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        public DateTimeOffset? LastErrorDate { get; set; }

        /// <summary>
        /// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        public string LastErrorMessage { get; set; }
    }
}
