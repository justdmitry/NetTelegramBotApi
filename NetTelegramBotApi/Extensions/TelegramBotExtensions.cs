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

        public static Task<bool> SetWebhook(this ITelegramBot bot, SetWebhook request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> DeleteWebhook(this ITelegramBot bot, DeleteWebhook request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<WebhookInfo> GetWebhookInfo(this ITelegramBot bot, CancellationToken cancellationToken = default)
        {
            return bot.Execute(new GetWebhookInfo(), cancellationToken);
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

        public static Task<bool> PinChatMessage(this ITelegramBot bot, PinChatMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> UnpinChatMessage(this ITelegramBot bot, UnpinChatMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> UnpinAllChatMessages(this ITelegramBot bot, UnpinAllChatMessages request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<ChatFullInfo> GetChat(this ITelegramBot bot, GetChat request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<ChatMember[]> GetChatAdministrators(this ITelegramBot bot, GetChatAdministrators request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<ChatMember> GetChatMember(this ITelegramBot bot, GetChatMember request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<int> GetChatMemberCount(this ITelegramBot bot, GetChatMemberCount request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> DeleteMessage(this ITelegramBot bot, DeleteMessage request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<bool> DeleteMessages(this ITelegramBot bot, DeleteMessages request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> EditMessageCaption(this ITelegramBot bot, EditMessageCaption request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> EditMessageMedia(this ITelegramBot bot, EditMessageMedia request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> EditMessageReplyMarkup(this ITelegramBot bot, EditMessageReplyMarkup request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }

        public static Task<Message> EditMessageText(this ITelegramBot bot, EditMessageText request, CancellationToken cancellationToken = default)
        {
            return bot.Execute(request, cancellationToken);
        }
    }
}
