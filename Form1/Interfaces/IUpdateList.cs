using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface IUpdateList
{
    public void UpdateList(List<JProperty> translatedList, Control textBox, int index);

    public void UpdateResxList(List<KeyValuePair<string, string>> translatedList,
        List<KeyValuePair<string, string>> resxList, Control textBox, int index);
    public void UpdateTranslation(JObject translatedStrings, List<JProperty> translatedList);
}

