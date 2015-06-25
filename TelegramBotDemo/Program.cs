using System;
using System.Configuration;
using System.Threading.Tasks;
using NetTelegramBotApi;

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

            var me = bot.GetMe();
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
                var updates = bot.GetUpdates(offset);
                if (updates != null)
                {
                    foreach (var update in updates)
                    {
                        offset = update.UpdateId + 1;
                        if (update.Message != null)
                        {
                            Console.WriteLine("Msg from {0} {1} ({2}): {3}",
                                update.Message.From.FirstName,
                                update.Message.From.LastName,
                                update.Message.From.Username,
                                update.Message.Text
                                );
                        }
                    }
                }
            }
        }
    }
}
