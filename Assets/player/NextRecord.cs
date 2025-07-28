using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextRecord : MonoBehaviour
{
    private void Awake()
    {
        TextNextRecord = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UpdateNextRecord();
    }

    private TextMeshProUGUI TextNextRecord;
    private void UpdateNextRecord()
    {
        int ScorrNextRecord = PlayerData.instance.RecordScorr - PlayerData.instance.ScorrRun;

        TextNextRecord.SetText("Всего <color=#e16510>" + ScorrNextRecord + "</color> очков до <color=#e16510>нового рекорда</color>!");
    }

}
