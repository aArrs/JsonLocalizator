using System.Collections;
using System.ComponentModel.Design;
using System.Resources;
using System.Xml;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class ResxCreator : ICreateResx
{
    IGetFileText _getFileText = new GetFileText();
    public void CreateResx(List<KeyValuePair<string, string>> resxList, string fileName, string toLanguage, string tempFilePath)
    {
        var username = Environment.UserName;
        var newFileName = $"{fileName}.{toLanguage}.resx";
        var filePath = "C:\\Users\\" + username + $"\\Documents\\resx_{toLanguage}\\{newFileName}";
        
        List<XmlNode> oldHeaders = new List<XmlNode>();
        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(tempFilePath);
        
        XmlElement root = xmlDoc.DocumentElement;
        
        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.Name == "resheader")
            {
                oldHeaders.Add(node);
            }
        }

        foreach (var node in oldHeaders)
        {
            root.RemoveChild(node);
        }


        XmlNode firstDataNode = null;
        
        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.Name == "data")
            {
                firstDataNode = node;
                break;
            }
        }
        
        if (firstDataNode != null)
        {
            _getFileText.AddResHeader(xmlDoc, root, "resmimetype", "text/microsoft-resx", firstDataNode);
            _getFileText.AddResHeader(xmlDoc, root, "version", "2.0", firstDataNode);
            _getFileText.AddResHeader(xmlDoc, root, "reader", "System.Resources.NetStandard.ResXResourceReader", firstDataNode);
            _getFileText.AddResHeader(xmlDoc, root, "writer", "System.Resources.NetStandard.ResXResourceWriter", firstDataNode);
        }
        else
        {
            _getFileText.AddResHeader(xmlDoc, root, "resmimetype", "text/microsoft-resx");
            _getFileText.AddResHeader(xmlDoc, root, "version", "2.0");
            _getFileText.AddResHeader(xmlDoc, root, "reader", "System.Resources.NetStandard.ResXResourceReader");
            _getFileText.AddResHeader(xmlDoc, root, "writer", "System.Resources.NetStandard.ResXResourceWriter");
        }
        foreach (var newValue in resxList)
        {
            XmlNode dataNode = root.SelectSingleNode($"data[@name='{newValue.Key}']");
            if (dataNode != null)
            {
                XmlNode valueNode = dataNode.SelectSingleNode("value");
                if (valueNode != null)
                {
                    valueNode.InnerText = newValue.Value;
                }
            }
        }

        xmlDoc.Save(filePath);
        
        MessageBox.Show($"Файл {newFileName} успешно сохранен в {filePath}");
    }
}