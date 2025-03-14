using Newtonsoft.Json.Linq;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class ListUpdater : IUpdateList
{
    //Сохранение введенных вручную изменений в переводе
    public void UpdateList(List<JProperty> translatedList, Control textBox, int index)
    {
        if (translatedList == null)
        {
            throw new Exception("Переведите файл");
        }
        translatedList[index].Value = textBox.Text;
    }
    public void UpdateResxList(List<KeyValuePair<string, string>> translatedList, List<KeyValuePair<string, string>> resxList,  Control textBox, int index)
    {
        if (translatedList == null)
        {
            throw new Exception("Переведите файл");
        }
        resxList.Add(new KeyValuePair<string, string>(translatedList[index].Key, textBox.Text));
    }

    //Рекурсивная сборка переведенных значений в исходную json структуру
    public void UpdateTranslation(JObject translatedStrings, List<JProperty> translatedList)
    {
        foreach (var property in translatedStrings.Properties())
        {
            if (translatedStrings == null && translatedList == null)
            {
                throw new Exception("Переведите файл");
            }
            if (property.Value.Type == JTokenType.Object)
            {
                UpdateTranslation((JObject)property.Value, translatedList);
            }
            else if (property.Value.Type == JTokenType.Array)
            {
                foreach (var item in (JArray)property.Value)
                {
                    if (item.Type == JTokenType.Object)
                    {
                        UpdateTranslation((JObject)property.Value, translatedList);
                    }
                }
            }
            else
            {
                property.Value = (translatedList.FirstOrDefault(p => p.Name == property.Name)).Value;
            }
        }
    }
}