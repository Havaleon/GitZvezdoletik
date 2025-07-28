using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LVL_Tools : MonoBehaviour
{

    public static Dictionary<GameObject, List<GameObject>> Pools_All = new Dictionary<GameObject, List<GameObject>>();
    public static GameObject Get_Pool(GameObject obj)
    {
        if (Pools_All.ContainsKey(obj) == false)
        {
            Pools_All[obj] = new List<GameObject>();
        }

        for (int i = 0; i < Pools_All[obj].Count; i++)
        {

            if (Pools_All[obj][i].activeSelf == false)
            {
                GameObject p = Pools_All[obj][i];

                p.SetActive(true);
                return p;
            }
        }

        GameObject g = Instantiate(obj);
        Pools_All[obj].Add(g);
        g.SetActive(true);
        return g;

    }
    /*
    [SerializeField]
    private SerializedDictionary<GameObject, float> Enemi_All;
    private GameObject odds_Enemy()
    {
        Dictionary<GameObject, float> clon_Dict = Enemi_All;

        return for_odds(clon_Dict);
    }*/
    public static GameObject for_odds(Dictionary<GameObject, float> clon_Dict)
    {
        float r = Random.Range(0f, clon_Dict.Values.Sum());
        float odds_num = 0;

        for (int i = 0; i < clon_Dict.Count; i++)
        {
            odds_num += clon_Dict.ElementAt(i).Value;

            if (r < odds_num)
            {
                return clon_Dict.ElementAt(i).Key;

                /*
                if (Indivdual_Odds(clon_Dict.ElementAt(i).Key) == true)
                {
                    return clon_Dict.ElementAt(i).Key;
                }
                else
                {
                    clon_Dict.Remove(clon_Dict.ElementAt(i).Key);
                    return for_odds(clon_Dict);
                }*/
            }
        }


        //return clon_Dict.ElementAt(0).Key;
        return null;
    }

    /*
    private static bool Indivdual_Odds(GameObject gameObject)
    {
        switch (gameObject.name)
        {


            
            case "Bomba":
                Enemi_All[gameObject] = Enemi_All[gameObject] / 10;
                return true;

            case "Heal":
                if (LVL_Controller.LVL_progres / LVL_Controller.LVL_Up_step > 2)
                {
                    Enemi_All[gameObject] = Enemi_All[gameObject] / 10;
                    return true;
                }
                return false;



            case "Shark":

                if (LVL_Controller.LVL_progres / LVL_Controller.LVL_Up_step > 1)
                {
                    List<Vector2> pos_shark = new List<Vector2>
                    {
                    new Vector2 (square_size,0f),
                    new Vector2 (-square_size,0f),
                    };

                    List<Vector2> new_pos_shark = new List<Vector2>();

                    for (int i = pos_shark.Count - 1; i > -1; i--)
                    {
                        int n = Random.Range(0, pos_shark.Count);

                        new_pos_shark.Add(pos_shark[n]);
                        pos_shark.RemoveAt(n);
                    }

                    for (int i = new_pos_shark.Count - 1; i > -1; i--)
                    {
                        if (pole.Contains(pos_Enemy + new_pos_shark[i]) == true)
                        {
                            pole.Remove(pos_Enemy + new_pos_shark[i]);

                            if (new_pos_shark[i].x < 0f)
                            {
                                pos_Enemy_Plus = new Vector2(-square_size, 0f);
                            }

                            return true;
                        }
                    }
                }
                return false;

        }

        return true;
    }*/

}
