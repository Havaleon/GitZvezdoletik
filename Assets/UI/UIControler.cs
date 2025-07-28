using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public static UIControler Instance;
    private void Awake()
    {
        Instance = this;
    }


    public Transform ContentIndicators;
    [HideInInspector]
    public List<string> CurentIndicators;
}
