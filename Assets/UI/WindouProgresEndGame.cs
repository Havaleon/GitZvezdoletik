using UnityEngine;

public class WindouProgresEndGame : MonoBehaviour
{
    [SerializeField]
    private TextCounterAnimation ScorrText, MoneyText;


    void Start()
    {
        Initialize();
    }


    private void Initialize()
    {
        ScorrText.SetTargetInt(DataCarrier.Instance.ScorrRun);
        MoneyText.SetTargetInt(DataCarrier.Instance.MoneyRun);
    }

}
