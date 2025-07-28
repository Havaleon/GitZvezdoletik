using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas_Dead;
    [SerializeField]
    private Image ImageTimer;
    public void UpdateDead()
    {
        TextCrystalButton.SetText(PriceCrystalRespawn + " кристал");
        ImageTimer.fillAmount = 1f;
        TimeStartTimer = Time.unscaledTime;
    }
    private void Update()
    {
        TimerAnimation();
    }

    private float TimeStartTimer, DurationTimer = 15f;
    private void TimerAnimation()
    {
        float t = ((TimeStartTimer + DurationTimer) - Time.unscaledTime) / DurationTimer;

        ImageTimer.fillAmount = t;

        if (t < 0f
            && Canvas_Dead.activeSelf == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private int CountRevardVideoContinue = 3;
    [SerializeField]
    private GameObject ButtonRevardVideoContinue;
    public void RevardVideoContinue()
    {
        if (CountRevardVideoContinue > 0)
        {
            Respawn();
            CountRevardVideoContinue--;

            if(CountRevardVideoContinue <= 0)
            {
                Destroy(ButtonRevardVideoContinue);
            }
        }
    }

    private int PriceCrystalRespawn = 1;
    [SerializeField]
    private TextMeshProUGUI TextCrystalButton;
    public void CrystalContinue()
    {
        if (PlayerData.instance.AddCrystal(-PriceCrystalRespawn) == true)
        {
            Respawn();
            PriceCrystalRespawn++;
        }
    }


    [SerializeField]
    private Dead_scr dead_Scr;
    private void Respawn()
    {
        dead_Scr.OnImmortal(5f);
        Canvas_Dead.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void ExitMenu()
    {
        DataCarrier.Instance.Start_CanvasEndGameProgres = true;
        DataCarrier.Instance.ScorrRun = PlayerData.instance.ScorrRun;
        DataCarrier.Instance.MoneyRun = PlayerData.instance.MoneyRun;

        SceneManager.LoadScene(0);
    }
}
