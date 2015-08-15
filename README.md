# NetTelegramBotApi
C# client library for building Telegram bot (https://core.telegram.org/bots/api)

Contains strongly-types request and response classes, and transport class for sending requests and receiving results.

## Usage

    var bot = new TelegramBot(accessToken);
    var me = await bot.MakeRequestAsync(new GetMe());
    if (me != null)
    {
       Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
    }

See `TelegramBotDemo` project for more samples.

## Installation

Install as [nuget package](https://www.nuget.org/packages/NetTelegramBotApi):

    Install-Package NetTelegramBotApi

Dependencies: [`Newtonsoft.Json`](https://www.nuget.org/packages/Newtonsoft.Json/)

## Version history

### 3.5.50816 - API changes

* Changes in Telegram API defined as [July 2015](https://core.telegram.org/bots/api-changelog#july-2015) implemented (issue #7):
 * The `Caption` field has been **removed** from the `Video` object and added to the `Message` object instead.
 * `Caption` and `Duration` optional fields have been added to the `SendVideo` request.
 * `UserId` type in the `Contact` object **changed** to Long (was String - typo in API docs)
* `Performer` and `Title` optional fields have been added to `Audio` object
* `Duration`, `Performer` and `Title` optional fields have been added to the `SendAudio` request
* Object `Voice` added (to `Message` class)
* `SendVoice` request added

### 3.4.50815 - Webhooks support, bugfixes

Improvements for working via webhooks:

* `SetWebhook` request added (Issue #3)
* `DeserializeUpdate` method added to convert webhook POST json value to `Update` object

Fixed issue #6 with sending files with non-latin characters in name.

### 3.3.50701 - DateTimeOffset instead of long

`Message` properties `Date` and `ForwardDate` are now DateTimeOffset (converted to local time).

### 3.2.50628 - With sending files

Methods for sending files (`SendPhoto`, `SendVideo`, etc) implemented.

### 3.1.50627 - Using HttpClient

Switched to HttpClient (instead of HttpRequest):

* no more `System.Web` dependency;
* `MakeRequest` method is now async only, use `.Result` or `.Wait()` for synchronous calls

### 2.1.50626 - Requests hierarchy

Refactored to new request model - base `RequestBase` class and one (and one async) `MakeRequest` method.

Major version increased to "2", patch version set to current date.

### 1.0.1 - Initial release

Response class hierarchy (`Types`), first requests. It works!
