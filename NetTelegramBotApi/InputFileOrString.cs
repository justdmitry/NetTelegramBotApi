namespace NetTelegramBotApi
{
    public readonly struct InputFileOrString
    {
        public InputFileOrString(InputFile value)
        {
            ArgumentNullException.ThrowIfNull(value);
            this.InputFile = value;
        }

        public InputFileOrString(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            this.String = value;
        }

        public readonly InputFile? InputFile { get; }

        public readonly string? String { get; }

        public static implicit operator InputFileOrString(InputFile value)
        {
            ArgumentNullException.ThrowIfNull(value);
            return new(value);
        }

        public static implicit operator InputFileOrString(FileInfo fileInfo) => new((InputFile)fileInfo);

        public static implicit operator InputFileOrString((Stream Content, string FileName) fileData) => new((InputFile)fileData);

        public static implicit operator InputFileOrString(Uri value)
        {
            ArgumentNullException.ThrowIfNull(value);
            return new(value.ToString());
        }

        public static implicit operator InputFileOrString(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return new(value);
        }
    }
}
