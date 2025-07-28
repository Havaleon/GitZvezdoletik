using UnityEngine;

public class PausButton : MonoBehaviour
{
    [SerializeField]
    private GameObject PausMenuObject;
    private RectTransform PausMenuRect;

    private void Start()
    {
        PausMenuRect = PausMenuObject.GetComponent<RectTransform>();

        PausMenuActive = true;
        PausClic();
    }

    private void Update()
    {
        Animation();
    }

    public void PausClic()
    {
        PausMenuActive = !PausMenuActive;

        if (PausMenuActive)
        {
            Time.timeScale = 0f;
            TargetPos = OnPos;
        }
        else
        {
            Time.timeScale = 1f;
            TargetPos = OffPos;
        }
    }
    
    private bool PausMenuActive = false;

    private Vector3 TargetPos, OnPos = Vector3.zero, OffPos = new Vector3 (0f, 1400f, 0f);

    private void Animation()
    {
        PausMenuRect.anchoredPosition = Vector3.Lerp(PausMenuRect.anchoredPosition, TargetPos, 4f * Time.unscaledDeltaTime);
    }
}
