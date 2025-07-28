using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroier : MonoBehaviour
{
    private GameObject Parent;

    private void Start()
    {
        Parent = transform.parent.gameObject;
    }


    private void Update()
    {
        if (transform.position.z < player.inst.Pos.z - 5f)
        {
            Parent.SetActive(false);
        }
    }
}
