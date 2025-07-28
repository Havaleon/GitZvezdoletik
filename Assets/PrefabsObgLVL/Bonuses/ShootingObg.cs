using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObg : BonusObg
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.inst.OnShooting(Duration);
            AddIndicator(Duration);
            ParentObg.SetActive(false);
        }
    }
}
