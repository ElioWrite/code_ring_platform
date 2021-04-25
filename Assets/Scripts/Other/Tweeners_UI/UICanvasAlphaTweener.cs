using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class UICanvasAlphaTweener : MonoBehaviour
{
    private CanvasGroup _canvas;
    public CanvasGroup CanvasGroup
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

    private Tweener tweener;

    /// <summary>
    /// Плавно меняем прозрачность у CanvasGroup обжекта
    /// </summary>
    public void TweenBetweenAlpha(float targetAlpha, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        tweener = DOTween.To(
            () => CanvasGroup.alpha,
            (t) => CanvasGroup.alpha = t,
            targetAlpha, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Плавно меняем прозрачность у CanvasGroup обжекта, со стартовым значением.
    /// </summary>
    public void TweenBetweenAlpha(float startAlpha, float targetAlpha, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        CanvasGroup.alpha = startAlpha;
        TweenBetweenAlpha(targetAlpha, easeMod, duration, callbackMethod, delay);
    }

    public void StopTween()
    {
        if (tweener != null)
            tweener.Kill();
    }

    public void CompleteTween()
    {
        if(tweener != null)
            tweener.Complete();
    }
}
