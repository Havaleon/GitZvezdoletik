using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public float Speed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        if(transform.position.z > player.instance.Pos.z + 30)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        entyti entyti = other.GetComponent<entyti>();
        //Debug.Log(entyti);
        
        if(entyti != null)
        {
            entyti.Damage(40);

            gameObject.SetActive(false);
        }
    }
}
