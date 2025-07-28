using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCarrier : MonoBehaviour
{
    public static DataCarrier Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [HideInInspector]
    public bool Start_CanvasEndGameProgres = false;

    [HideInInspector]
    public int ScorrRun, MoneyRun;
}
