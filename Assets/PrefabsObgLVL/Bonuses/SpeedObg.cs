using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObg : BonusObg
{
    private float �ultiplySpeed = 0.25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.inst.OnSpeedBonus(�ultiplySpeed, Duration);
            AddIndicator(Duration);

            ParentObg.SetActive(false);
        }
    }
}
