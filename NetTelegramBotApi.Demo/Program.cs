using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetTelegramBotApi;
using NetTelegramBotApi.Demo;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHttpClient<ITelegramBot, DemoBot>();
builder.Services.AddHostedService<BotServiceHost>();

var app = builder.Build();
await app.RunAsync();
