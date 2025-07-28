using UnityEngine;

public class SpawnLongObstacle : LVLObjects
{
    protected override void Initialization2()
    {

    }

    protected override bool Spawn2()
    {
        if (Random.value < 0.75f)
        {
            SpawnLong_2();
        }
        else
        {
            SpawnLong_3();
        }

        return true;
    }

    private void SpawnLongPrefab(GameObject g, float size)
    {
        g = LVL_Tools.Get_Pool(g);
        DataObstacl dataObstacl = g.GetComponent<DataObstacl>();

        Vector3 Localpos = Vector3.zero;
        Vector3 posModel = Vector3.zero;


        float RandomRangeSize = size / 2;
        Localpos.x = Random.Range(-RandomRangeSize, RandomRangeSize);


        posModel.x = -Localpos.x;
        dataObstacl.Model.transform.localPosition = posModel;


        Localpos.y = (LVL_Controler.Instance.positionY_weight.Evaluate(Random.value) * 0.4f) - 0.2f;
        Localpos.z = Random.Range(0f, 3f);


        g.transform.position = LVL_Controler.Instance.Spawn_cursor + Localpos;
        dataObstacl.Model.transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        g.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);


        LVL_Controler.Instance.Spawn_cursor.x += size - 1f;
    }
    private void SpawnLong_2()
    {
        SpawnLongPrefab(ObstacleObg, 2f);
    }


    [SerializeField]
    private GameObject LongObstacle_3;
    private void SpawnLong_3()
    {
        SpawnLongPrefab(LongObstacle_3, 3f);
    }
}
