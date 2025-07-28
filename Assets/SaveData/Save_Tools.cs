using System.Collections.Generic;
using UnityEngine;

public class Save_Tools : MonoBehaviour
{

    public void SaveListInt(string key, List<int> list)
    {
        PlayerPrefs.SetInt(key + 0, list.Count);

        for (int i = 1; i < list.Count; i++)
        {
            PlayerPrefs.SetInt(key + i, list[i]);
        }
    }

    public void LoadListInt(string key, List<int> list)
    {
        list.Clear();

        list.Add(PlayerPrefs.GetInt(key + 0));

        for (int i = 1; i < list[0]; i++)
        {
            list.Add(PlayerPrefs.GetInt(key + i));
        }
    }

}
