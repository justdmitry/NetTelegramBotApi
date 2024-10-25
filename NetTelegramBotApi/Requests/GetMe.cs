namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// A simple method for testing your bot's auth token. Requires no parameters.
    /// Returns basic information about the bot in form of a <see cref="User"/> object.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getme"/>
    /// </remarks>
    public class GetMe() : RequestBase<User>("getMe")
    {
        // Nothing.
    }
}
