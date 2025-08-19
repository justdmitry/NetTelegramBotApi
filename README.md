# NetTelegramBotApi

C# client library for building Telegram bots (https://core.telegram.org/bots/api).

Contains strongly-typed request and response classes, and transport class for sending requests and receiving results. Uses `System.Text.Json` only.


[![NuGet](https://img.shields.io/nuget/v/NetTelegramBotApi.svg)](https://www.nuget.org/packages/NetTelegramBotApi/)
![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4)
![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4)
![MIT License](https://img.shields.io/github/license/justdmitry/NetTelegramBotApi)

## Usage

```csharp
var bot = new TelegramBot(accessToken, new HttpClient());
var me = await bot.GetMe();
if (me != null)
{
   Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
}
```

See `TelegramBotDemo` project for more samples.

Use with `AddHttpClient<TelegramBot>(...)` in web projects, use `Polly` (or any other you like) to handle transient faults and improve the resilience.

## Extensibility

Just describe new request (or data) class:

```csharp
public class PinChatMessage() : RequestBase<bool>("pinChatMessage")
{
    public string? BusinessConnectionId { get; set; }

    public required IntegerOrString ChatId { get; set; }

    public required long MessageId { get; set; }

    public bool? DisableNotification { get; set; }
}
```

This works out-of-the-box:

* snake_case property naming (`BusinessConnectionId` -> `business_connection_id`);
* `DateTimeOffset` [de]serialization of unix-time fields;
* use `IntegerOrString` type for number-or-string fields (like `chat_id`);
* use `InputFile` or `InputFileOrString` types for requests with files (don't forget to pass `withFiles: true` to `RequestBase`, check [`SetWebhook`](./NetTelegramBotApi/Requests/SetWebhook.cs) for example);


## Installation

Use NuGet package [NetTelegramBotApi](https://www.nuget.org/packages/NetTelegramBotApi/).


## Dependencies

Only `System.Text.Json`.