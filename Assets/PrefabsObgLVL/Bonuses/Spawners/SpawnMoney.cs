using UnityEngine;

public class SpawnMoney : LVLObjects
{
    protected override void Initialization2()
    {
        
    }

    [SerializeField]
    private GameObject Crystal;

    private float localOdds = 0f;
    protected override bool Spawn2()
    {
        //Debug.Log("inst Money");
        if (Random.value < localOdds)
        {
            GameObject g;

            if (Random.value < 0.0025f)
            {
                g = LVL_Tools.Get_Pool(Crystal);
            }
            else
            {
                g = LVL_Tools.Get_Pool(ObstacleObg);
            }


            g.transform.position = LVL_Controler.Instance.Spawn_cursor + new Vector3(0f, 0f, UnityEngine.Random.Range(0f, 3f));
            g.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);

            localOdds -= 0.6f;

            return true;
        }
        else
        {
            localOdds += 0.4f;
        }

        return false;
    }
}
