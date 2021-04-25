using System.Collections;
using UnityEngine;

public class PanelsUIModel : UIModel
{
    [SerializeField]
    private PanelsViewModel _viewModel;
    public virtual PanelsViewModel ViewModel => _viewModel;

    public IEnumerator ShowPanel<T>(TransitionCode code) where T : PanelViewModel
    {
        yield return ViewModel.ShowPanel<T>(code);
    }

    public void ShowPanelSynchronously<T>(TransitionCode code) where T : PanelViewModel
    {
        StartCoroutine(ViewModel.ShowPanel<T>(code));
    }

    public void HidePanelSynchronously<T>(TransitionCode code) where T : PanelViewModel
    {
        StartCoroutine(ViewModel.HidePanel<T>(code));
    }

    public void ShowPanelImmediately<T>() where T : PanelViewModel
    {
        ViewModel.ShowPanelImmediately<T>();
    }

    public void HidePanelImmediately<T>() where T : PanelViewModel
    {
        ViewModel.HidePanelImmediately<T>();
    }

    public IEnumerator HidePanel<T>(TransitionCode code) where T : PanelViewModel
    {
        yield return ViewModel.HidePanel<T>(code);
    }

    public void HideAllPanelsImmediately()
    {
        ViewModel.HideAllPanelsImmediately();
    }
}
