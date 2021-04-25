using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitingStateModel : StateModel
{
    public override IEnumerator OnStateBeginning()
    {
        yield return base.OnStateBeginning();

        yield return UI.Panels.ShowPanel<ExitingPanelVM>(TransitionCode.Alpha);

        Debug.Log("Data saving");
        yield return new WaitForSeconds(1);
        Debug.Log("Clear all resources");
        yield return new WaitForSeconds(1);

        Debug.Log("Close application...");

        ExitApplication();
    }

    private void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
