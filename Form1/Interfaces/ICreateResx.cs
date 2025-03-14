using System.Xml;

namespace WinFormsApp2.Interfaces;

public interface ICreateResx
{
    public void CreateResx(List<KeyValuePair<string, string>> resxList, string fileName, string toLanguage, string tempFilePath);
}