using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using Microsoft.Extensions.Configuration;

namespace TelegramBotDemo_vNext
{
    public class Program
    {
        private static bool stopMe = false;

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
            var accessToken = config["AccessToken"];

            Console.WriteLine("Starting your bot...");
            Console.WriteLine();

            var t = Task.Run(() => RunBot(accessToken));

            Console.ReadLine();
            stopMe = true;
        }

        public static void RunBot(string accessToken)
        {
            var bot = new TelegramBot(accessToken);

            var me = bot.MakeRequestAsync(new GetMe()).Result;
            if (me == null)
            {
                Console.WriteLine("GetMe() FAILED. Do you forget to add your AccessToken to config.json?");
                Console.WriteLine("(Press ENTER to quit)");
                Console.ReadLine();
                return;
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("{0} (@{1}) connected!", me.FirstName, me.Username);

            Console.WriteLine();
            Console.WriteLine("Find @{0} in Telegram and send him a message - it will be displayed here", me.Username);
            Console.WriteLine("(Press ENTER to stop listening and quit)");
            Console.WriteLine();

            string uploadedPhotoId = null;
            string uploadedDocumentId = null;
            long offset = 0;
            while (!stopMe)
            {
                var updates = bot.MakeRequestAsync(new GetUpdates() { Offset = offset }).Result;
                if (updates != null)
                {
                    foreach (var update in updates)
                    {
                        offset = update.UpdateId + 1;
                        if (update.Message == null)
                        {
                            continue;
                        }
                        var from = update.Message.From;
                        var text = update.Message.Text;
                        var photos = update.Message.Photo;
                        var contact = update.Message.Contact;
                        var location = update.Message.Location;
                        Console.WriteLine(
                            "Msg from {0} {1} ({2}) at {4}: {3}",
                            from.FirstName,
                            from.LastName,
                            from.Username,
                            text,
                            update.Message.Date);

                        if (photos != null)
                        {
                            var webClient = new HttpClient();
                            foreach (var photo in photos)
                            {
                                Console.WriteLine("  New image arrived: size {1}x{2} px, {3} bytes, id: {0}", photo.FileId, photo.Height, photo.Width, photo.FileSize);
                                var file = bot.MakeRequestAsync(new GetFile(photo.FileId)).Result;
                                var tempFileName = System.IO.Path.GetTempFileName();
                                var bytes = webClient.GetByteArrayAsync(file.FileDownloadUrl).Result;
                                System.IO.File.WriteAllBytes(tempFileName, bytes);
                                Console.WriteLine("    Saved to {0}", tempFileName);
                            }
                        }
                        if (contact != null)
                        {
                            var req = new SendContact(update.Message.Chat.Id, contact.PhoneNumbet, contact.FirstName)
                            {
                                LastName = contact.LastName
                            };
                            bot.MakeRequestAsync(req).Wait();
                        }
                        if (location != null)
                        {
                            var req = new SendLocation(update.Message.Chat.Id, location.Latitude, location.Longitude);
                            bot.MakeRequestAsync(req).Wait();
                        }

                        if (string.IsNullOrEmpty(text))
                        {
                            continue;
                        }
                        if (text == "/photo")
                        {
                            if (uploadedPhotoId == null)
                            {
                                var reqAction = new SendChatAction(update.Message.Chat.Id, "upload_photo");
                                bot.MakeRequestAsync(reqAction).Wait();
                                System.Threading.Thread.Sleep(500);
                                using (var photoData = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream("TelegramBotDemo-vNext.t_logo.png"))
                                {
                                    var req = new SendPhoto(update.Message.Chat.Id, new FileToSend(photoData, "Telegram_logo.png"))
                                    {
                                        Caption = "Telegram_logo.png"
                                    };
                                    var msg = bot.MakeRequestAsync(req).Result;
                                    uploadedPhotoId = msg.Photo.Last().FileId;
                                }
                            }
                            else
                            {
                                var req = new SendPhoto(update.Message.Chat.Id, new FileToSend(uploadedPhotoId))
                                {
                                    Caption = "Resending photo id=" + uploadedPhotoId
                                };
                                bot.MakeRequestAsync(req).Wait();
                            }
                            continue;
                        }
                        if (text == "/doc")
                        {
                            if (uploadedDocumentId == null)
                            {
                                var reqAction = new SendChatAction(update.Message.Chat.Id, "upload_document");
                                bot.MakeRequestAsync(reqAction).Wait();
                                System.Threading.Thread.Sleep(500);
                                using (var docData = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream("TelegramBotDemo-vNext.Telegram_Bot_API.htm"))
                                {
                                    var req = new SendDocument(update.Message.Chat.Id, new FileToSend(docData, "Telegram_Bot_API.htm"));
                                    var msg = bot.MakeRequestAsync(req).Result;
                                    uploadedDocumentId = msg.Document.FileId;
                                }
                            }
                            else
                            {
                                var req = new SendDocument(update.Message.Chat.Id, new FileToSend(uploadedDocumentId));
                                bot.MakeRequestAsync(req).Wait();
                            }
                            continue;
                        }
                        if (text == "/docutf8")
                        {
                            var reqAction = new SendChatAction(update.Message.Chat.Id, "upload_document");
                            bot.MakeRequestAsync(reqAction).Wait();
                            System.Threading.Thread.Sleep(500);
                            using (var docData = typeof(Program).GetTypeInfo().Assembly.GetManifestResourceStream("TelegramBotDemo-vNext.Пример_UTF8_filename.txt"))
                            {
                                var req = new SendDocument(update.Message.Chat.Id, new FileToSend(docData, "Пример_UTF8_filename.txt"));
                                var msg = bot.MakeRequestAsync(req).Result;
                                uploadedDocumentId = msg.Document.FileId;
                            }
                            continue;
                        }
                        if (text == "/help")
                        {
                            var keyb = new ReplyKeyboardMarkup()
                            {
                                Keyboard = new[] {
                                    new[] { new KeyboardButton("/photo"), new KeyboardButton("/doc"), new KeyboardButton("/docutf8") },
                                    new[] { new KeyboardButton("/contact") { RequestContact = true }, new KeyboardButton("/location") { RequestLocation = true } },
                                    new[] { new KeyboardButton("/help") }
                                },
                                OneTimeKeyboard = true,
                                ResizeKeyboard = true
                            };
                            var reqAction = new SendMessage(update.Message.Chat.Id, "Here is all my commands") { ReplyMarkup = keyb };
                            bot.MakeRequestAsync(reqAction).Wait();
                            continue;
                        }
                        if (update.Message.Text.Length % 2 == 0)
                        {
                            bot.MakeRequestAsync(new SendMessage(
                                update.Message.Chat.Id,
                                "You wrote *" + update.Message.Text.Length + " characters*")
                            {
                                ParseMode = SendMessage.ParseModeEnum.Markdown
                            }).Wait();
                        }
                        else
                        {
                            bot.MakeRequestAsync(new ForwardMessage(update.Message.Chat.Id, update.Message.Chat.Id, update.Message.MessageId)).Wait();
                        }
                    }
                }
            }
        }
    }
}
