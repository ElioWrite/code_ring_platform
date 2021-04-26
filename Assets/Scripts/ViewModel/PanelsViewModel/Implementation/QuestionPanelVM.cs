using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionPanelVM : PanelViewModel
{
    [SerializeField]
    private Text _questionText;

    [SerializeField]
    private TimerViewModel _timer;

    private QuestionDataModel _currentQuestion;

    public void OnNextButtonClicked()
    {
        var question = Root.Questions.GetRandomAndRemove();

        if(question == null)
        {
            // TODO: вывести, что вопросы кончились
        }

        Initialize(question);
    }

    public void OnClipboardPythonBtnClick()
    {
        GUIUtility.systemCopyBuffer = @"""""""" + Environment.NewLine + _currentQuestion.Text + Environment.NewLine + @"""""""";
    }

    public void OnClipboardCPPBtnClick()
    {
        GUIUtility.systemCopyBuffer = @"/*" + Environment.NewLine + _currentQuestion.Text + Environment.NewLine + @"*/";
    }

    public void Initialize(QuestionDataModel model)
    {
        _currentQuestion = model;
        _questionText.text = model.Text;
        _timer.StopTimer();
    }    
}
