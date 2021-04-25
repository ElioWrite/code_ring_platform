using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIMovingElement : MonoBehaviour
{
    private RectTransform _rectCashed;
    public RectTransform RectCashed
    {
        get
        {
            if (_rectCashed == null) _rectCashed = GetComponent<RectTransform>();
            return _rectCashed;
        }
    }

    [Tooltip("Динамика движения.")]
    public Ease EaseMode;

    private Tweener _moveTweener;

   /// <summary>
   /// Плавное движение за время duration с предварительным перемещением в from.
   /// Юзается anchoredPosition.
   /// </summary>
    public void MoveFromTo(Vector2 from, Vector2 to, float duration, TweenCallback callback, float delay = 0)
    {
        _moveTweener.Complete();
        RectCashed.anchoredPosition = from;

        _moveTweener = DOTween.To(
            () => RectCashed.anchoredPosition,
            (t) => RectCashed.anchoredPosition = t,
            to, duration);
        _moveTweener.SetEase(EaseMode);
        _moveTweener.SetDelay(delay);
        _moveTweener.OnComplete(callback);
    }

    /// <summary>
    /// Плавное движение за время duration из текущей позиции.
    /// Юзается anchoredPosition.
    /// </summary>
    public void MoveTo(Vector2 to, float duration, TweenCallback callback, float delay = 0)
    {
        _moveTweener.Complete();

        _moveTweener = DOTween.To(
            () => RectCashed.anchoredPosition,
            (t) => RectCashed.anchoredPosition = t,
            to, duration);
        _moveTweener.SetEase(EaseMode);
        _moveTweener.SetDelay(delay);
        _moveTweener.OnComplete(callback);
    }
}
