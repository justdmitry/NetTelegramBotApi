using System;

namespace NetTelegramBotApi.Types
{
    public enum ChatMemberStatus : byte
    {
        Unknown,
        Creator,
        Administrator,
        Member,
        Left,
        Kicked
    }
}
