using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionStateModel : StateModel
{
    private List<QuestionDataModel> _fetchedDataList = new List<QuestionDataModel>();

    public override IEnumerator OnStateBeginning()
    {
        yield return base.OnStateBeginning();

        yield return UI.Panels.ShowPanel<QuestionPanelVM>(TransitionCode.Alpha);

        Root.Questions.Initialize();

        UI.Panels.ViewModel.GetPanel<QuestionPanelVM>().Initialize(Root.Questions.GetRandomAndRemove());

        // yield return Root.States.GoToStateCoroutine(StateCode.Introduction);
    }

    public override IEnumerator OnStateEnding()
    {
        yield return base.OnStateEnding();

        yield return UI.Panels.HidePanel<QuestionPanelVM>(TransitionCode.Alpha);
    }
}
