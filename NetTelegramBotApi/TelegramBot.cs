using System;
using System.Threading.Tasks;
using NetTelegramBotApi.Types;
using Newtonsoft.Json;

namespace NetTelegramBotApi
{
    public class TelegramBot : TelegramBotBase
    {
        public TelegramBot(string accessToken)
            : base(accessToken)
        {
            // Nothing
        }

        public User GetMe()
        {
            return MakeRequest<User>("getMe");
        }

        public async Task<User> GetMeAsync()
        {
            return await MakeRequestAsync<User>("getMe").ConfigureAwait(false);
        }
    }
}
