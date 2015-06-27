using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;

namespace TelegramBotDemo
{
    public class Program
    {
        private static bool stopMe = false;

        public static void Main(string[] args)
        {
            var accessToken = ConfigurationManager.AppSettings["AccessToken"];

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
                Console.WriteLine("GetMe() FAILED. Do you forget to add your AccessToken to App.config?");
                Console.WriteLine("(Press ENTER to quit)");
            }
            Console.WriteLine("{0} (@{1}) connected!", me.FirstName, me.Username);

            Console.WriteLine();
            Console.WriteLine("Find @{0} in Telegram and send him a message - it will be displayed here", me.Username);
            Console.WriteLine("(Press ENTER to stop listening and quit)");
            Console.WriteLine();

            string uploadedPhotoId = null;
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
                        Console.WriteLine(
                            "Msg from {0} {1} ({2}): {3}",
                            from.FirstName,
                            from.LastName,
                            from.Username,
                            text);

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
                                using (var photoData = Assembly.GetExecutingAssembly().GetManifestResourceStream("TelegramBotDemo.t_logo.png"))
                                {
                                    var req = new SendPhoto(update.Message.Chat.Id, photoData, "Telegram_logo.png")
                                    {
                                        Caption = "Telegram_logo.png"
                                    };
                                    var msg = bot.MakeRequestAsync(req).Result;
                                    uploadedPhotoId = msg.Photo.Last().FileId;
                                }
                            }
                            else
                            {
                                var req = new SendPhoto(update.Message.Chat.Id, uploadedPhotoId)
                                {
                                    Caption = "Resending photo id=" + uploadedPhotoId
                                };
                                bot.MakeRequestAsync(req).Wait();
                            }
                            continue;
                        }
                        if (update.Message.Text.Length % 2 == 0)
                        {
                            bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "You wrote " + update.Message.Text.Length + " characters")).Wait();
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
