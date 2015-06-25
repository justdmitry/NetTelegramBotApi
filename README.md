# NetTelegramBotApi
C# client library for building Telegram bot (https://core.telegram.org/bots/api)

Contains data types and transport class for sending requests and receiving results.

Usage:

    var bot = new TelegramBot(accessToken);
    var me = bot.GetMe();
    if (me != null)
    {
       Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
    }
