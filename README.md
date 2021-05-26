# NetTelegramBotApi
C# client library for building Telegram bot (https://core.telegram.org/bots/api)

Contains strongly-types request and response classes, and transport class for sending requests and receiving results.

[![NuGet](https://img.shields.io/nuget/v/NetTelegramBotApi.svg?maxAge=86400&style=flat)](https://www.nuget.org/packages/NetTelegramBotApi/)

## Usage

    var bot = new TelegramBot(accessToken);
    var me = await bot.MakeRequestAsync(new GetMe());
    if (me != null)
    {
       Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
    }

See `TelegramBotDemo` project for more samples.

## Version history

### 5.0.0 - net5.0

* Target framworks changed: `net5.0` only
* `System.Text.Json` replaces `Newtosoft.Json`

### 4.0.0 - Big update

Telegram API updated up to [v2.3 (November 21, 2016)](https://core.telegram.org/bots/api-changelog#november-21-2016). Message editing, games - everything should work **except inline mode** (see below).

**Breaking changes** (compared to 3.8.1):

1. `MakeRequestAsync` now throws `BotRequestException` if non-Ok response is received from server.
2. Typo fixed on `Contact` type: `PhoneNumber` was `PhoneNumbet`
3. `ReplyKeyboardHide` renamed to `ReplyKeyboardRemove` (when it had been renamed in API???)
4. Breaking changes in API 2.3:
    * Parameter `EditMessage` replaced with `DisableEditMessage` in `SetGameScore`
    * In `ReplyKeyboardRemove`: `HideKeyboard` renamed to `RemoveKeyboard`

**Inline mode**

[Inline mode](https://core.telegram.org/bots/api#inline-mode) needs a lot of new classes to be created. Please make PR if you wish to help.

### 3.8.1 - .NET Core RTM, netstandard1.3

* Upgraded to .NET Core 1.0.0 and `netstandard1.3`

### 3.7.50926 - API updates, proxy support

* Changes in Telegram API defined as [August 29, 2015](https://core.telegram.org/bots/api-changelog#august-29-2015) implemented (issue #19):
 * Added support for uploading certificates in `SetWebhook`
* Changes in Telegram API defined as [September 7, 2015](https://core.telegram.org/bots/api-changelog#september-7-2015) implemented (issue #20):
 * Added `ParseMode` field to `SendMessage` request for simple markdown markup (see [FAQ](https://core.telegram.org/bots/api#using-markdown) for details)
* Changes in Telegram API defined as [September 18, 2015](https://core.telegram.org/bots/api-changelog#september-18-2015) implemented (issue #21):
 * Bots can now download files and media sent by users, use `GetFile` request and `File` object (run demo project and send him a picture!)
* Proxy support added:
 * Use `WebProxy` property when creating bot (see [issue #22](https://github.com/justdmitry/NetTelegramBotApi/pull/22) for sample)

### 3.6.50925 - Upgrade to vNext

Project converted to Visual Studio 2015 and new project type (`xproj`).

NuGet package now targets multiple runtimes: `net45`, `dnx45`, `dnx50` and `dnxcore50`.

New demo console app added (`TelegramBotDemo-vNext`) for testing under `dnx451` runtime. Old demo app ('classic' console project) also available, but **Attention! Now it grabs package from nuget!** (because old-style .csproj can't reference new .xproj assemblies directly).

### 3.5.50818 - API changes 'August 15, 2015'

Changes in Telegram API defined as [August 15, 2015](https://core.telegram.org/bots/api-changelog#august-15-2015) implemented (issue #13).

All real changes were already implemented in `3.5.50816`, only some documenation/comments are updated in this version.


### 3.5.50816 - API changes

* Changes in Telegram API defined as [July 2015](https://core.telegram.org/bots/api-changelog#july-2015) implemented (issue #7):
 * The `Caption` field has been **removed** from the `Video` object and added to the `Message` object instead.
 * `Caption` and `Duration` optional fields have been added to the `SendVideo` request.
 * `UserId` type in the `Contact` object **changed** to Long (was String - typo in API docs)
* Changes, not [yet?] announced in Telegram API changlog:
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
