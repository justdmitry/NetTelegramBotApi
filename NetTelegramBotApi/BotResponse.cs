using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi
{
    public class BotResponse<T>
    {
        public bool Ok { get; set; }

        public string Description { get; set; }

        public T Result { get; set; }

        public long? ErrorCode { get; set; }

        public ResponseParameters Parameters { get; set; }
    }
}
