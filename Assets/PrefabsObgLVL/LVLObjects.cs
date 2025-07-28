using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LVLObjects : MonoBehaviour
{
    public float odds_spawn = 1;

    public GameObject ObstacleObg;

    protected abstract void Initialization2();
    public void Initialization()
    {
        Initialization2();
    }


    protected abstract bool Spawn2();
    public bool Spawn()
    {
        return Spawn2();
    }
}
