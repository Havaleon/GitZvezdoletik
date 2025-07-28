using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UpdateTextScorr : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI TextMesh;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        SetAction();
        TextMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string text)
    {
        TextMesh.SetText(text);
    }
    protected abstract void SetAction();
}
