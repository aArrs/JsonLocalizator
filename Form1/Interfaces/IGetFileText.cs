using System.Xml;

namespace WinFormsApp2.Interfaces;

public interface IGetFileText
{
    void GetText(OpenFileDialog openFile);
    public string fileExtension { get; set; }
    public string fileName { get; set; }
    public string fileText { get; set; }
    public string tempFilePath { get; set; }
    public  List<KeyValuePair<string, string>> resources { get; set; }
    public List<XmlNode> oldHeaders {get; set; }

    public void AddResHeader(XmlDocument xmlDoc, XmlElement root, string name, string value,
        XmlNode insertBeforeNode = null);
}
