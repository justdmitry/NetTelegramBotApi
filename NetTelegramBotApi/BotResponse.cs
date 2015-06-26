using System;

namespace NetTelegramBotApi
{
    public class BotResponse<T>
    {
        public bool Ok { get; set; }

        public string Description { get; set; }

        public T Result { get; set; }
    }
}
