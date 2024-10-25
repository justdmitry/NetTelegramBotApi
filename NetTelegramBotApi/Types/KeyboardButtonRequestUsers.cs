namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object defines the criteria used to request suitable users.
    /// Information about the selected users will be shared with the bot when the corresponding button is pressed.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#keyboardbuttonrequestusers"/>
    /// </remarks>
    public class KeyboardButtonRequestUsers
    {
        public required int RequestId { get; set; }

        public bool? UserIsBot { get; set; }

        public bool? UserIsPremium { get; set; }

        public byte? MaxQuantity { get; set; }

        public bool? RequestName { get; set; }

        public bool? RequestUsername { get; set; }

        public bool? RequestPhoto { get; set; }
    }
}
