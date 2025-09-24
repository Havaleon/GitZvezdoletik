using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecelerationObg : BonusObg
{
    private float ÌultiplySpeed = -0.25f;
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            player.instance.OnDecelerationBonus(ÌultiplySpeed, Duration);
            AddIndicator(Duration);
        }
    }
}
