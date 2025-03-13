using Newtonsoft.Json.Linq;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;

namespace Tests;

    [TestClass]
    public class ViewListTest : ViewList
    {
        IViewList _viewList = new ViewList();
        
        [TestMethod]
        public void ViewListResultTest()
        {
            JObject protocol = new JObject()
            {
                ["folder-inbox"]= "Папки входящих",
                ["folder-outbox"]= "Папки исходящих",
                ["folder-card"]= "Настройка папки",
                ["management-card"]= "Настройка конфигурации"
            };
            
            JObject testFile = new JObject()
            {
                ["services"] = protocol,
            };
            
            List<JProperty> testTranslatedList = new List<JProperty>();
            
            List<JProperty> checkList = new List<JProperty>()
            {
                new JProperty("folder-inbox", "Папки входящих"),
                new JProperty("folder-outbox", "Папки исходящих"),
                new JProperty("folder-card", "Настройка папки"),
                new JProperty("management-card", "Настройка конфигурации"),
            };
            
            _viewList.ValueViewer(testFile, testTranslatedList);

            CollectionAssert.AreEqual(testTranslatedList, checkList);
        }
    }
