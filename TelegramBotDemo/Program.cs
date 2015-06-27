using System;
using System.Configuration;
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
                        Console.WriteLine(
                            "Msg from {0} {1} ({2}): {3}",
                            update.Message.From.FirstName,
                            update.Message.From.LastName,
                            update.Message.From.Username,
                            update.Message.Text);
                        if (!string.IsNullOrEmpty(update.Message.Text))
                        {
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
}
