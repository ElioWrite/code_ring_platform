using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;

[RequireComponent(typeof(Image))]
public class UIImageFillTweener : MonoBehaviour
{
    private Image _imageCashed;
    public Image ImageCashed
    {
        get
        {
            if (_imageCashed == null) _imageCashed = GetComponent<Image>();
            return _imageCashed;
        }
    }

    private Tweener _fillTweener;

    public void TweenBetweenFill(float endFill, float duration, Action callback, float delay = 0)
    {
        _fillTweener = DOTween.To(
            () => ImageCashed.fillAmount,
            (t) => ImageCashed.fillAmount = t,
            endFill, duration);
        _fillTweener.SetEase(Ease.Linear);
        _fillTweener.SetDelay(delay);
        _fillTweener.OnComplete(callback.Invoke);
    }

    public void TweenBetweenFill(float startFill, float endFill, float duration, Action callback, float delay = 0)
    {
        ImageCashed.fillAmount = startFill;
        _fillTweener = DOTween.To(
            () => ImageCashed.fillAmount,
            (t) => ImageCashed.fillAmount = t,
            endFill, duration);
        _fillTweener.SetEase(Ease.Linear);
        _fillTweener.SetDelay(delay);
        _fillTweener.OnComplete(callback.Invoke);
    }

    public void CompleteTween()
    {
        _fillTweener.Complete();
    }

    public void KillTween()
    {
        _fillTweener.Kill();
    }
}
