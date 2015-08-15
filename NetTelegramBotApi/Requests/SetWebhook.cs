using System;
using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to specify a url and receive incoming updates via an outgoing webhook. 
    /// Whenever there is an update for the bot, we will send an HTTPS POST request to the specified url, 
    /// containing a JSON-serialized Update. In case of an unsuccessful request, we will give up after 
    /// a reasonable amount of attempts.
    /// </summary>
    /// <remarks>
    /// If you'd like to make sure that the Webhook request comes from Telegram, 
    /// we recommend using a secret path in the URL, e.g. www.example.com/<secret_path>. 
    /// Since nobody else knows this secret_path, you can be pretty sure it’s us.
    /// </remarks>
    public class SetWebhook : RequestBase<bool>
    {
        /// <param name="url">HTTPS url to send updates to. Use null or empty string to remove webhook integration</param>
        public SetWebhook(string url)
            : base("setWebhook")
        {
            this.Url = url;
        }

        /// <summary>
        /// HTTPS url to send updates to. Use an empty string to remove webhook integration
        /// </summary>
        public string Url { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("url", Url),
            };
            return new FormUrlEncodedContent(values);
        }
    }
}
