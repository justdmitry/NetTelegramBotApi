namespace NetTelegramBotApi
{
    using NetTelegramBotApi.Requests;

    public static class TelegramBotExtensions
    {
        public static Task<User> GetMe(this ITelegramBot bot, CancellationToken cancellationToken = default)
        {
            return bot.Execute(new GetMe(), cancellationToken);
        }

        public static Task<Update[]> GetUpdates(this ITelegramBot bot, GetUpdates request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }
    }
}
