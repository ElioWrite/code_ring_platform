using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

[RequireComponent(typeof(RectTransform))]
public class UIPulseTweener : MonoBehaviour
{
    private RectTransform _rect;
    public RectTransform RTransform
    {
        get
        {
            if (_rect == null) _rect = GetComponent<RectTransform>();
            return _rect;
        }
    }

    // КОСТЫЛЬ! Связано с неправильной работой Complete() в ряде скриптов.
    Tweener tweener;
    Tweener tweener2;

    public float PulseDuration;
    public float MaxScale;

    [Header("Пульсирует ли объект:")]
    public bool IsPulsed = false;

    public void StartPulse(float delay)
    {
        IsPulsed = true;
        Invoke("StartPulse", delay);
    }

    public void StartPulse()
    {
        IsPulsed = true;
        StartPulseTween();
    }

    public void StopPulse()
    {
        IsPulsed = false;
    }

    void StartPulseTween()
    {
        TweenBetweenScaleElastic(Vector3.one, new Vector3(MaxScale, MaxScale, MaxScale), Ease.Linear, PulseDuration, () => { if (IsPulsed) StartPulseTween(); });
    }

    /// <summary>
    /// Плавное изменение скейла обжекта.
    /// </summary>
    public void TweenBetweenScale(Vector3 targetScale, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        tweener2 = DOTween.To(
            () => RTransform.localScale,
            (t) => RTransform.localScale = t,
            targetScale, duration);
        tweener2.SetEase(easeMod);
        tweener2.SetDelay(delay);
        tweener2.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Плавное изменение скейла обжекта (с начальным значением)
    /// </summary>
    public void TweenBetweenScale(Vector3 startScale, Vector3 targetScale, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.localScale = startScale;
        TweenBetweenScale(targetScale, easeMod, duration, callbackMethod, delay);
    }

    public void TweenBetweenScaleElastic(Vector3 startScale, Vector3 targetScale, Ease easeMod,
        float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.localScale = startScale;

        tweener = DOTween.To(
            () => RTransform.localScale,
            (t) => RTransform.localScale = t,
            targetScale, duration / 2);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(() => TweenBetweenScale(startScale, easeMod, duration / 2, callbackMethod, 0));
    }
}
