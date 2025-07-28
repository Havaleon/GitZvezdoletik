using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticWindOBG : MonoBehaviour
{
    private void OnDisable()
    {
        OnSpeed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnSpeed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OnSpeed = false;
        }
    }


    private bool OnSpeed = false;
    private void Update()
    {
        if (OnSpeed)
        {
            float speed = player.inst.Speed_Max.x * 0.1f;

            player.inst.transform.position += transform.forward * speed * Time.deltaTime;
        }   
    }
}
