using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KabinaKosmoleta : MonoBehaviour
{
    private Vector3 LocalPos;

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        
    }
    private void LateUpdate()
    {
        UpdateTransform();
    }

    private void Initialization()
    {
        LocalPos = transform.localPosition;
        transform.parent = null;
    }

    private void UpdateTransform()
    {
        transform.position = LocalPos + player.instance.transform.position;
        transform.rotation = CameraController.instance.transform.rotation;
    }
}
