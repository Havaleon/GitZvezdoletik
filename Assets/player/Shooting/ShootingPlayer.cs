using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    void Update()
    {
        Shooting();
    }

    [SerializeField]
    private GameObject Projectile,
        PivotShootLeft, PivotShootRite;

    private void Shooting()
    {
        //GameObject g = LVL_Tools.Get_Pool();
    }
}
