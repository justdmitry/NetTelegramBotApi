namespace NetTelegramBotApi
{
    public readonly struct IntegerOrString
    {
        public IntegerOrString(string value)
        {
            this.Value = value;
        }

        public IntegerOrString(long value)
        {
            this.Value = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public string Value { get; }

        public static implicit operator IntegerOrString(string value) => new(value);

        public static implicit operator IntegerOrString(long value) => new(value);

        public override readonly string ToString()
        {
            return this.Value;
        }
    }
}
