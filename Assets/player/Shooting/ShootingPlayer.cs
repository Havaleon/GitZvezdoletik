using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
