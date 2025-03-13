using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class GetFileText: IGetFileText
{
    //переменная для названия переведенного файла
    public string fileName { get; set; } = null;
    //открытие файла и копирование исходного текста для перевода,
    //присвоение переменной fileName имени открытого файла
    public string GetText()
    {
        fileName = null;
        var fileText = string.Empty;
        OpenFileDialog openFile = new OpenFileDialog();
        //openFile.CheckFileExists = false;
        openFile.Filter = "Json files (*.json)|*.json";
        if (openFile.ShowDialog() != DialogResult.OK)
        {
            throw new Exception("Выберите файл.");
        }

        /*if (openFile.ShowDialog() == DialogResult.OK)
        {
            openFile.CheckFileExists = true;
        }*/
        /*if (openFile.CheckFileExists == false)
        {
            throw new Exception("Такого файла не существует."); 
        }*/
        
        fileText = File.ReadAllText(openFile.FileName);
        fileName = Path.GetFileNameWithoutExtension(openFile.FileName);
        
        if (Path.GetExtension(openFile.FileName) != ".json")
        {
            throw new Exception("Неверное расширение файла.");
        }
                    
        return fileText;
    }
}