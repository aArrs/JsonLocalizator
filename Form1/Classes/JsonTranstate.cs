using WinFormsApp2.Interfaces;
using GTranslate.Translators;
using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Classes;

    public class JsonTranslate : ITranslate
    {
        //рекурсивный перевод каждого вложенного значениия с использованием GTranslate
        public async Task<JObject> TranslateJsonYa(YandexTranslator client, JObject sourceStrings, string toLanguage)
        {
            if (sourceStrings == null)
            {
                throw new Exception("Выберите файл.");
            }
            if (toLanguage == null)
            {
                throw new Exception("Выберите язык.");
            }
            foreach (var property in sourceStrings.Properties())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    await TranslateJsonYa(client, (JObject)property.Value, toLanguage);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var item in (JArray)property.Value)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            await TranslateJsonYa(client, (JObject)item, toLanguage);
                        }
                    }
                }
                else
                {
                    property.Value =
                        (await client.TranslateAsync(property.Value.ToString(), toLanguage, (await client.DetectLanguageAsync(property.Value.ToString())).ISO6391))
                        .Translation;
                }
            }
            return sourceStrings;
        }
    }
