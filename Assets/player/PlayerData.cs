using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    [SerializeField]
    private TextMeshProUGUI TextMoney, TextMoneyRun, TextScorr;
    private void Awake()
    {
        instance = this;
    }
    [HideInInspector]
    public int Money, MoneyRun, Crystal,
        ScorrRun, RecordScorr;
    [HideInInspector]
    public List<int> BonusesLVL;


    public bool AddMoney(int plus)
    {
        Money += plus;
        if (Money < 0)
        {
            Money -= plus;
            TextMoney.SetText(Money.ToString());

            return false;
        }

        TextMoney.SetText(Money.ToString());

        AddMoneyRun(plus);
        return true;
    }
    private void AddMoneyRun(int plus)
    {
        if (player.instance.enabled == true)
        {
            MoneyRun += plus;

            TextMoneyRun.SetText(MoneyRun.ToString());
        }
    }


    public event Action<string> SetTextCrystal;
    public bool AddCrystal(int plus)
    {
        Crystal += plus;
        if (Crystal < 0)
        {
            Crystal -= plus;

            SetTextCrystal?.Invoke(Crystal.ToString());
            return false;
        }
        SetTextCrystal?.Invoke(Crystal.ToString());
        return true;
    }


    public event Action<string> SetTextRecord;
    public void ScorrUpdate()
    {
        ScorrRun = (int)player.instance.transform.position.z + 10;

        TextScorr.SetText(ScorrRun.ToString());

        if (RecordScorr < ScorrRun)
        {
            RecordScorr = ScorrRun;
        }

        SetTextRecord?.Invoke(RecordScorr.ToString());
    }


    public int GetLVLBonus(BonusType BonusType)
    {
        while (true)
        {
            if (BonusesLVL.Count < (int)BonusType + 1)
            {
                BonusesLVL.Add(0);
            }
            else
            {
                break;
            }
        }
        return BonusesLVL[(int)BonusType];
    }
}


public enum BonusType
{
    Null = 0,
    Shild = 1,
    Speed = 2,
    Deceleration = 3,
    Shooting = 4
}