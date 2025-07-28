using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve AnimationCurve;

    private void Awake()
    {
        Initialize();
    }

    public List<GameObject> StartCanvases;
    private void Initialize()
    {
        All_Canvas = new List<CanvasScr>();
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform trans = transform.GetChild(i);
            trans.AddComponent<CanvasScr>();

            CanvasScr canvasScr = trans.GetComponent<CanvasScr>();
            canvasScr.CodCanvas = i;
            canvasScr.AnimationCurve = AnimationCurve;

            All_Canvas.Add(canvasScr);
            All_Canvas[i].Initialize();
        }


        List<int> canvasesStartCods = new List<int>();
        for (int i = 0; i < StartCanvases.Count; i++)
        {
            canvasesStartCods.Add(StartCanvases[i].GetComponent<CanvasScr>().CodCanvas);
        }
        SetCanvases(canvasesStartCods);
    }


    private List<CanvasScr> All_Canvas;
    public void SetCanvases(List<int> CodsCanvas)
    {
        for (int i = 0; i < All_Canvas.Count; i++)
        {
            if (CodsCanvas.Contains(All_Canvas[i].CodCanvas))
            {
                All_Canvas[i].EnableCanvas();
            }
            else
            {
                All_Canvas[i].DisableCanvas();
            }
        }
    }
}
