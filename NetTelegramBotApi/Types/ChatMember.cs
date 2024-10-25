namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains information about one member of a chat. Currently, the following 6 types of chat members are supported.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmember"/>
    /// </remarks>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "status")]
    [JsonDerivedType(typeof(ChatMemberOwner), typeDiscriminator: "owner")]
    [JsonDerivedType(typeof(ChatMemberAdministrator), typeDiscriminator: "administrator")]
    [JsonDerivedType(typeof(ChatMemberMember), typeDiscriminator: "member")]
    [JsonDerivedType(typeof(ChatMemberRestricted), typeDiscriminator: "restricted")]
    [JsonDerivedType(typeof(ChatMemberLeft), typeDiscriminator: "left")]
    [JsonDerivedType(typeof(ChatMemberBanned), typeDiscriminator: "kicked")]
    public abstract class ChatMember
    {
        // Nothing.
    }
}
