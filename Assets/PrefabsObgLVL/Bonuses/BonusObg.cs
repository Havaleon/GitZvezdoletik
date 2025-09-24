using UnityEngine;


public class BonusObg : MonoBehaviour
{
    private int LVL;
    [HideInInspector]
    public float Duration = 10f;

    public GameObject ParentObg;
    [SerializeField]
    private GameObject IndicatorTimeUI;

    private void Awake()
    {
        Initialize();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        AnimationTakeEnable();
    }

    private void Update()
    {
        AnimationTake();
    }

    [SerializeField]
    private BonusType BonusType;
    private void Initialize()
    {
        LVL = PlayerData.instance.GetLVLBonus(BonusType);
        Duration = 10f + LVL;
    }


    public void AddIndicator(float duration)
    {
        if (UIControler.Instance.CurentIndicators.Contains(IndicatorTimeUI.name + "(Clone)") == false)
        {
            GameObject g = LVL_Tools.Get_Pool(IndicatorTimeUI);
            g.transform.parent = UIControler.Instance.ContentIndicators;

            g.transform.GetChild(0).GetComponent<IndicatorBonus>().DurationBonus = duration;

            UIControler.Instance.CurentIndicators.Add(g.name);
        }
        else
        {
            UIControler.Instance.ContentIndicators.Find(IndicatorTimeUI.name + "(Clone)").
                GetChild(0).GetComponent<IndicatorBonus>().TimeStart = Time.time;
        }
    }


    private bool OnAnimation = false;

    private float TimeEndTakeAnimation, TimeDurationTakeAnimation = 0.9f;
    private Vector3 StartPos, StartScale;

    private void AnimationTakeEnable()
    {
        if (OnAnimation == false)
        {
            AnimationTakePos = AnimationTakePos ?? StaticDataBonus.instans.AnimationTakePos;
            AnimationTakeScale = AnimationTakeScale ?? StaticDataBonus.instans.AnimationTakeScale;
            AnimationTakePosY = AnimationTakePosY ?? StaticDataBonus.instans.AnimationTakePosY;

            OnAnimation = true;
            ParentObg.transform.parent = player.instance.transform;
            StartPos = ParentObg.transform.localPosition;
            TimeEndTakeAnimation = Time.time + TimeDurationTakeAnimation;
            StartScale = ParentObg.transform.localScale;
        }
    }

    private void AnimationTakeDisable()
    {
        OnAnimation = false;
        ParentObg.SetActive(false);

        ParentObg.transform.parent = null;
    }
    private static AnimationCurve AnimationTakePos, AnimationTakeScale, AnimationTakePosY;
    private void AnimationTake()
    {
        if (OnAnimation)
        {
            float t = (TimeEndTakeAnimation - Time.time) / TimeDurationTakeAnimation;
            if (t < 0f) AnimationTakeDisable();

            Vector3 pos = Vector3.Lerp(new Vector3(0f,0f,0f), StartPos, AnimationTakePos.Evaluate(t));
            pos.y = AnimationTakePosY.Evaluate(1f - t) * -0.2f;

            Vector3 scale = Vector3.Lerp(new Vector3(0f, 0f, 0f), StartScale, AnimationTakeScale.Evaluate(t));

            ParentObg.transform.localPosition = pos;
            ParentObg.transform.localScale = scale;
        }
    }
}
