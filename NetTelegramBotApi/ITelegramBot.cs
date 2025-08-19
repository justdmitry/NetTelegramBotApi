namespace NetTelegramBotApi
{
    public interface ITelegramBot
    {
        Task<TResponse> Execute<TResponse>(RequestBase<TResponse> request, CancellationToken cancellationToken = default);

        Update? DeserializeUpdate(string json);
    }
}
