using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CanvasViewModel))]
public class PanelsViewModel : UIViewModel
{
    private CanvasViewModel _canvasCached;
    public CanvasViewModel CanvasCached => _canvasCached ?? (_canvasCached = GetComponent<CanvasViewModel>());

    [SerializeField]
    private List<PanelViewModel> _panels;
    public List<PanelViewModel> Panels => _panels;

    public IEnumerator ShowPanel<T>(TransitionCode transition) where T : PanelViewModel
    {
        var panel = Panels.OfType<T>().FirstOrDefault();

        if (!panel) yield return null;

        panel.IsEnabled = true;

        yield return UI.Transitions.Get(transition)?.ShowCoroutine(panel);
    }

    public IEnumerator HidePanel<T>(TransitionCode transition) where T : PanelViewModel
    {
        var panel = Panels.OfType<T>().FirstOrDefault();

        if (!panel) yield return null;

        yield return UI.Transitions.Get(transition)?.HideCoroutine(panel);

        panel.IsEnabled = false;
    }

    public void ShowPanelImmediately<T>() where T : PanelViewModel
    {
        var panel = Panels.OfType<T>().FirstOrDefault();

        if (!panel) return;

        panel.ShowImmediately();
    }

    public void HidePanelImmediately<T>() where T : PanelViewModel
    {
        var panel = Panels.OfType<T>().FirstOrDefault();

        if (!panel) return;

        panel.HideImmediately();
    }

    public void HideAllPanelsImmediately()
    {
        foreach (var p in Panels)
            p.HideImmediately();
    }

    public T GetPanel<T>() where T : PanelViewModel => Panels.OfType<T>().FirstOrDefault();
}
