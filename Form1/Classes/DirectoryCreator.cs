using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class DirectoryCreator: ICreateDirectory
{
    public void CreateDirectory(string dir)
    {
        var username = Environment.UserName;
        var filePath = "C:\\Users\\" + username + $"\\Documents\\{dir}";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
    }
}