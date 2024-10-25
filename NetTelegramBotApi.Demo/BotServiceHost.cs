namespace NetTelegramBotApi.Demo
{
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NetTelegramBotApi.Types;

    public class BotServiceHost(ITelegramBot bot, ILogger<BotServiceHost> logger)
        : BackgroundService
    {
        private string uploadedPhotoId = string.Empty;
        private string uploadedDocumentId = string.Empty;

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
            else if (msg.Text == "/photo")
            {
                if (string.IsNullOrEmpty(uploadedPhotoId))
                {
                    await bot.SendChatAction(new() { ChatId = msg.Chat.Id, Action = ChatAction.UploadPhoto });
                    await Task.Delay(500);

                    using var photoData = typeof(Program).Assembly.GetManifestResourceStream("NetTelegramBotApi.Demo.t_logo.png");
                    var resp = await bot.SendPhoto(new() { ChatId = msg.Chat.Id, Photo = (photoData, "Telegram_logo.png"), Caption = "Telegram logo" });
                    uploadedPhotoId = resp.Photo.Last().FileId;
                }
                else
                {
                    await bot.SendPhoto(new() { ChatId = msg.Chat.Id, Photo = uploadedPhotoId, Caption = "Resending photo id=" + uploadedPhotoId });
                }
            }
            else if (msg.Text == "/doc")
            {
                if (string.IsNullOrEmpty(uploadedDocumentId))
                {
                    await bot.SendChatAction(new() { ChatId = msg.Chat.Id, Action = ChatAction.UploadDocument });
                    await Task.Delay(500);

                    using var docData = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream("NetTelegramBotApi.Demo.Telegram_Bot_API.htm");
                    var resp = await bot.SendDocument(new() { ChatId = msg.Chat.Id, Document = (docData, "Telegram_Bot_API.htm"), Caption = "Here is your file" });
                    uploadedDocumentId = resp.Document.FileId;
                }
                else
                {
                    await bot.SendDocument(new() { ChatId = msg.Chat.Id, Document = uploadedDocumentId, Caption = "Resending doc id=" + uploadedDocumentId });
                }
            }
            else if (msg.Text == "/docutf8")
            {
                await bot.SendChatAction(new() { ChatId = msg.Chat.Id, Action = ChatAction.UploadDocument });
                await Task.Delay(500);

                using var docData = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream("NetTelegramBotApi.Demo.Пример_UTF8_filename.txt");
                await bot.SendDocument(new() { ChatId = msg.Chat.Id, Document = (docData, "Пример_UTF8_filename.txt"), Caption = "Here is your file with UTF8" });
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
