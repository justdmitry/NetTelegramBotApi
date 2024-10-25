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

        public static Task<Message> ForwardMessage(this ITelegramBot bot, ForwardMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<MessageId[]> ForwardMessages(this ITelegramBot bot, ForwardMessages request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendAnimation(this ITelegramBot bot, SendAnimation request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendAudio(this ITelegramBot bot, SendAudio request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> SendChatAction(this ITelegramBot bot, SendChatAction request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendDocument(this ITelegramBot bot, SendDocument request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendMessage(this ITelegramBot bot, SendMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendPhoto(this ITelegramBot bot, SendPhoto request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendVideo(this ITelegramBot bot, SendVideo request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendVideoNote(this ITelegramBot bot, SendVideoNote request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> SendVoice(this ITelegramBot bot, SendVoice request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }
    }
}
