namespace NetTelegramBotApi.Demo
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NetTelegramBotApi.Types;

    public class BotServiceHost(ITelegramBot bot, ILogger<BotServiceHost> logger)
        : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var me = await bot.GetMe(stoppingToken);
            logger.LogInformation("Hello, I'm {Name} (@{Username})!", me.FirstName, me.Username);

            long offset = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                var updates = await bot.GetUpdates(new() { Offset = offset }, stoppingToken);
                if (updates == null)
                {
                    continue;
                }

                foreach (var update in updates)
                {
                    offset = update.UpdateId + 1;
                    var msg = update.Message;
                    if (msg != null)
                    {
                        try
                        {
                            await ProcessMessage(msg);
                        }
                        catch (RequestFailedException ex)
                        {
                            logger.LogError(ex, "Ooops");
                        }
                    }
                }
            }
        }

        protected async Task ProcessMessage(Message msg)
        {
            logger.LogInformation(
                "Msg from {Name} ({Username}) at {Date}: {Text}",
                msg.From?.FirstName,
                msg.From?.Username,
                msg.Date,
                msg.Text);

            if (string.IsNullOrEmpty(msg.Text))
            {
                return;
            }
            else if (msg.Text == "/help")
            {
                var keyb = new ReplyKeyboardMarkup()
                {
                    Keyboard =
                    [
                        [new() { Text = "/photo" }, new() { Text = "/doc" }, new() { Text = "/longmsg" }, new() { Text = "/docutf8" }],
                        [new() { Text = "/contact", RequestContact = true }, new() { Text = "/location", RequestLocation = true }],
                        [new() { Text = "/help" }],
                    ],
                    OneTimeKeyboard = true,
                    ResizeKeyboard = true,
                };
                await bot.SendMessage(new() { ChatId = msg.Chat.Id, Text = "Here is all my commands", ReplyMarkup = keyb });
            }
            else if (msg.Text == "/longmsg")
            {
                var text = new string('X', 4096 + 1);
                await bot.SendMessage(new() { ChatId = msg.Chat.Id, Text = text });
            }
            else if (msg.Text.Length % 2 == 0)
            {
                await bot.SendMessage(new()
                {
                    ChatId = msg.Chat.Id,
                    Text = "You wrote: \r\n" + msg.Text.EscapeMarkdownV2(),
                    ParseMode = ParseMode.MarkdownV2,
                });
            }
            else
            {
                await bot.ForwardMessage(new()
                {
                    ChatId = msg.Chat.Id,
                    FromChatId = msg.Chat.Id,
                    MessageId = msg.MessageId,
                });
            }
        }
    }
}
