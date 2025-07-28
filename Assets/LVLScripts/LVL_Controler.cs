using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LVL_Controler : MonoBehaviour
{
    public static LVL_Controler Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Spawn_cursor = new Vector3(-x_size_lvl - x_size_edge, 0f, 0f);
    }

    [SerializeField]
    private Transform Player_transform;

    [HideInInspector]
    public Vector3 Spawn_cursor;

    void Update()
    {
        Generation();
    }

    [HideInInspector]
    public float Spawn_Odds = 1f,
        x_size_lvl = 10f,
        x_size_edge = 5f,
        x_shift_lvl;


    public AnimationCurve odds_weight,
        positionY_weight,
        curve_odds;
    private void Generation()
    {
        if (Spawn_cursor.z < Player_transform.position.z + 20f)
        {
            if (Spawn_cursor.x > -x_size_lvl + x_shift_lvl
                && Spawn_cursor.x < x_size_lvl + x_shift_lvl
                )
            {
                SpawnObstacle();
            }
            else
            {
                Spawn_Edge();
            }



            Spawn_cursor.x += 1f + (odds_weight.Evaluate(UnityEngine.Random.value) * 0.5f);
            if (Spawn_cursor.x > (x_size_lvl + x_size_edge) + x_shift_lvl)
            {
                x_shift_lvl += UnityEngine.Random.Range(-3f, 3f);


                Spawn_cursor.x = (-x_size_lvl - x_size_edge) + x_shift_lvl;
                Spawn_cursor.z += 5f;


                period_num++;
                if (period_num > period_next)
                {
                    period_old = period_next;

                    float period_next_plus = period_next_num + UnityEngine.Random.Range(period_min, period_max);
                    //Debug.Log(period_next_plus);

                    period_next += period_next_plus;

                    period_next_num++;
                }
                period_current = (period_num - period_old) / (period_next - period_old);
            }
        }
    }

    private float period_num,
        period_old,
        period_next,
        period_next_num,
        period_current,

        period_min = 0, period_max = 30;

    [Space]
    [Header("Obstacles")]
    [SerializeField]
    private List<LVLObjects> Obstacles;


    private void SpawnObstacle()
    {
        if (Random.value < Spawn_Odds)
        {
            if (Random.value < curve_odds.Evaluate(period_current)
                && Random.value < period_num / 15f
                )
            {
                SpawnLVLObjects(Obstacles);
            }

            Spawn_Odds -= 0.2f;
        }
        else
        {
            SpawnLVLObjects(Bonuses);
            Spawn_Odds += 0.25f;
        }
    }

    [Space]
    [Header("Bonuses")]
    public List<LVLObjects> Bonuses;
    private void SpawnLVLObjects(List<LVLObjects> array)
    {
        float sum = 0;

        for (int i = 0; i < array.Count; i++)
        {
            sum += array[i].odds_spawn;
        }

        float r = Random.Range(0f, sum);
        float e = 0;
        for (int i = 0; i < array.Count; i++)
        {
            e += array[i].odds_spawn;
            if (r < e)
            {
                array[i].Spawn();
                break;
            }
        }
    }


    private void Spawn_Edge()
    {
        GameObject g = Obstacles[0].GetComponent<SpawnAsteroid>().ObstacleObg;


        if (Spawn_cursor.x < x_shift_lvl)
        {
            if (Spawn_cursor.x < x_shift_lvl - (x_size_lvl + x_size_edge - 3f))
            {
                g = Obstacles[0].GetComponent<SpawnAsteroid>().asteroid_Edge;
            }
        }
        else
        {
            if (Spawn_cursor.x > x_shift_lvl + (x_size_lvl + x_size_edge - 3f))
            {
                g = Obstacles[0].GetComponent<SpawnAsteroid>().asteroid_Edge;
            }
        }


        for (int i = 0; i < 5; i++)
        {
            g = LVL_Tools.Get_Pool(g);
            g.transform.position = Spawn_cursor + new Vector3(0f, (positionY_weight.Evaluate(Random.value) * 0.4f) - 0.2f, i);
            g.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);
        }
    }

}
