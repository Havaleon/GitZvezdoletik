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
            CameraController.instance.ShakeEnable();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OnSpeed = false;
            CameraController.instance.ShakeDisable();
        }
    }


    private bool OnSpeed = false;
    private void Update()
    {
        if (OnSpeed)
        {
            float speed = player.instance.Speed_Max.x * 0.1f;

            player.instance.transform.position += transform.forward * speed * Time.deltaTime;
        }   
    }
}
