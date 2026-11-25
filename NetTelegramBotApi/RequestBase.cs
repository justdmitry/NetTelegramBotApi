namespace NetTelegramBotApi
{
    using System.Net.Http.Json;
    using System.Text.Json.Nodes;

    public abstract class RequestBase<TResponse>(string methodName)
    {
        public static void CreateAttachment(MultipartFormDataContent multipartFormDataContent, InputFile value, string propertyName)
        {
            ArgumentException.ThrowIfNullOrEmpty(propertyName);

            // HACK, but utf-8 file names (issue #5) sent correctly now (in filename, not filename*),
            //   thanks to http://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
            var contentDispositionValue = string.Format(
                "form-data; name={0}; filename=\"{1}\"",
                propertyName,
                string.Concat(System.Text.Encoding.UTF8.GetBytes(value.Name).Select(x => (char)x).Where(x => x != '"')));

            var fileContent = new StreamContent(value.Content);
            fileContent.Headers.Add("Content-Disposition", contentDispositionValue);

            multipartFormDataContent.Add(fileContent, propertyName);
        }

        public static InputFileOrString CreateAttachment(MultipartFormDataContent multipartFormDataContent, InputFileOrString value, string? propertyName = null)
        {
            if (value.InputFile == null)
            {
                return value;
            }

            propertyName ??= "file" + Random.Shared.Next();
            CreateAttachment(multipartFormDataContent, value.InputFile.Value, propertyName);
            return "attach://" + propertyName;
        }

        public virtual (string Method, HttpContent Content) CreateHttpContent()
        {
            if (!HaveFiles())
            {
                return (methodName, JsonContent.Create(this, this.GetType(), options: TelegramBot.JsonOptions));
            }

            var mc = new MultipartFormDataContent();

            CreateAttachments(mc);

            var json = JsonSerializer.Serialize(this, this.GetType(), options: TelegramBot.JsonOptions);
            var root = JsonNode.Parse(json)!.AsObject();

            foreach (var (key, value) in root.Where(x => x.Value != null))
            {
                switch (value!.GetValueKind())
                {
                    case JsonValueKind.Object:
                    case JsonValueKind.Array:
                        mc.Add(new StringContent(value.ToJsonString()), key);
                        break;

                    case JsonValueKind.String:
                    case JsonValueKind.False:
                    case JsonValueKind.True:
                    case JsonValueKind.Number:
                        var sv = value.GetValue<object>()?.ToString();
                        if (sv != null)
                        {
                            mc.Add(new StringContent(sv), key);
                        }

                        break;
                }
            }

            return (methodName, mc);
        }

        protected virtual bool HaveFiles()
        {
            return false;
        }

        protected virtual void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            // Nothing. Used in derived classes.
        }
    }
}
