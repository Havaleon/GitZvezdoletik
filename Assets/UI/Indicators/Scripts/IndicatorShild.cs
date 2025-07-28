using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorShild : MonoBehaviour
{
    private void Update()
    {
        if(Dead_scr.Instance.BonusExtraLivesBool == false)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
