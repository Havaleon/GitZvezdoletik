using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOnClickCanvases : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Canvases;

    void Start()
    {
        SetCanvases();
    }

    private void SetCanvases()
    {
        CanvasController canvasController = GameObject.Find("Canvases").GetComponent<CanvasController>();

        Button button = GetComponent<Button>();

        List<int> canvasesScr = new List<int>();
        for (int i = 0; Canvases.Count > i; i++)
        {
            canvasesScr.Add(Canvases[i].GetComponent<CanvasScr>().CodCanvas);
        }

        button.onClick.AddListener(() => canvasController.SetCanvases(canvasesScr));
    }
}
