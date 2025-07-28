using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalText : UpdateTextScorr
{
    protected override void SetAction()
    {
        PlayerData.instance.SetTextCrystal += UpdateText;

        StartCoroutine(UpdateCrystalText());
    }

    IEnumerator UpdateCrystalText()
    {
        int FrameCount = 2;

        while (FrameCount > 0)
        {
            FrameCount--;
            if (FrameCount == 0)
            {
                PlayerData.instance.AddCrystal(0);
            }

            yield return null;
        }
    }
}
