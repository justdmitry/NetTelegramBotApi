namespace NetTelegramBotApi
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using NetTelegramBotApi.Types;
    using NetTelegramBotApi.Requests;
    using Xunit;

    public class InlineKeyboardButtonTest
    {
        /// <summary>
        /// Test for Issue #46
        /// </summary>
        [Fact]
        public async Task CallbackData_SerializedOk()
        {
            var keyb = new InlineKeyboardMarkup()
            {
                InlineKeyboard = new[] { new[] { new InlineKeyboardButton { Text = "test", CallbackData = "123" } } },
            };
            var reqAction = new SendMessage(123, "Hello") { ReplyMarkup = keyb };

            var submitText = await reqAction.CreateHttpContent().ReadAsStringAsync();

            var encoded = WebUtility.UrlEncode("{\"inline_keyboard\":[[{\"text\":\"test\",\"callback_data\":\"123\"}]]}");
            Assert.Equal($"chat_id=123&text=Hello&reply_markup={encoded}", submitText);
        }
    }
}
