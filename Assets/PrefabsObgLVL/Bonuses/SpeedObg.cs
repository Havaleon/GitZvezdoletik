using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObg : BonusObg
{
    private float ÌultiplySpeed = 0.25f;
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            player.instance.OnSpeedBonus(ÌultiplySpeed, Duration);
            AddIndicator(Duration);
        }
    }
}
