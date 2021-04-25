using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionsDataModel : FilesDataModel
{
    public IEnumerable<QuestionDataModel> FetchedData { get; private set; }

    public override void FetchData()
    {
        if (FetchedData != null)
            ClearData();

        FetchedData = FetchDataFromFiles(FilesDirectoryPath)
            .Select(s => new QuestionDataModel(s.Number, s.Text));

        Debug.Log(FetchedData);
    }

    public override void ClearData()
    {
        FetchedData = null;
    }
}
