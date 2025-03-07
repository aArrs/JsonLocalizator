using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

    public interface IViewList
{
    List<JProperty> ValueViewer(JObject fileText, List<JProperty> translatedList);
}



