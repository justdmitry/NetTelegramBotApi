namespace NetTelegramBotApi.Demo
{
    using System.Net.Http;
    using Microsoft.Extensions.Configuration;

    public class DemoBot(IConfiguration configuration, HttpClient httpClient)
        : TelegramBot(configuration["BotToken"], httpClient)
    {
        // Nothing
    }
}
