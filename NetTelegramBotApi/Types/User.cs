using System;
using Newtonsoft.Json;

namespace NetTelegramBotApi.Types
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
    }
}
