# NetTelegramBotApi
C# client library for building Telegram bot (https://core.telegram.org/bots/api)

Contains strongly-types request and response classes, and transport class for sending requests and receiving results.

## Usage

    var bot = new TelegramBot(accessToken);
    var me = bot.MakeRequest(new GetMe());
    if (me != null)
    {
       Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
    }

See `TelegramBotDemo` project for more samples.

## Installation

Install as [nuget package](https://www.nuget.org/packages/NetTelegramBotApi):

    Install-Package NetTelegramBotApi

Dependencies: `System.Web`, [`Newtonsoft.Json`](https://www.nuget.org/packages/Newtonsoft.Json/)

## Version history

### 2.0.50626 - Requests hierarchy

Refactored to new request model - base `RequestBase` class and one (and one async) `MakeRequest` method.

Major version increased to "2", patch version set to current date.

### 1.0.1 - Initial release

Response class hierarchy (`Types`), first requests. It works!
