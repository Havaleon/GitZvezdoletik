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
        Camera_transform = transform;
        Camera_Component = GetComponent<Camera>();
    }

    private Transform Camera_transform;
    private Camera Camera_Component;

    private Vector3 Camera_rot_min = Vector3.zero,
        Camera_rot_max = new Vector3(0f, 2f, -10f),
        Camera_rot_current = Vector3.zero;

    public void CameraMove(float value)
    {
        Vector3 rot = Vector3.LerpUnclamped(Camera_rot_min, Camera_rot_max, value);
        Camera_rot_current = Vector3.Lerp(Camera_rot_current, rot, 4f * Time.deltaTime);
        Camera_transform.rotation = Quaternion.Euler(Camera_rot_current);


        float value_positive = value;
        if (value_positive < 0f) value_positive *= -1f;

        //60 50


        //80 70 нормальная скорость
        //90 80 ускорение
        float Field = Mathf.Lerp(80f, 70f, value_positive);

        Camera_Component.fieldOfView = Mathf.Lerp(Camera_Component.fieldOfView, Field, 4f * Time.deltaTime);
    }

    public void ObShake()
    {

    }
    private void ShakeUpdate()
    {

    }
}
