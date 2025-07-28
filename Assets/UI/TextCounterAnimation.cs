using TMPro;
using UnityEngine;

public class TextCounterAnimation : MonoBehaviour
{
    void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        AnimationInt();
    }

    private TextMeshProUGUI Text;
    private int CurentInt,StartInt , TargetInt;

    public void SetTargetInt(int i)
    {
        TargetInt = i;
        StartInt = CurentInt;

        onAnimation = true;
        StartTimeAnimation = Time.time;
    }

    private bool onAnimation = false;
    private float StartTimeAnimation;
    [SerializeField]
    private float DurationAnimation = 2f;
    private void AnimationInt()
    {
        if (onAnimation == true)
        {
            float t = (Time.time - StartTimeAnimation) / DurationAnimation;

            CurentInt = (int)Mathf.Lerp(StartInt, TargetInt, t);

            Text.SetText(CurentInt.ToString());

            if(t > 1f)
            {
                onAnimation = true;
            }
        }
    }
}
