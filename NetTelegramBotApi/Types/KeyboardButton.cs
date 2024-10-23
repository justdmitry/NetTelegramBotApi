namespace NetTelegramBotApi.Types
{
    public class KeyboardButton
    {
        public KeyboardButton(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Text of the button.
        /// If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed.
        /// Available in private chats only
        /// </summary>
        public bool RequestContact { get; set; }

        /// <summary>
        /// Optional. If True, the user's current location will be sent when the button is pressed.
        /// Available in private chats only
        /// </summary>
        public bool RequestLocation { get; set; }
    }
}
