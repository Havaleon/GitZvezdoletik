using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDataBonus : MonoBehaviour
{
    private void Awake()
    {
        instans = this;
    }

    public static StaticDataBonus instans;

    public AnimationCurve AnimationTakePos, AnimationTakePosY,
        AnimationTakeScale;
}
