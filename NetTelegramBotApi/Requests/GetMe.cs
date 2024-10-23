using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// A simple method for testing your bot's auth token. Requires no parameters.
    /// Returns basic information about the bot in form of a User object.
    /// </summary>
    public class GetMe : RequestBase<User>
    {
        public GetMe()
            : base("getMe")
        {
            // Nothing
        }

        public override HttpContent CreateHttpContent()
        {
            return null;
        }
    }
}
