using TMPro;
using UnityEngine;

public class FormUpgradeCard : MonoBehaviour
{
    [SerializeField]
    private BonusType BonusType;
    [SerializeField]
    private TextMeshProUGUI TextHeading, TextLVL, PriceText;
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UpdatePrice();
        UpdateText();
    }

    private void UpdateText()
    {
        TextLVL.SetText((1 + PlayerData.instance.GetLVLBonus(BonusType)).ToString());

        PriceText.SetText(Price.ToString());
    }
    private int Price;
    private void UpdatePrice()
    {
        Price = (1 + PlayerData.instance.GetLVLBonus(BonusType)) * 100;
    }

    public void Upgrade()
    {
        if (PlayerData.instance.AddMoney(-Price))
        {
            PlayerData.instance.BonusesLVL[(int)BonusType] += 1;
            Debug.Log(BonusType);
            UpdatePrice();
            UpdateText();

            SaveManager.instance.SaveGame();
        }
    }
}
