using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasElement : MonoBehaviour
{
    private Vector3 EnablePos;
    private Vector3 DisablePos;
    public void Initialized()
    {
        gameObject.SetActive(true);

        EnablePos = transform.position;

        Vector3 pos = transform.position;

        if (pos.x < Screen.width / 3f)
        {
            DisablePos = EnablePos + new Vector3(-Screen.width, 0f, 0f);
        }
        else
        if (pos.x > (Screen.width / 3) * 2)
        {
            DisablePos = EnablePos + new Vector3(Screen.width, 0f, 0f);
        }
        else
        {
            if (pos.y > Screen.height / 2f)
            {
                DisablePos = EnablePos + new Vector3(0f, Screen.height, 0f);
            }
            else
            {
                DisablePos = EnablePos + new Vector3(0f, -Screen.height, 0f);
            }

        }
    }

    void Update()
    {
        AnimationUpdate();
    }
    
    private void OnAnimation()
    {
        OnAnimationBool = true;
        StartTimeAnimation = Time.time;

        StartPos = transform.position;
    }
    public void OnDisableAnimation()
    {
        OnAnimation();

        TargetPos = DisablePos;
    }
    public void OnEnableAnimation()
    {
        OnAnimation();

        TargetPos = EnablePos;
    }


    private bool OnAnimationBool = false;

    [HideInInspector]
    public float DurationAnimation;
    private float StartTimeAnimation;

    private Vector3 StartPos, TargetPos;

    [HideInInspector]
    public AnimationCurve AnimationCurve;
    private void AnimationUpdate()
    {
        if (OnAnimationBool == true)
        {
            float t = (Time.time - StartTimeAnimation) / DurationAnimation;

            transform.position = Vector3.LerpUnclamped(StartPos, TargetPos, AnimationCurve.Evaluate(t));

            if(t > 1f)
            {
                OnAnimationBool = false;
            }
        }
    }
}
