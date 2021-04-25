using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitializeStateModel : StateModel
{
    public override IEnumerator OnStateBeginning()
    {
        yield return base.OnStateBeginning();

        yield return Root.Scenes.LoadScene(SceneCode.UI);

        UI.Panels.HideAllPanelsImmediately();

        UI.Panels.ShowPanelImmediately<PreloadPanelVM>();

        Debug.Log("Data caching");

        yield return new WaitForSeconds(1);
        Root.Data.Questions.FetchData();

        Debug.Log("Network connection check");
        yield return new WaitForSeconds(2);

        yield return Root.States.GoToStateCoroutine(StateCode.MainMenu);
    }

    public override IEnumerator OnStateEnding()
    {
        yield return base.OnStateEnding();

        yield return UI.Panels.HidePanel<PreloadPanelVM>(TransitionCode.Alpha);
    }
}
