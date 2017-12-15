namespace System
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        private static readonly Regex WrongChars = new Regex(@"([\*_`\[\]\(\)])");

        public static string MarkdownEncode(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return WrongChars.Replace(value, @"\$1");
        }
    }
}
