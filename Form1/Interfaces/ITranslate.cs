using GTranslate.Translators;
using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface ITranslate
{
    public Task<JObject> TranslateJsonYa(YandexTranslator client, JObject sourceStrings, string toLanguage);
    public Task<List<KeyValuePair<string, string>>> TranslateResxYa(YandexTranslator client, List<KeyValuePair<string, string>> sourceList, string toLanguage);
}


