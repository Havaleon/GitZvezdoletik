using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReyardEndGameProgres : MonoBehaviour
{
    [SerializeField]
    private GameObject MoneyButton, CrystalButton;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        MoneyButton.SetActive(false);
        CrystalButton.SetActive(false);

        if (Random.value < 1f)
        {
            SpawnCrystalButton();
        }
        else
        {
            SpawnMoneyButton();
        }
    }

    private void SpawnButton(GameObject Button, int Reward)
    {
        Button.SetActive(true);

        Button.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText("+" + Reward.ToString());
    }

    private int MoneyReward;
    private void SpawnMoneyButton()
    {
        MoneyReward = 50;
        SpawnButton(MoneyButton, MoneyReward);
    }
    public void ClicMoney()
    {
        PlayerData.instance.AddMoney(MoneyReward);
        MoneyButton.SetActive(false);
    }


    private int CrystalReward;
    private void SpawnCrystalButton()
    {
        CrystalReward = 3;
        SpawnButton(CrystalButton, CrystalReward);
    }
    public void ClicCrystal()
    {
        PlayerData.instance.AddCrystal(CrystalReward);
        CrystalButton.SetActive(false);
    }
}
