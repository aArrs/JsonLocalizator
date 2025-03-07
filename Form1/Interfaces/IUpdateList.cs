using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface IUpdateList
{
    public void UpdateList(List<JProperty> translatedList, Control textBox, int index);
    public void UpdateTranslation(JObject translatedStrings, List<JProperty> translatedList);
}

