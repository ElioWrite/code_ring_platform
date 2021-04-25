using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTransiton : TransitionUIModel
{
    [SerializeField]
    private Ease _easeMode;
    public Ease EaseMode => _easeMode;

    public override IEnumerator HideCoroutine(PanelViewModel panel)
    {
        base.HideCoroutine(panel);

        Tweener = DOTween.To(
            () => panel.CanvasGroupCached.alpha,
            (t) => panel.CanvasGroupCached.alpha = t,
            0, ShowDuration);
        Tweener.SetEase(_easeMode);
        Tweener.SetDelay(TransitionDelay);

        while (Tweener.IsActive())
            yield return null;
    }

    public override IEnumerator ShowCoroutine(PanelViewModel panel)
    {
        base.ShowCoroutine(panel);

        Tweener = DOTween.To(
            () => panel.CanvasGroupCached.alpha,
            (t) => panel.CanvasGroupCached.alpha = t,
            1, ShowDuration);
        Tweener.SetEase(_easeMode);
        Tweener.SetDelay(TransitionDelay);

        while (Tweener.IsActive())
            yield return null;
    }
}
