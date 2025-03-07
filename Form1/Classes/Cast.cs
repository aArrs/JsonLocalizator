using Newtonsoft.Json;
using WinFormsApp2.Interfaces;
using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Classes;

public class Cast : ICast
{
    public JObject GetJObject(string json)
    {
        var parsedValue = new JObject();
        try
        {
            parsedValue = JObject.Parse(json);
        }
        catch(JsonReaderException jre)
        {
            MessageBox.Show("Файл неисправен");
        }

        return parsedValue;
    }
}