using System.Threading.Tasks;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi
{
    public interface ITelegramBot
    {
        Task<T> MakeRequestAsync<T>(RequestBase<T> request);

        Update DeserializeUpdate(string json);
    }
}
