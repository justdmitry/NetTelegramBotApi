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

            Console.WriteLine();
            Console.WriteLine("Done. Press ENTER to quit");
            Console.ReadLine();
        }
    }
}
