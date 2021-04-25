using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIFlippedCardTweener))]
public class UIFlippedCard : UIViewModel
{
    [SerializeField]
    private UIFlippedCardTweener _flipTweenerCached;
    public UIFlippedCardTweener FlipTweenerCached => _flipTweenerCached;
}
