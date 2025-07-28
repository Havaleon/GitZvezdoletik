using UnityEngine;


public class BonusObg : MonoBehaviour
{
    private int LVL;
    [HideInInspector]
    public float Duration = 10f;

    public GameObject ParentObg;
    [SerializeField]
    private GameObject Indicator;

    private void Awake()
    {
        Initialize();
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
        if (UIControler.Instance.CurentIndicators.Contains(Indicator.name + "(Clone)") == false)
        {
            //(Clone)
            GameObject g = LVL_Tools.Get_Pool(Indicator);
            g.transform.parent = UIControler.Instance.ContentIndicators;

            g.transform.GetChild(0).GetComponent<IndicatorBonus>().DurationBonus = duration;

            UIControler.Instance.CurentIndicators.Add(g.name);
        }
        else
        {
            //g.transform.GetChild(0).GetComponent<IndicatorBonus>().DurationBonus = duration;

            UIControler.Instance.ContentIndicators.Find(Indicator.name + "(Clone)").
                GetChild(0).GetComponent<IndicatorBonus>().TimeStart = Time.time;
        }
    }
}
