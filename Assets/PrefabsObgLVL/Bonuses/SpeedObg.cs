using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObg : BonusObg
{
    private float ÌultiplySpeed = 0.25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.inst.OnSpeedBonus(ÌultiplySpeed, Duration);
            AddIndicator(Duration);

            ParentObg.SetActive(false);
        }
    }
}
