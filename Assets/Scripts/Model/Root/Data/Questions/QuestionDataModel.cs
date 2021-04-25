using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDataModel
{
    public int Number { get; private set; }

    public Guid ID { get; private set; }

    public string Text { get; private set; }

    /// <summary>
    /// Creates a QuestionData from params.
    /// Guid will be generated automatically.
    /// </summary>
    public QuestionDataModel(int number, string text)
    {
        Number = number;
        Text = text;

        ID = Guid.NewGuid();
    }

    /// <summary>
    /// Creates a StudentData from StudentJsonData.
    /// </summary>
    public QuestionDataModel(FileDataModel fileModel) : this(fileModel.Number, fileModel.Text) { }
}
