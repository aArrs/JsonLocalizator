using Newtonsoft.Json.Linq;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;

namespace Tests;

[TestClass]
public sealed class CastTest : Cast
{
    ICast _cast = new Cast();
    
    [TestMethod]
    public void GetJObjectResultTest() 
    { 
        JObject testJson = new JObject()
    {
        ["services"] = "Сервисы",
        ["journal-medo"]= "Журнал диспетчера МЭДО",
        ["buffer-admin-settings"]= "Буфер электронных сообщений",
        ["message-management"]= "Управление сообщениями",
        ["inbox-management"]= "Управление загрузкой",
        ["outbox-management"]= "Управление отправкой",
        ["medo-management"]= "Управление каналом МЭДО",
        ["protocol-table"]= "Протокол электронного сообщения",
        ["message-audit"]= "Аудит сообщений",
        ["folder-settings"]= "Настройка папок и конфигурации",
        ["distribution-message"]= "Управлять распределением сообщений",
        ["clean-message"]= "Управление очисткой сообщений",
        ["folder-inbox"]= "Папки входящих",
        ["folder-outbox"]= "Папки исходящих",
        ["folder-card"]= "Настройка папки",
        ["management-card"]= "Настройка конфигурации"
    };
        string testString = testJson.ToString();
        
        var castedItem = _cast.GetJObject(testString);
        
        Assert.IsInstanceOfType(_cast.GetJObject(testString), typeof(JObject));
        CollectionAssert.AreEqual(castedItem, testJson);
    }
}
