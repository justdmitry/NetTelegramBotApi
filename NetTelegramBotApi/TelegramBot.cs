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

        public Update[] GetUpdates(long offset, int limit = 100, int timeout = 0)
        {
            string query = string.Format("offset={0}&limit={1}&timeout={2}", offset, limit, timeout);
            return MakeRequest<Update[]>("getUpdates", query);
        }

        public async Task<Update[]> GetUpdatesAsync(long offset, int limit = 100, int timeout = 0)
        {
            string query = string.Format("offset={0}&limit={1}&timeout={2}", offset, limit, timeout);
            return await MakeRequestAsync<Update[]>("getUpdates", query);
        }
    }
}
