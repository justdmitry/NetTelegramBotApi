namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the birthdate of a user.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#birthdate"/>
    /// </remarks>
    public class Birthdate
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int? Year { get; set; }
    }
}
