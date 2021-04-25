using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public abstract class PanelViewModel : UIViewModel
{
    private CanvasGroup _canvas;
    public CanvasGroup CanvasGroupCached
    {
        get
        {
            if (_canvas == null) _canvas = GetComponent<CanvasGroup>();
            return _canvas;
        }
    }

    private RectTransform _rectCashed;
    public RectTransform RectCashed
    {
        get
        {
            if (_rectCashed == null) _rectCashed = GetComponent<RectTransform>();
            return _rectCashed;
        }
    }

    public bool IsEnabled
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    public bool IsInteractable
    {
        get { return CanvasGroupCached.interactable; }
        set { CanvasGroupCached.interactable = false; }
    }

    public bool IsBlocksRaycasts
    {
        get { return CanvasGroupCached.blocksRaycasts; }
        set { CanvasGroupCached.blocksRaycasts = value; }
    }

    public void HideImmediately(bool withDisabling = true)
    {
        CanvasGroupCached.alpha = 0;
        if (withDisabling) IsEnabled = false;
    }

    public void ShowImmediately(bool withEnabling = true)
    {
        CanvasGroupCached.alpha = 1;
        if (withEnabling) IsEnabled = true;
    }
}
