using System.Text.Json;
using System.Text.RegularExpressions;

namespace NetTelegramBotApi.Util
{
    /// <summary>
    /// Thanks to http://stackoverflow.com/questions/18051395/custom-json-net-contract-resolver-for-lowercase-underscore-to-camelcase
    /// </summary>
    public class JsonLowerCaseUnderscoreNamingPolicy : JsonNamingPolicy
    {
        private Regex regex = new Regex("(?!(^[A-Z]))([A-Z])");

        public override string ConvertName(string propertyName)
        {
            return regex.Replace(propertyName, "_$2").ToLower();
        }
    }
}
