namespace NetTelegramBotApi
{
    /// <summary>
    /// Implemented by Types, which require additional post-processing after receiving from server.
    /// </summary>
    public interface IPostProcessingRequired
    {
        void PostProcess(string accessToken);
    }
}
