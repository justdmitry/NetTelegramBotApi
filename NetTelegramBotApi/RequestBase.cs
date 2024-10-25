namespace NetTelegramBotApi
{
    using System.Net.Http.Json;
    using System.Text.Json.Nodes;

    public abstract class RequestBase<TResponse>(string methodName, bool withFiles = false)
    {
        public virtual (string Method, HttpContent Content) CreateHttpContent()
        {
            if (!withFiles)
            {
                return (methodName, JsonContent.Create(this, this.GetType(), options: TelegramBot.JsonOptions));
            }

            var mc = new MultipartFormDataContent();

            var json = JsonSerializer.Serialize(this, this.GetType(), options: TelegramBot.JsonOptions);
            var root = JsonNode.Parse(json)!.AsObject();

            var props = this.GetType().GetProperties();

            foreach (var prop in props.Where(x => x.PropertyType == typeof(InputFile)))
            {
                var name = TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(prop.Name);
                var val = (InputFile?)prop.GetValue(this);
                if (val.HasValue)
                {
                    // HACK, but utf-8 file names (issue #5) sent correctly now (in filename, not filename*),
                    //   thanks to http://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
                    var contentDispositionValue = string.Format(
                        "form-data; name={0}; filename=\"{1}\"",
                        name,
                        string.Concat(System.Text.Encoding.UTF8.GetBytes(val.Value.Name).Select(x => (char)x).Where(x => x != '"')));
                    var fileContent = new StreamContent(val.Value.Content);
                    fileContent.Headers.Add("Content-Disposition", contentDispositionValue);
                    mc.Add(fileContent, name);
                    root.Remove(name);
                }
            }

            foreach (var prop in props.Where(x => x.PropertyType == typeof(InputFileOrString)))
            {
                var name = TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(prop.Name);
                var val = (InputFileOrString?)prop.GetValue(this);
                if (val.HasValue && val.Value.InputFile.HasValue)
                {
                    // HACK, but utf-8 file names (issue #5) sent correctly now (in filename, not filename*),
                    //   thanks to http://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
                    var contentDispositionValue = string.Format(
                        "form-data; name={0}; filename=\"{1}\"",
                        name,
                        string.Concat(System.Text.Encoding.UTF8.GetBytes(val.Value.InputFile.Value.Name).Select(x => (char)x).Where(x => x != '"')));
                    var fileContent = new StreamContent(val.Value.InputFile.Value.Content);
                    fileContent.Headers.Add("Content-Disposition", contentDispositionValue);
                    mc.Add(fileContent, name);
                    root.Remove(name);
                }
            }

            foreach (var node in root)
            {
                if (node.Value != null)
                {
                    switch (node.Value.GetValueKind())
                    {
                        case JsonValueKind.Object:
                        case JsonValueKind.Array:
                            mc.Add(new StringContent(node.Value.ToJsonString()), node.Key);
                            break;

                        case JsonValueKind.String:
                        case JsonValueKind.False:
                        case JsonValueKind.True:
                        case JsonValueKind.Number:
                            var sv = node.Value.GetValue<object>()?.ToString();
                            if (sv != null)
                            {
                                mc.Add(new StringContent(sv), node.Key);
                            }

                            break;
                    }
                }
            }

            return (methodName, mc);
        }
    }
}
