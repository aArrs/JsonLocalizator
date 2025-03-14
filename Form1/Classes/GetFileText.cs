using System.Collections;
using System.ComponentModel.Design;
using System.Resources;
using System.Xml;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class GetFileText: IGetFileText
{
    string username = Environment.UserName;
    public string fileName { get; set; } = null;
    public string fileExtension { get; set; } = null;
    public string fileText { get; set; } = null;
    public string tempFilePath { get; set; } = null;
    
    public List<XmlNode> oldHeaders { get; set; } = new List<XmlNode>();
    public List<KeyValuePair<string, string>> resources { get; set; } = new List<KeyValuePair<string, string>>();
    //если .json файл, то присваеваем fileText содержимое для дальнейшей работы
    //если .resx, то 
    //зменяем элементы resheader для корректной работы с винформ
    //ждя этого создаем новый temp файл с новыми значениями resheader, 
    // открываем его и записываем в список все элементы для дальнейшей работы
    public void GetText(OpenFileDialog openFile)
    {
        
        fileName = null;
        fileText = null;
        fileExtension = null;
        tempFilePath = null;
        oldHeaders.Clear();
        oldHeaders.TrimExcess();
        resources.Clear();
        resources.TrimExcess();
        
        openFile.Filter = "Json files (*.json)|*.json| Resource files (*.resx*)|*.resx";
        if (openFile.ShowDialog() != DialogResult.OK)
        {
            throw new Exception("Выберите файл.");
        }

        var keyValuePairs = new Hashtable(); 
        tempFilePath =  "C:\\\\Users\\" + username + "\\Documents\\new_file.resx";
        fileName = Path.GetFileNameWithoutExtension(openFile.FileName);
        fileExtension = Path.GetExtension(openFile.FileName);
        
        if (fileExtension == ".json")
        {
            fileText = File.ReadAllText(openFile.FileName);
        }
        else
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(openFile.FileName);

            // Получение корневого элемента
            XmlElement root = xmlDoc.DocumentElement;
            if (root == null || root.Name != "root")
            {
                throw new Exception("Файл не содержит корневого элемента <root>.");
            }
            // Удаление старых заголовков
            
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

            // Поиск первого элемента data
            XmlNode firstDataNode = null;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "data")
                {
                    firstDataNode = node;
                    break;
                }
            }

            // Добавление новых заголовков перед первым элементом data
            if (firstDataNode != null)
            {
                AddResHeader(xmlDoc, root, "resmimetype", "text/microsoft-resx", firstDataNode);
                AddResHeader(xmlDoc, root, "version", "2.0", firstDataNode);
                AddResHeader(xmlDoc, root, "reader", "System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", firstDataNode);
                AddResHeader(xmlDoc, root, "writer", "System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", firstDataNode);
            }
            else
            {
                // Если элементов data нет, добавляем заголовки в конец
                AddResHeader(xmlDoc, root, "resmimetype", "text/microsoft-resx");
                AddResHeader(xmlDoc, root, "version", "2.0");
                AddResHeader(xmlDoc, root, "reader", "System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
                AddResHeader(xmlDoc, root, "writer", "System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            }

            // Сохранение изменений в новый файл
            xmlDoc.Save(tempFilePath);
            using (ResXResourceReader reader = new ResXResourceReader(tempFilePath))
            {
                reader.UseResXDataNodes = true;
                foreach (DictionaryEntry entry in reader)
                {
                    if (entry.Value is ResXDataNode node)
                    {
                        // Получаем имя узла
                        string key = node.Name;

                        // Получаем значение узла
                        object value = node.GetValue((ITypeResolutionService)null);

                        resources.Add(new KeyValuePair<string, string>(key, value.ToString()));
                        
                    }
                }
            }
        }
        if (fileExtension != ".json" && fileExtension != ".resx")
            {
                throw new Exception("Неверное расширение файла.");
            }
        }
    public void AddResHeader(XmlDocument xmlDoc, XmlElement root, string name, string value, XmlNode insertBeforeNode = null)
    {
        // Создание элемента resheader
        XmlElement resHeader = xmlDoc.CreateElement("resheader");
        resHeader.SetAttribute("name", name);

        // Создание элемента value
        XmlElement valueElement = xmlDoc.CreateElement("value");
        valueElement.InnerText = value;

        // Добавление value в resheader
        resHeader.AppendChild(valueElement);

        // Вставка resheader перед указанным узлом или в конец
        if (insertBeforeNode != null)
        {
            root.InsertBefore(resHeader, insertBeforeNode);
        }
        else
        {
            root.AppendChild(resHeader);
        }
    }
}
