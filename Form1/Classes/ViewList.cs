using WinFormsApp2.Interfaces;
using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Classes;

public class ViewList : IViewList
{
    //Метод рекурсивно "забирает" вложенные ключ:значения и помещает в список для дальнейшей работы с ними
    public List<JProperty> ValueViewer(JObject fileText, List<JProperty> translatedList)
    {
        foreach (var property in fileText.Properties())
        {
            if (property.Value.Type == JTokenType.Object)
            {
                ValueViewer((JObject)property.Value, translatedList);
            }
            else if (property.Value.Type == JTokenType.Array)
            {
                foreach (var item in (JArray)property.Value)
                {
                    if (item.Type == JTokenType.Object)
                    {
                        ValueViewer((JObject)property.Value, translatedList);
                    }
                }
            }
            else
            {
                translatedList.Add(property); 
            }
        }
            
        return translatedList;
    }
}
