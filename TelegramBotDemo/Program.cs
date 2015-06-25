using System;
using System.Configuration;
using System.Threading.Tasks;
using NetTelegramBotApi;

namespace TelegramBotDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accessToken = ConfigurationManager.AppSettings["AccessToken"];

            Console.WriteLine("Starting your bot...");
            Console.WriteLine();

            var bot = new TelegramBot(accessToken);

            var me = bot.GetMe();
            if (me != null)
            {
                Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
            }
            var updates = bot.GetUpdates(0);
            if (updates != null)
            {
                foreach (var update in updates)
                {
                    if (update.Message != null) {
                        Console.WriteLine("Msg from {0} {1} ({2}): {3}",
                            update.Message.From.FirstName,
                            update.Message.From.LastName,
                            update.Message.From.Username,
                            update.Message.Text
                            );
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Done. Press ENTER to quit");
            Console.ReadLine();
        }
    }
}
