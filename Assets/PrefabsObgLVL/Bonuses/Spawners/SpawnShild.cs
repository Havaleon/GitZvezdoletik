using UnityEngine;

public class SpawnShild : LVLObjects
{
    protected override void Initialization2()
    {

    }
    protected override bool Spawn2()
    {
        GameObject g = LVL_Tools.Get_Pool(ObstacleObg);

        g.transform.position = LVL_Controler.Instance.Spawn_cursor + new Vector3(0f, 0f, Random.Range(0f, 3f));
        g.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);

        return true;
    }
}
