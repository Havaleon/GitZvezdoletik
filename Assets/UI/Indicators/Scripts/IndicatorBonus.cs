using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorBonus : MonoBehaviour
{
    private GameObject Parent;
    private void Awake()
    {
        Parent = transform.parent.gameObject;
    }

    private void OnEnable()
    {
        TimeStart = Time.time;
    }
    private void OnDisable()
    {
        UIControler.Instance.CurentIndicators.Remove(Parent.name);
    }

    private void Update()
    {
        Animation();
    }

    [HideInInspector]
    public float DurationBonus;
    [HideInInspector]
    public float TimeStart;
    [SerializeField]
    private Image ProgressBar;

    private void Animation()
    {
        float t = (Time.time - TimeStart) / DurationBonus;

        ProgressBar.fillAmount = 1f - t;

        if(t > 1f)
        {
            Parent.SetActive(false);
        }
    }
}
