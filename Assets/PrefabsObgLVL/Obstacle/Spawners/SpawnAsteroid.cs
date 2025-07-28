using UnityEngine;

public class SpawnAsteroid : LVLObjects
{
    protected override void Initialization2()
    {
        
    }

    public GameObject asteroid_Edge;

    protected override bool Spawn2()
    {
        GameObject g = LVL_Tools.Get_Pool(ObstacleObg);
        g.transform.position = LVL_Controler.Instance.Spawn_cursor + new Vector3(0f, (LVL_Controler.Instance.positionY_weight.Evaluate(UnityEngine.Random.value) * 0.4f) - 0.2f, UnityEngine.Random.Range(0f, 3f));
        g.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);

        return true;
    }
}
