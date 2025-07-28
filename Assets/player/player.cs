using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player inst;
    [HideInInspector]
    public Vector3 Pos;
    private void Awake()
    {
        inst = this;
    }


    private void OnEnable()
    {
        Speed = Vector3.zero;
    }

    void Update()
    {
        UpdateSpeedBonus();
        UpdateShooting();
        Move();
    }

    [HideInInspector]
    public Vector3 Speed_Max = new Vector3(5f, 0f, 5f);
    private Vector3 Speed;
    private float Speed_x_value, boost = 4f, boost_value = 0.8f;


    private bool Move_x = false;
    private void Move()
    {
        Pos = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Move_x = true;
        }

        if (Move_x == true)
        {
            if (Input.mousePosition.x < Screen.width / 2f)
            {
                if (Speed_x_value > -1f)
                {
                    Speed_x_value += -boost_value * Time.deltaTime;
                }
            }
            else
            {
                if (Speed_x_value < 1f)
                {
                    Speed_x_value += boost_value * Time.deltaTime;
                }
            }
        }
        if (Speed_x_value > 1f)
        {
            Speed_x_value = 1f;
        }
        if (Speed_x_value < -1f)
        {
            Speed_x_value = -1f;
        }


        if (Input.GetMouseButtonUp(0))
        {
            Move_x = false;
        }

        if (Move_x == false)
        {
            if (Speed_x_value > 0f)
            {
                Speed_x_value -= Mathf.Lerp(0f, boost * 0.75f, Speed_x_value) * Time.deltaTime;
            }
            else
            {
                Speed_x_value += Mathf.Lerp(0f, boost * 0.75f, Speed_x_value * -1f) * Time.deltaTime;
            }
        }

        Speed.x = Speed_Max.x * Speed_x_value;


        float value_x = Speed_x_value;
        if (value_x < 0f)
        {
            value_x *= -1f;
        }
        Speed.z = Mathf.Lerp(Speed_Max.z, Speed_Max.z * 0.75f, value_x);

        ApplySpeed();


        PlayerData.instance.ScorrUpdate();
        CameraController.instance.CameraMove(Speed_x_value);
    }


    private Dictionary<string, SpeedCoef> CoeffsSpeed = new Dictionary<string, SpeedCoef>()
    {
        // Boost, Time
        {"Boost", new SpeedCoef()},//1 Boost
        {"Deceleration", new SpeedCoef()}//2 Deceleration
    };

    private float SpeedBonusCoeffCurrent = 1f;
    public void OnSpeedBonus(float ÌultiplySpeed, float Duration)
    {
        CoeffsSpeed["Boost"].Coeff = ÌultiplySpeed;
        CoeffsSpeed["Boost"].TimeEnd = Time.time + Duration;
    }
    public void OnDecelerationBonus(float ÌultiplySpeed, float Duration)
    {
        CoeffsSpeed["Deceleration"].Coeff = ÌultiplySpeed;
        CoeffsSpeed["Deceleration"].TimeEnd = Time.time + Duration;
    }
    private void UpdateSpeedBonus()
    {
        for (int i = CoeffsSpeed.Count - 1; i >= 0; i--)
        {
            if (Time.time > CoeffsSpeed.ElementAt(i).Value.TimeEnd)
            {
                if (i < 2)
                {
                    CoeffsSpeed.ElementAt(i).Value.Coeff = 0f;
                }
                else
                {
                    CoeffsSpeed.Remove(CoeffsSpeed.ElementAt(i).Key);
                }
            }
        }

        float CoefSpeedTarget = 0f;

        for (int i = CoeffsSpeed.Count - 1; i >= 0; i--)
        {
            CoefSpeedTarget += CoeffsSpeed.ElementAt(i).Value.Coeff;
        }

        SpeedBonusCoeffCurrent = 1f + Mathf.MoveTowards(SpeedBonusCoeffCurrent - 1f, CoefSpeedTarget, 0.25f * Time.deltaTime);
    }

    [HideInInspector]
    public Vector3 EndSpeed;
    private void ApplySpeed()
    {
        float t1 = Pos.z / 10000f;
        float spead_boost = Mathf.LerpUnclamped(1f, 2f, t1);

        EndSpeed = Speed * SpeedBonusCoeffCurrent * spead_boost;
        transform.position += EndSpeed * Time.deltaTime;

        //Debug.Log(EndSpeed * Time.deltaTime);
    }

    private float EndTimeShoting;
    [SerializeField]
    private GameObject ObgShoting;
    public void OnShooting(float Duration)
    {
        EndTimeShoting = Time.time + Duration;
        ObgShoting.SetActive(true);
    }
    private void UpdateShooting()
    {
        if (Time.time > EndTimeShoting)
        {
            ObgShoting.SetActive(false);
        }
    }


    /*
    [SerializeField]
    private Transform Camera_transform;
    [SerializeField]
    private Camera Camera_Component;

    private Vector3 Camera_rot_min = Vector3.zero,
        Camera_rot_max = new Vector3(0f, 2f, -10f),
        Camera_rot_current = Vector3.zero;

    private void Camera_Controler(float value)
    {
        Vector3 rot = Vector3.LerpUnclamped(Camera_rot_min, Camera_rot_max, value);
        Camera_rot_current = Vector3.Lerp(Camera_rot_current, rot, 4f * Time.deltaTime);
        Camera_transform.rotation = Quaternion.Euler(Camera_rot_current);


        float value_positive = value;
        if (value_positive < 0f) value_positive *= -1f;


        float Field = Mathf.Lerp(60f, 50f, value_positive);

        Camera_Component.fieldOfView = Mathf.Lerp(Camera_Component.fieldOfView, Field, 4f * Time.deltaTime);


    }
    
    */
}

public class SpeedCoef
{
    public float TimeEnd,
        Coeff;
}


