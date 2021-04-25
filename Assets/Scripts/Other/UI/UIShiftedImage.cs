using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShiftedImage : UIViewModel
{
    public RectTransform AdditionalRect;

    public void SetShift(ShiftDirection direction)
    {
        switch(direction)
        {
            case ShiftDirection.Left:
                AdditionalRect.SetAsLastSibling();
                break;
            case ShiftDirection.Right:
                AdditionalRect.SetAsFirstSibling();
                break;
        }
    }
}

public enum ShiftDirection
{
    Left,
    Right
}
