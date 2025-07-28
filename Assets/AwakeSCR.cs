using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeSCR : MonoBehaviour
{
    [SerializeField]
    private int TargetFPS;

    private void Awake()
    {
        LVL();
        Canvases();
        Application.targetFrameRate = TargetFPS;
    }

    [SerializeField]
    private LVL_Controler LVL_Controler;
    private void LVL()
    {
        LVL_Tools.Pools_All.Clear();


        for (int i = 0; i < LVL_Controler.Bonuses.Count; i++)
        {
            LVL_Controler.Bonuses[i].Initialization();
        }
    }

    [SerializeField]
    private CanvasController CanvasController;
    [SerializeField]
    private List<GameObject> StartCanvasesProgres;
    private void Canvases()
    {
        if(DataCarrier.Instance != null
            && DataCarrier.Instance.Start_CanvasEndGameProgres == true)
        {
            DataCarrier.Instance.Start_CanvasEndGameProgres = false;

            CanvasController.StartCanvases = StartCanvasesProgres;
        }
    }
}
