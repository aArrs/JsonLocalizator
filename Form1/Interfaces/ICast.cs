using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface ICast
{
    JObject GetJObject(string json);
}

