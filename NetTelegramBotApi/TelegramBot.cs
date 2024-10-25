namespace NetTelegramBotApi
{
    using NetTelegramBotApi.Util;

    public class TelegramBot : ITelegramBot
    {
        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new UnixDateTimeConverter(),
                new IntegerOrStringConverter(),
                new InputFileOrStringConverter(),
            },
        };

        private readonly string accessToken;
        private readonly HttpClient httpClient;

        public TelegramBot(string accessToken, HttpClient httpClient)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(accessToken);
            ArgumentNullException.ThrowIfNull(httpClient);

            this.accessToken = accessToken;
            this.httpClient = httpClient;
        }

        /// <inheritdoc/>
        /// <exception cref="RequestFailedException">When non-Ok response returned from server.</exception>
        public async Task<TResponse> Execute<TResponse>(RequestBase<TResponse> request, CancellationToken cancellationToken = default)
        {
            (var methodName, var content) = request.CreateHttpContent();
            using (content)
            {
                var uri = new Uri($"https://api.telegram.org/bot{this.accessToken}/{methodName}");
                using var response = await this.httpClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);

                if ((int)response.StatusCode >= 500)
                {
                    // It's server fault. Throw default exception.
                    response.EnsureSuccessStatusCode();
                }

                var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                var result = DeserializeMessage<ResponseBase<TResponse>>(responseText);
                if (!response.IsSuccessStatusCode || result == null || !result.Ok || result.Result is null)
                {
                    var exceptionMessage = $"Request failed ({response.StatusCode}): {responseText}";
                    throw new RequestFailedException(exceptionMessage)
                    {
                        StatusCode = response.StatusCode,
                        ResponseBody = responseText,
                        Description = result?.Description,
                        ErrorCode = result?.ErrorCode,
                        Parameters = result?.Parameters,
                    };
                }

                return result.Result;
            }
        }

        /// <inheritdoc/>
        public Update? DeserializeUpdate(string json)
        {
            return DeserializeMessage<Update>(json);
        }

        protected static TResult? DeserializeMessage<TResult>(string json)
            where TResult : class
        {
            return JsonSerializer.Deserialize<TResult>(json, JsonOptions);
        }
    }
}
