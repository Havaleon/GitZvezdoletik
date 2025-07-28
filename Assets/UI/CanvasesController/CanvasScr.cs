using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasScr : MonoBehaviour
{
    [HideInInspector]
    public int CodCanvas;

    [HideInInspector]
    public AnimationCurve AnimationCurve;
    private List<CanvasElement> CanvasElements;
    public void Initialize()
    {
        CanvasElements = new List<CanvasElement>();

        for (int i = 0; i < transform.childCount; i++)
        {
            CanvasElement canvasElement = transform.GetChild(i).AddComponent<CanvasElement>();
            canvasElement.DurationAnimation = DurationAnimation;
            canvasElement.AnimationCurve = AnimationCurve;
            canvasElement.Initialized();
            CanvasElements.Add(canvasElement);
        }
    }
    private void Update()
    {
        AnimationUpdate();
    }


    private float DurationAnimation = 0.5f;
    public void EnableCanvas()
    {
        if(gameObject.name == "Canvas_Run")
        {
            Debug.Log("Canvas_Run trye " + CodCanvas);
        }

        gameObject.SetActive(true);
        OnAnimationDisable = false;
        for (int i = 0; i < CanvasElements.Count; i++)
        {
            CanvasElements[i].OnEnableAnimation();
        }
    }

    public void DisableCanvas()
    {
        OnAnimationDisable = true;
        StartTimeAnimation = Time.time;
        for (int i = 0; i < CanvasElements.Count; i++)
        {
            CanvasElements[i].OnDisableAnimation();
        }
    }

    private bool OnAnimationDisable;
    private float StartTimeAnimation;
    private void AnimationUpdate()
    {
        if (OnAnimationDisable == true)
        {
            float t = (Time.time - StartTimeAnimation) / DurationAnimation;

            if(t > 1f)
            {
                gameObject.SetActive(false);
                OnAnimationDisable = false;

                if (gameObject.name == "Canvas_Run")
                {
                    Debug.Log("Canvas_Run false " + CodCanvas);
                }
            }
        }
    }
}