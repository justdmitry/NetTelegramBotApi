namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a venue.
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Venue location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Optional. Foursquare identifier of the venue
        /// </summary>
        public string foursquareId { get; set; }
    }
}
