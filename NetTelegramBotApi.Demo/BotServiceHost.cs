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
                        await ProcessMessage(msg);
                    }
                }
            }
        }

        protected async Task ProcessMessage(Message msg)
        {
            logger.LogInformation("New msg received");
        }
    }
}
