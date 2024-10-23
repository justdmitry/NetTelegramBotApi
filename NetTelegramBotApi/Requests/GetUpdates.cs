using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to receive incoming updates using long polling (wiki). An Array of Update objects is returned.
    /// </summary>
    public class GetUpdates : RequestBase<Update[]>
    {
        public GetUpdates()
            : base("getUpdates")
        {
            // Nothing
        }

        /// <summary>
        /// Identifier of the first update to be returned.
        /// Must be greater by one than the highest among the identifiers of previously received updates.
        /// By default, updates starting with the earliest unconfirmed update are returned.
        /// An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Limits the number of updates to be retrieved. Values between 1—100 are accepted. Defaults to 100.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling.
        /// </summary>
        public int? Timeout { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (!Offset.HasValue && !Limit.HasValue && !Timeout.HasValue)
            {
                return null;
            }

            var dic = new Dictionary<string, string>();

            if (Offset.HasValue)
            {
                dic.Add("offset", Offset.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Limit.HasValue)
            {
                dic.Add("limit", Limit.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Timeout.HasValue)
            {
                dic.Add("timeout", Timeout.Value.ToString(CultureInfo.InvariantCulture));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
