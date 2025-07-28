using UnityEngine;

public enum TypeAnimation
{
    Position = 0,
    Rotation = 1,
    Scale = 2
}

public class Animation_controler_V5 : MonoBehaviour
{
    [SerializeField]
    private TypeAnimation TypeAnimation;

    /*
    [SerializeField]
    private bool Position;
    [SerializeField]
    private bool Rotation;
    [SerializeField]
    private bool Scale;*/

    [Space]
    [Header("Animation")]
    [SerializeField] private float Animation_time;
    public Vector3 Vector_Start, Vector_End;
    [SerializeField] private bool Random_invers_Ptime, Random_Start_Ptime;
    [SerializeField] private bool Destroy_end_time, Disable_end_time, Loop;
    [SerializeField] private float Random_delei_Ptime;
    [SerializeField] private AnimationCurve Pos_Curve;


    private bool on_Play_Animation = false;

    private void OnEnable()
    {
        TimeAnimation = 0f;

        frame_num = 0;

        if (Vector_Start != new Vector3(0f, 0f, 0f))
        {
            on_Play_Animation = true;
        }
        if (Vector_End != new Vector3(0f, 0f, 0f))
        {
            on_Play_Animation = true;
        }
        if (TypeAnimation == TypeAnimation.Position)
        {
            transform.position = Vector_Start;
        }
        if (TypeAnimation == TypeAnimation.Rotation)
        {
            transform.rotation = Quaternion.Euler(Vector_Start);
        }   
        if (TypeAnimation == TypeAnimation.Scale)
        {
            transform.localScale = Vector_Start;
        }


        Enable_Anim();
    }

    private void Enable_Anim()
    {
        if (on_Play_Animation == true)
        {
            if (Random_invers_Ptime == true)
            {
                if (Random.value < 0.5f)
                {
                    invers_Ptime = !invers_Ptime;
                }
            }
            else
            {
                invers_Ptime = false;
            }


            if (Random_Start_Ptime == true)
            {
                Position_time_start = Time.time - Random.Range(0f, Animation_time);
            }
            else
            {
                Position_time_start = Time.time;
            }

            Position_Random_time = Random.Range(0f, Random_delei_Ptime);
        }
    }

    private bool invers_Ptime;

    private float Position_Random_time;

    private float Position_time_start;

    private int frame_num;

    [HideInInspector]
    public float TimeAnimation;
    void Update()
    {
        frame_num++;

        if (on_Play_Animation == true)
        {
            float t = (Time.time - Position_time_start) / (Animation_time + Position_Random_time);
            if (t > 1f)
            {
                if (frame_num > 1)
                {
                    if (Destroy_end_time)
                    {
                        Destroy(gameObject);
                    }

                    if (Disable_end_time)
                    {
                        this.enabled = false;
                        gameObject.SetActive(false);
                    }

                    if(Loop == false)
                    {
                        //this.enabled = false;
                        on_Play_Animation = false;
                    }
                }

                t = 1f;
                Position_time_start = Time.time;
            }
            TimeAnimation = t;


            if (invers_Ptime == true)
            {
                t = 1f - t;
            }


            if (TypeAnimation == TypeAnimation.Position)
            {
                transform.localPosition = Vector3.LerpUnclamped(Vector_Start, Vector_End, Pos_Curve.Evaluate(t));
            }
            else
            if (TypeAnimation == TypeAnimation.Rotation)
            {
                transform.localRotation = Quaternion.Euler(Vector3.LerpUnclamped(Vector_Start, Vector_End, Pos_Curve.Evaluate(t)));
            }
            else
            if (TypeAnimation == TypeAnimation.Scale)
            {
                transform.localScale = Vector3.LerpUnclamped(Vector_Start, Vector_End, Pos_Curve.Evaluate(t));
            }
        }
    }
}
