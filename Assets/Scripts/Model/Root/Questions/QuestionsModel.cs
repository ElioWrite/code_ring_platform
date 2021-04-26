using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionsModel : Model
{
    private List<QuestionDataModel> _fetchedDataList = new List<QuestionDataModel>();

    public QuestionDataModel GetRandomAndRemove()
    {
        if (_fetchedDataList.Count < 1)
            return null;

        var question = _fetchedDataList[Random.Range(0, _fetchedDataList.Count)];

        _fetchedDataList.Remove(question);

        return question;
    }

    public void Initialize()
    {
        _fetchedDataList = Root.Data.Questions.FetchedData.ToList();
    }
}
