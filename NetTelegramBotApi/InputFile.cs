namespace NetTelegramBotApi
{
    public readonly struct InputFile(Stream content, string name)
    {
        public readonly Stream Content { get; } = content;

        public readonly string Name { get; } = name;

        public static implicit operator InputFile(FileInfo fileInfo)
        {
            ArgumentNullException.ThrowIfNull(fileInfo);

            return new(fileInfo.OpenRead(), fileInfo.Name);
        }

        public static implicit operator InputFile((Stream Content, string FileName) fileData)
        {
            ArgumentNullException.ThrowIfNull(fileData.Content);
            ArgumentException.ThrowIfNullOrWhiteSpace(fileData.FileName);

            return new(fileData.Content, fileData.FileName);
        }
    }
}
