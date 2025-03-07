using GTranslate.Translators;
using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface ITranslate
{
    public Task<JObject> TranslateJsonYa(YandexTranslator client, JObject sourceStrings, string toLanguage);
}


