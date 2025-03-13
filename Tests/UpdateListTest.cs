using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;

namespace Tests;
[TestClass]
public class UpdateListTest : ListUpdater
{
    IUpdateList _updateList = new ListUpdater();
    
    [TestMethod]
    public void UpdateListResultTest() 
    { 
        Control textBox = new Control();
        textBox.Text = "Sample text";

        int index = 0;
        
        JProperty testProperty = new JProperty("name", "test value");
        List<JProperty> testList = new List<JProperty>() {testProperty};
        
        _updateList.UpdateList(testList, textBox, index);
        Assert.AreEqual(testList[index].Value, textBox.Text);
        Assert.IsInstanceOfType(testList[index], typeof(JProperty));
    }
    
    [TestMethod]
    public void UpdateTranslationResultTest() 
    { 
        JObject translatedStrings = new JObject()
        {
            ["services"] = "Сервисы",
            ["journal-medo"]= "Журнал диспетчера МЭДО",
            ["buffer-admin-settings"]= "Буфер электронных сообщений",
            ["message-management"]= "Управление сообщениями",
            ["inbox-management"]= "Управление загрузкой"
        };
        
        JObject testStrings = new JObject()
        {
            ["services"] = "Сссееерррвввииисссыыы",
            ["journal-medo"]= "Сссееерррвввииисссыыы",
            ["buffer-admin-settings"]= "Сссееерррвввииисссыыы",
            ["message-management"]= "Сссееерррвввииисссыыы",
            ["inbox-management"]= "Сссееерррвввииисссыыы"
        };
        
        List<JProperty> testList = new List<JProperty>() {new JProperty("services", "Сссееерррвввииисссыыы"), 
            new JProperty("journal-medo", "Сссееерррвввииисссыыы"),
            new JProperty("buffer-admin-settings", "Сссееерррвввииисссыыы"),
            new JProperty("message-management", "Сссееерррвввииисссыыы"),
            new JProperty("inbox-management", "Сссееерррвввииисссыыы")
        };
        
        _updateList.UpdateTranslation(translatedStrings, testList);
        
        CollectionAssert.AreEqual(translatedStrings, testStrings);
        Assert.IsInstanceOfType(testList, typeof(List<JProperty>));
    }
}