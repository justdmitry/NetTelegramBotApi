namespace System
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    public static class StringExtensions
    {
        private static readonly char[] MarkdownV1Chars = ['\\', '_', '*', '`', '['];

        private static readonly char[] MarkdownV2Chars = ['\\', '_', '*', '[', ']', '(', ')', '~', '`', '>', '#', '+', '-', '=', '|', '{', '}', '.', '!'];

        [return: NotNullIfNotNull(nameof(value))]
        public static string EscapeMarkdown(this string value)
        {
            return Escape(value, MarkdownV1Chars);
        }

        [return: NotNullIfNotNull(nameof(value))]
        public static string EscapeMarkdownV2(this string value)
        {
            return Escape(value, MarkdownV2Chars);
        }

        [return: NotNullIfNotNull(nameof(source))]
        private static string Escape(string source, char[] characters)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return source;
            }

            if (source.IndexOfAny(characters) == -1)
            {
                return source;
            }

            var sb = new StringBuilder(source.Length + 100);
            foreach (var c in source)
            {
                if (characters.Contains(c))
                {
                    sb.Append('\\');
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
