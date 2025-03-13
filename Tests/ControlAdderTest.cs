using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;

namespace Tests;

[TestClass]
public class ControlAdderTest : ControlsAdder
{
    
    IAddControls _addControls = new ControlsAdder();

    [TestMethod]
    public void AddLabelResultTest()
    { 
        Panel testPanel = new Panel();
    
        System.Collections.Generic.List<Newtonsoft.Json.Linq.JProperty> sourceList = new System.Collections.Generic.List<Newtonsoft.Json.Linq.JProperty>()
        {
            new JProperty("folder-inbox", "Папки входящих"),
            new JProperty("folder-outbox", "Папки исходящих"),
            new JProperty("folder-card", "Настройка папки"),
            new JProperty("management-card", "Настройка конфигурации"),
        };


        System.Collections.Generic.List<System.Windows.Forms.Control> testList = new System.Collections.Generic.List<System.Windows.Forms.Control>();
        System.Collections.Generic.List<System.Windows.Forms.Control> checkList = new System.Collections.Generic.List<System.Windows.Forms.Control>();
        
        checkList.Add(new TextBox { Text = "folder-inbox" });
        checkList.Add(new TextBox { Text = "folder-outbox" });
        checkList.Add(new TextBox { Text = "folder-card" });
        checkList.Add(new TextBox { Text = "management-card" });  
        
        _addControls.AddLabel(testPanel, sourceList, testList);
        
        Assert.AreEqual(testList.Count, checkList.Count);
    }
}