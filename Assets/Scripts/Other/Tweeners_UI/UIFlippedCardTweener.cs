using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

/// <summary>
/// Твиннер, имитирующий поведение "переворачивающейся карты";
/// </summary>
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class UIFlippedCardTweener : MonoBehaviour
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

    private Image _imageCashed;
    public Image ImageCashed
    {
        get
        {
            if (_imageCashed == null) _imageCashed = GetComponent<Image>();
            return _imageCashed;
        }
    }

    // Длительность переворота;
    public float FlipDuration;

    public Ease EaseMode;

    public Text CardText;

    public bool IsFlipped { get; private set; }

    [Header("Включить переход по цвету:")]
    public bool IsColorTransitionEnabled;
    public Color TransitionColor;

    private Tweener _flipTweener;

    void StartHalfFlip(System.Action callbackMethod, float delay = 0)
    {
        //_flipTweener.Complete();

        _flipTweener = DOTween.To(
            () => RectCashed.rotation,
            (t) => RectCashed.rotation = t,
             new Vector3(RectCashed.rotation.x, 90, RectCashed.rotation.z), FlipDuration / 2);
        _flipTweener.SetEase(EaseMode);
        _flipTweener.SetDelay(delay);
        _flipTweener.OnComplete(callbackMethod.Invoke);
    }

    void EndHalfFlip(System.Action callbackMethod, float delay = 0)
    {
        //_flipTweener.Kill();
        //RectCashed.rotation = Quaternion.Euler(RectCashed.rotation.x, 90, RectCashed.rotation.z);
        _flipTweener = DOTween.To(
            () => RectCashed.rotation,
            (t) => RectCashed.rotation = t,
            new Vector3(RectCashed.rotation.x, 0, RectCashed.rotation.z), FlipDuration / 2);
        _flipTweener.SetEase(EaseMode);
        _flipTweener.SetDelay(delay);
        _flipTweener.OnComplete(callbackMethod.Invoke);
    }

    /// <summary>
    /// Повернуть карту с текстом;
    /// </summary>
    public void FlipCardWithText(string endText, System.Action callback = null, float delay = 0)
    {
        if (callback == null)
            callback = () => { };

        //var startColor = ImageCashed.color;
        StartHalfFlip(() =>
        {
            CardText.text = endText;
            if(IsColorTransitionEnabled) ImageCashed.color = TransitionColor;
            EndHalfFlip(() => { IsFlipped = true; callback(); });
        }, delay);
    }

    public IEnumerator FlipCardWithTextCoroutine(
        string startText, string endText, Action callback = null, float delay = 0)
    {
        if (callback == null)
            callback = () => { };

        bool isFlipEnded = false;

        CardText.text = startText;

        FlipCardWithText(endText, () => { isFlipEnded = true; IsFlipped = true; callback(); }, delay);

        while (!isFlipEnded)
            yield return null;
    }
}
