using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entyti : MonoBehaviour
{
    [SerializeField]
    private Transform ParentObg;

    [SerializeField]
    private int HealthMax = 100;
    private int Health;
    private void OnEnable()
    {
        Health = HealthMax;
    }

    public void Damage(int Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            ParentObg.parent.gameObject.SetActive(false);
        }
    }
}
