using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataModel : Model
{
    [SerializeField]
    private QuestionsDataModel _questionsDataModel;
    public QuestionsDataModel Questions => _questionsDataModel;
}

public abstract class JsonDataModel : Model
{
    [SerializeField]
    private string _jsonPath;
    public string JsonPath => _jsonPath;

    public abstract void FetchData();
    public abstract void ClearData();

    public static T FetchDataFromJSON<T>(string path)
    {
        if (!File.Exists(path))
            throw new ArgumentNullException("path", string.Format("File wasn't found at path: {0}", path));

        var strContent = File.ReadAllText(path);

        return JsonUtility.FromJson<T>(strContent);
    }
}

public abstract class FilesDataModel : Model
{
    [SerializeField]
    private string _filesDirectoryPath;
    public string FilesDirectoryPath => _filesDirectoryPath;

    public abstract void FetchData();
    public abstract void ClearData();

    public static IEnumerable<FileDataModel> FetchDataFromFiles(string path)
    {
        if (!Directory.Exists(path))
            throw new ArgumentNullException("path", string.Format("Directory wasn't found at path: {0}", path));

        var files = Directory.GetFiles(path, searchPattern: "*.txt");

        var resultList = new List<FileDataModel>();

        for(int i = 0; i < files.Length; i++)
        {
            resultList.Add(new FileDataModel(i + 1, File.ReadAllText(files[i])));
        }

        return resultList;
    }
}

public class FileDataModel
{
    public FileDataModel(int number, string text)
    {
        this.Number = number;
        this.Text = text;
    }

    public int Number { get; private set; }
    public string Text { get; private set; }
}
