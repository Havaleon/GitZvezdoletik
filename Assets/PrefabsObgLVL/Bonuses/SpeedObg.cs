using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObg : BonusObg
{
    private float �ultiplySpeed = 0.25f;
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            player.instance.OnSpeedBonus(�ultiplySpeed, Duration);
            AddIndicator(Duration);
        }
    }
}
