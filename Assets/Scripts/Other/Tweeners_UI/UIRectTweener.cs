using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(RectTransform))]
public class UIRectTweener : MonoBehaviour
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

    /// <summary>
    /// Двигаем UI-обжект плавно до targetPos
    /// </summary>
    public void MoveBetween(Vector2 targetPos, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        tweener = DOTween.To(
            () => RTransform.anchoredPosition,
            (t) => RTransform.anchoredPosition = t,
            targetPos, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Двигаем UI-обжект плавно до targetPos, но предварительно поместив его в точку startPos 
    /// </summary>
    public void MoveBetween(Vector2 startPos, Vector2 targetPos, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.anchoredPosition = startPos;
        tweener = DOTween.To(
            () => RTransform.anchoredPosition,
            (t) => RTransform.anchoredPosition = t,
            targetPos, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);

    }



    /// <summary>
    /// Двигаем обжект в глобал координатах (полезно при большой вложенности)
    /// учитывать RectTransform.position (ВАЖНО!)
    /// </summary>
    public void MoveBetweenGlobal(Vector2 targetPos, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        tweener = DOTween.To(
            () => RTransform.position,
            (t) => RTransform.position = t,
            (Vector3)targetPos, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    public void MoveBetweenGlobal(Vector2 startPos, Vector2 targetPos, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.position = startPos;
        tweener = DOTween.To(
            () => RTransform.position,
            (t) => RTransform.position = t,
            (Vector3)targetPos, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Плавное изменение высоты обжекта до targetHeight
    /// </summary>
    public void TweenBetweenHeight(float targetHeight, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        Tweener tweener = DOTween.To(
            () => RTransform.sizeDelta.y,
            (t) => RTransform.sizeDelta = new Vector2(RTransform.sizeDelta.x, t),
            targetHeight, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Плавное изменение высоты обжекта до targetHeight с заданным начальным значением
    /// </summary>
    public void TweenBetweenHeight(float startHeight, float targetHeight, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.sizeDelta = new Vector2(RTransform.sizeDelta.x, startHeight);
        TweenBetweenHeight(targetHeight, easeMod, duration, callbackMethod, delay);
    }

    /// <summary>
    /// Плавное изменение ширины обжекста до targetWidth
    /// </summary>
    public void TweenBetweenWidth(float targetWidth, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        Tweener tweener = DOTween.To(
            () => RTransform.sizeDelta.x,
            (t) => RTransform.sizeDelta = new Vector2(t, RTransform.sizeDelta.y),
            targetWidth, duration);
        tweener.SetEase(easeMod);
        tweener.SetDelay(delay);
        tweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Плавное изменение ширины обжекста до targetWidth с заданным начальным значением
    /// </summary>
    public void TweenBetweenWidth(float startWidth, float targetWidth, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        RTransform.sizeDelta = new Vector2(startWidth, RTransform.sizeDelta.y);
        TweenBetweenWidth(targetWidth, easeMod, duration, callbackMethod, delay);
    }

    /// <summary>
    /// Плавное изменение и высоты, и ширины обжекта
    /// </summary>
    public void TweenBetweenWidthAndHeight(float targetWidth, float targetHeight, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        TweenBetweenWidth(targetWidth, easeMod, duration, delegate { }, delay);
        TweenBetweenHeight(targetHeight, easeMod, duration, callbackMethod, delay);
    }

    /// <summary>
    /// Плавное изменение и высоты, и ширины обжекта с начальными значениями
    /// </summary>
    public void TweenBetweenWidthAndHeight(float startWidth, float targetWidth, float startHeight, float targetHeight,
                                            Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        TweenBetweenWidth(startWidth, targetWidth, easeMod, duration, delegate { }, delay);
        TweenBetweenHeight(startHeight, targetHeight, easeMod, duration, callbackMethod, delay);
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

    public void TweenBetweenRotation(Vector3 targetRotation, Ease easeMod, float duration, Action callbackMethod, float delay = 0)
    {
        tweener2 = DOTween.To(
            () => RTransform.rotation.eulerAngles,
            (t) => RTransform.rotation = Quaternion.Euler(t),
            targetRotation, duration);
        tweener2.SetEase(easeMod);
        tweener2.SetDelay(delay);
        tweener2.OnComplete(callbackMethod.Invoke);
    }

    public void StopTween()
    {
        tweener.Kill();
        tweener2.Kill();
    }

    public void CompleteTween()
    {
        tweener.Complete();
        tweener2.Complete();
    }
}
