using UnityEngine;
using System.Collections;

public class Dead_scr : MonoBehaviour
{
    public static Dead_scr Instance;
    private void Awake()
    {
        Instance = this;
    }


    [SerializeField]
    private GameObject Canvas_Dead;

    private void OnCollisionEnter(Collision collision)
    {
        OnDead(collision);
    }
    private void OnDead(Collision collision)
    {
        //Debug.Log(immortal);
        if (immortal == false
            && collision.gameObject.tag == "obstacle")
        {
            Dead();
        }
        if (immortal == true
            && collision.gameObject.tag == "Obstacle_Edge")
        {
            Dead();

            if (transform.position.x < LVL_Controler.Instance.x_shift_lvl)
            {
                transform.position += new Vector3(3f, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(-3f, 0f, 0f);
            }
        }
    }

    [SerializeField]
    private EndGame_Controller EndGame_Controller;
    private void Dead()
    {
       // Debug.Log("adasda");
        if (ExtraLives <= 0 && BonusExtraLivesBool == false)
        {
            Debug.Log("Dead");
            SaveManager.instance.SaveGame();
            Time.timeScale = 0f;

            EndGame_Controller.UpdateDead();
            Canvas_Dead.SetActive(true);

            StartCoroutine(UpdateDead2());
        }
        else
        {
            if (BonusExtraLivesBool == true)
            {
                BonusExtraLives--;
                if (BonusExtraLives <= 0)
                {
                    BonusExtraLivesBool = false;
                }
            }
            else
            {
                ExtraLives--;
            }
            OnImmortal(1f);
        }
    }
    IEnumerator UpdateDead2()
    {
        int FrameCount = 2;

        while (FrameCount > 0)
        {
            FrameCount--;
            if (FrameCount == 0)
            {
                PlayerData.instance.AddCrystal(0);
            }

            yield return null;
        }
    }


    private void Update()
    {
        UpdateImortal();
        UpdateBonusExtraLives();
    }


    [HideInInspector]
    public int ExtraLives = 0;
    public void AddExtraLives(int AddNumLives, float Duration_ExtraLives)
    {
        ExtraLives += AddNumLives;
    }

    [HideInInspector]
    public bool BonusExtraLivesBool = false;
    [HideInInspector]
    public int BonusExtraLives = 0;
    [HideInInspector]
    public float TimeEndBonusExtraLives;
    public void SetBonusExtraLives(int AddNumLives, float Duration_ExtraLives)
    {
        BonusExtraLivesBool = true;
        BonusExtraLives = AddNumLives;
        TimeEndBonusExtraLives = Time.time + Duration_ExtraLives;
    }
    private void UpdateBonusExtraLives()
    {
        //Debug.Log(BonusExtraLives);
        if (BonusExtraLivesBool == true
            && Time.time > TimeEndBonusExtraLives)
        {
            BonusExtraLives = 0;
        }
    }



    private bool immortal = false;
    private float TimeEndImortal;
    public void OnImmortal(float Duration_Immortal)
    {
        immortal = true;
        TimeEndImortal = Time.time + Duration_Immortal;
    }
    private void UpdateImortal()
    {
        if (immortal == true
            && Time.time > TimeEndImortal)
        {
            immortal = false;
        }
    }
}
