using System.Collections;
using UnityEngine;

public class MainMenuStateModel : StateModel
{
    public override IEnumerator OnStateBeginning()
    {
        yield return base.OnStateBeginning();

        UI.Panels.ShowPanel<MainMenuPanelVM>(TransitionCode.Alpha);

        // yield return Root.States.GoToStateCoroutine(StateCode.Introduction);
    }

    public override IEnumerator OnStateEnding()
    {
        yield return base.OnStateEnding();

        yield return UI.Panels.HidePanel<PreloadPanelVM>(TransitionCode.Alpha);
    }
}
