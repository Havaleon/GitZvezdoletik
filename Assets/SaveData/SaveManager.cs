using UnityEngine;

public class SaveManager : Save_Tools
{
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        LoadGame();

        TimeAutoSave = DurationAutoSave;
    }

    private void Update()
    {
        AutoSave();
    }

    private void LoadGame()
    {
        PlayerData.instance.Money = PlayerPrefs.GetInt(KeyMoney);
        PlayerData.instance.AddMoney(100000000);

        PlayerData.instance.Crystal = PlayerPrefs.GetInt(KeyCrystal);
        PlayerData.instance.AddCrystal(0);

        PlayerData.instance.RecordScorr = PlayerPrefs.GetInt(KeyRecordScorr);
        PlayerData.instance.ScorrUpdate();

        LoadListInt(KeyBonusesLVL, PlayerData.instance.BonusesLVL);

        Debug.Log("Load Game");
    }


    private const string
        KeyMoney = "Money",
        KeyCrystal = "Crystal",
        KeyRecordScorr = "RecordScorr",
        KeyBonusesLVL = "BonusesLVL"
        ;


    public void SaveGame()
    {
        PlayerPrefs.SetInt(KeyCrystal, PlayerData.instance.Crystal);
        PlayerPrefs.SetInt(KeyMoney, PlayerData.instance.Money);

        PlayerPrefs.SetInt(KeyRecordScorr, PlayerData.instance.RecordScorr);

        SaveListInt(KeyBonusesLVL, PlayerData.instance.BonusesLVL);
    }


    private float TimeAutoSave,
    DurationAutoSave = 60f;
    private void AutoSave()
    {
        if (Time.unscaledTime > TimeAutoSave)
        {
            Debug.Log("Auto Save");

            TimeAutoSave = Time.unscaledTime + DurationAutoSave;

            SaveGame();
        }
    }
}
