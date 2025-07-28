using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagneticWind : LVLObjects
{

    protected override void Initialization2()
    {

    }

    protected override bool Spawn2()
    {
        SpawnWind();

        return true;
    }


    private void SpawnWind()
    {
        GameObject g = LVL_Tools.Get_Pool(ObstacleObg);

        Vector3 pos = LVL_Controler.Instance.Spawn_cursor + new Vector3(1.5f, 0f, Random.Range(0f, 3f));
        g.transform.position = pos;
        Vector3 rot = new Vector3(0f,Random.Range(80f, 100f),0f);
        if (Random.value < 0.5f) rot *= -1f;
        g.transform.rotation = Quaternion.Euler(rot);

        //LVL_Controler.Instance.Spawn_cursor.x += 2f;
    }
}
