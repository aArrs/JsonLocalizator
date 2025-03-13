using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class JsonCreator : ICreateJson
{
    //создание файла в директории ...Documents\en\be,
    //запись в него переведенной структуры json
    public async void CreateJson(string translatedStrings, string fileName, string toLanguage)
    {
        var username = Environment.UserName;
        var newFileName = $"{fileName}.json";
        var filePath = "C:\\Users\\" + username + $"\\Documents\\{toLanguage}\\{newFileName}";
        if (fileName == null)
        {
            throw new Exception("Выберите файл для перевода.");
        }
        if (translatedStrings == null)
        {
            throw new Exception("Сначала переведите файл.");
        }
        if (toLanguage == null)
        {
            throw new Exception("Выберите язык.");
        }
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        await using (File.Create(filePath)){}

        File.WriteAllText(filePath, translatedStrings);
        MessageBox.Show($"Файл {newFileName} успешно сохранен в {filePath}");

    }
}