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

        public static Task<Message> SendMessage(this ITelegramBot bot, SendMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> ForwardMessage(this ITelegramBot bot, ForwardMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<MessageId[]> ForwardMessages(this ITelegramBot bot, ForwardMessages request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }
    }
}
