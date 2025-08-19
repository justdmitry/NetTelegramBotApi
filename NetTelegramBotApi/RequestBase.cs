namespace NetTelegramBotApi
{
    using System.Diagnostics.CodeAnalysis;
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
            var namesToSkip = new HashSet<string>(5);

            var props = this.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(InputFile))
                {
                    var val = (InputFile?)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        var name = TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(prop.Name);
                        CreateAttachment(val.Value, name, mc);
                        namesToSkip.Add(name);
                    }
                }
                else if (prop.PropertyType == typeof(InputFileOrString))
                {
                    var val = (InputFileOrString?)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        var name = TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(prop.Name);
                        if (CreateAttachmentIfNeeded(val.Value, name, mc, out var newValue))
                        {
                            prop.SetValue(this, newValue);
                        }
                    }
                }
                else if (prop.PropertyType.IsClass)
                {
                    // Ideally, a recursion is needed here.
                    // But there are no such 'deep' objects in TG (yet), so I made a simple inner loop for now.
                    var val = prop.GetValue(this);
                    if (val != null)
                    {
                        var name = TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(prop.Name);
                        var innerProps = val.GetType().GetProperties();
                        foreach (var innerProp in innerProps.Where(x => x.PropertyType == typeof(InputFileOrString)))
                        {
                            var innerVal = (InputFileOrString?)innerProp.GetValue(val);
                            if (innerVal.HasValue)
                            {
                                var innerName = name + "_" + TelegramBot.JsonOptions.PropertyNamingPolicy!.ConvertName(innerProp.Name);
                                if (CreateAttachmentIfNeeded(innerVal.Value, innerName, mc, out var newValue))
                                {
                                    innerProp.SetValue(val, newValue);
                                }
                            }
                        }
                    }
                }
            }

            var json = JsonSerializer.Serialize(this, this.GetType(), options: TelegramBot.JsonOptions);
            var root = JsonNode.Parse(json)!.AsObject();

            foreach (var (key, value) in root.Where(x => x.Value != null && !namesToSkip.Contains(x.Key)))
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

        protected static void CreateAttachment(InputFile value, string propertyName, MultipartFormDataContent formContent)
        {
            // HACK, but utf-8 file names (issue #5) sent correctly now (in filename, not filename*),
            //   thanks to http://stackoverflow.com/questions/21928982/how-to-disable-base64-encoded-filenames-in-httpclient-multipartformdatacontent
            var contentDispositionValue = string.Format(
                "form-data; name={0}; filename=\"{1}\"",
                propertyName,
                string.Concat(System.Text.Encoding.UTF8.GetBytes(value.Name).Select(x => (char)x).Where(x => x != '"')));
            var fileContent = new StreamContent(value.Content);
            fileContent.Headers.Add("Content-Disposition", contentDispositionValue);
            formContent.Add(fileContent, propertyName);
        }

        protected static bool CreateAttachmentIfNeeded(InputFileOrString value, string propertyName, MultipartFormDataContent formContent, [NotNullWhen(true)] out InputFileOrString? newValue)
        {
            if (value.InputFile == null)
            {
                newValue = null;
                return false;
            }

            CreateAttachment(value.InputFile.Value, propertyName, formContent);

            newValue = new InputFileOrString("attach://" + propertyName);
            return true;
        }
    }
}
