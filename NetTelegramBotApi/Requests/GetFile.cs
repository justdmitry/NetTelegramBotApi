using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get basic info about a file and prepare it for downloading.
    /// For the moment, bots can download files of up to 20MB in size.
    /// On success, a <see cref="File"/> object is returned.
    /// The file can then be downloaded via the link https://api.telegram.org/file/bot<token>/<file_path>, where <file_path> is taken from the response.
    /// It is guaranteed that the link will be valid for at least 1 hour.
    /// When the link expires, a new one can be requested by calling getFile again.
    /// </summary>
    public class GetFile : RequestBase<File>
    {
        public GetFile(string fileId)
            : base("getFile")
        {
            this.FileId = fileId;
        }

        /// <summary>
        /// File identifier to get info about
        /// </summary>
        public string FileId { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("file_id", FileId),
            };
            return new FormUrlEncodedContent(values);
        }
    }
}
