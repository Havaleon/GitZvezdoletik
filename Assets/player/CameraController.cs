using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        initialize();
    }
    private void Update()
    {
        ShakeUpdate();
    }

    private void initialize()
    {
        CameraTransform = transform;
        CameraComponent = GetComponent<Camera>();
    }

    private Transform CameraTransform;
    private Camera CameraComponent;

    private Vector3 CameraRotMin = Vector3.zero,
        CameraRotMax = new Vector3(0f, 2f, -10f),
        CameraRotCurrent = Vector3.zero,
        CameraPos = Vector3.zero;

    public void CameraMove(float valueX)
    {
        Vector3 rot = Vector3.LerpUnclamped(CameraRotMin, CameraRotMax, valueX);
        CameraRotCurrent = Vector3.Lerp(CameraRotCurrent, rot, 4f * Time.deltaTime);
        CameraTransform.rotation = Quaternion.Euler(CameraRotCurrent);
        CameraTransform.localPosition = CameraPos;

        float value_positive = valueX;
        if (value_positive < 0f) value_positive *= -1f;

        //60 50


        //80 70 нормальная скорость
        //90 80 ускорение
        float Field = Mathf.Lerp(80f, 70f, value_positive);

        CameraComponent.fieldOfView = Mathf.Lerp(CameraComponent.fieldOfView, Field, 4f * Time.deltaTime);
    }

    private int OldShakeCount;
    public void ShakeEnable()
    {
        ShakeCount++;
        if (ShakeCount == 1 && OldShakeCount < 1) StartTimeShake = Time.time;
        OldShakeCount = ShakeCount;
    }


    public void ShakeDisable()
    {
        ShakeCount--;
        if (ShakeCount < 1 && OldShakeCount > 0) EndTimeShake = Time.time;
    }

    private int ShakeCount;

    //0.25
    Vector3 EndShakePos = Vector3.zero,
        StartShakePos;

    private float ShakeTimeEnd,
        ShakeDelay,
        ShakeTimeMax = 0.1f, ShakeTimeMaxRange = 0.1f,
        ShakeAmplitude,
        ShakeAmplitudeMin = 0.02f, ShakeAmplitudeRange = 0.02f;



    private bool yShakeInvers;

    [SerializeField]
    private AnimationCurve ShakeCurve;

    //private float ShakeTimeAdded;
    private void ShakeUpdate()
    {
        if (Time.time > ShakeTimeEnd)
        {
            ShakeDelay = ShakeTimeMax + Random.Range(0f, ShakeTimeMaxRange);

            ShakeDelay *= 1f + (ShakeStart() * 3f);
            ShakeDelay *= 1f + (1f - ShakeEnd());

            ShakeTimeEnd = Time.time + ShakeDelay;


            ShakeAmplitude = ShakeAmplitudeMin + Random.Range(0f, ShakeAmplitudeRange);

            float y = Random.Range(0f, ShakeAmplitude);
            if (yShakeInvers) y *= -1f;
            yShakeInvers = !yShakeInvers;

            float x = Random.Range(-ShakeAmplitude, ShakeAmplitude);
            StartShakePos = EndShakePos;
            EndShakePos = new Vector3(x, y, 0f);
        }

        float timeResult = (ShakeTimeEnd - Time.time) / ShakeDelay;

        if (timeResult < 0f) timeResult = 0f;
        timeResult = ShakeCurve.Evaluate(timeResult);

        Vector3 pos = Vector3.Lerp(EndShakePos, StartShakePos, timeResult);
        pos *= 1f - ShakeStart();
        pos *= ShakeEnd();

        CameraPos = pos; 
    }


    private float StartTimeShake, StartTimeDelay = 0.1f;
    [SerializeField]
    private AnimationCurve ShakeStartCurve;
    private float ShakeStart()
    {
        //return 0f;

        float t = (StartTimeShake + StartTimeDelay - Time.time) / StartTimeDelay;
        if (t < 0f) t = 0f;
        return t;
    }

    private float EndTimeShake, EndTimeDelay = 3.5f;
    [SerializeField]
    private AnimationCurve CurveEndShake;
    private float ShakeEnd()
    {
        if (Time.time < EndTimeShake + EndTimeDelay)
        {
            float t = (EndTimeShake + EndTimeDelay - Time.time) / EndTimeDelay;
            return CurveEndShake.Evaluate(t);
        }

        if (ShakeCount < 1) return 0f;
        if (ShakeCount > 0) return 1f;

        return 0f;
    }
}
