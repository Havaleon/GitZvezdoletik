using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObg : BonusObg
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        //OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            player.instance.OnShooting(Duration);
            AddIndicator(Duration);
        }
    }
}
