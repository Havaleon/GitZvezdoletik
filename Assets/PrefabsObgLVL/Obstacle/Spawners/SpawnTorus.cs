using UnityEngine;

public class SpawnTorus : LVLObjects
{

    protected override void Initialization2()
    {

    }

    protected override bool Spawn2()
    {
        if (Random.value < 0.75f)
        {
            SpawnTorus1();

        }
        else
        {
            SpawnTorus2();
        }

        return true;
    }



    private void SpawnTorus1()
    {
        GameObject g = LVL_Tools.Get_Pool(ObstacleObg);
        DataObstacl dataObstacl = g.GetComponent<DataObstacl>();

        Vector3 pos = LVL_Controler.Instance.Spawn_cursor + new Vector3(1.5f, 0f, Random.Range(0f, 3f));
        g.transform.position = pos;

        LVL_Controler.Instance.Spawn_cursor.x += 2f;

        GameObject model = g.GetComponent<DataObstacl>().Model;
        model.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

    }

    [SerializeField]
    private GameObject Torus2;

    private void SpawnTorus2()
    {
        GameObject g = LVL_Tools.Get_Pool(Torus2);
        DataObstacl dataObstacl = g.GetComponent<DataObstacl>();

        Vector3 pos = LVL_Controler.Instance.Spawn_cursor + new Vector3(2.5f, 0f, Random.Range(0f, 3f));
        g.transform.position = pos;


        GameObject model = g.GetComponent<DataObstacl>().Model;
        model.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));



        LVL_Controler.Instance.Spawn_cursor.x += 4f;
    }
}
