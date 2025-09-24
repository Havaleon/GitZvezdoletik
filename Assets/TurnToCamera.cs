using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToCamera : MonoBehaviour
{
    void Update()
    {
        transform.forward = -(CameraController.instance.transform.position - transform.position);
    }
}
