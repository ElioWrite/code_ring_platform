using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionUIModel : UIModel
{
    [SerializeField]
    private TransitionCode _code;
    public TransitionCode Code => _code;

    [SerializeField]
    protected float _showDuration;
    [SerializeField]
    protected float _hideDuration;

    [SerializeField]
    protected float _transitionDelay;

    [SerializeField]
    private TweenConflictMode _conflictMode;

    public Tweener Tweener { get; protected set; }

    public virtual float ShowDuration => _showDuration;

    public virtual float HideDuration => _hideDuration;

    public virtual float TransitionDelay => _transitionDelay;

    public virtual IEnumerator ShowCoroutine(PanelViewModel panel)
    {
        HandleConflict();
        yield return null;
    }

    public virtual IEnumerator HideCoroutine(PanelViewModel panel)
    {
        HandleConflict();
        yield return null;
    }

    public void HandleConflict()
    {
        if (_conflictMode == TweenConflictMode.Kill)
            KillTweener();
        else if (_conflictMode == TweenConflictMode.Complete)
            CompleteTween();
    }
    public void KillTweener() => Tweener?.Kill();
    public void CompleteTween() => Tweener?.Complete();
}

public enum TweenConflictMode
{
    None,
    Kill,
    Complete
}
