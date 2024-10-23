using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get a list of profile pictures for a user. Returns a UserProfilePhotos object.
    /// </summary>
    public class GetUserProfilePhotos : RequestBase<UserProfilePhotos>
    {
        public GetUserProfilePhotos(long userId)
            : base("getUserProfilePhotos")
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Sequential number of the first photo to be returned. By default, all photos are returned.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.
        /// </summary>
        public int? Limit { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("user_id", UserId.ToString(CultureInfo.InvariantCulture));
            if (Offset.HasValue)
            {
                dic.Add("offset", Offset.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Limit.HasValue)
            {
                dic.Add("limit", Limit.Value.ToString(CultureInfo.InvariantCulture));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
