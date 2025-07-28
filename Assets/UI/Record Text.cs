using UnityEngine;
using UnityEngine.Events;

public class RecordText : UpdateTextScorr
{
    protected override void SetAction()
    {
       PlayerData.instance.SetTextRecord += UpdateText;
    }
}
