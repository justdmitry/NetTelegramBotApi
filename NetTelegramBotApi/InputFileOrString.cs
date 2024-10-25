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

        public static implicit operator InputFileOrString(InputFile value) => new(value);

        public static implicit operator InputFileOrString(Uri value) => new(value.ToString());

        public static implicit operator InputFileOrString(string value) => new(value);
    }
}
