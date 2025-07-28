using UnityEngine;

public class interpolation_animation_obstacle : MonoBehaviour
{
    [SerializeField]
    private interpolation_animation interpolation_Animation_pos,
        interpolation_Animation_Rot;

    private void Awake()
    {
        interpolation_Animation_pos.TransformPoint = player.inst.transform;
        interpolation_Animation_Rot.TransformPoint = player.inst.transform;
    }

    [SerializeField]
    private AnimationCurve AnimationCurve;

    private void OnEnable()
    {
        PosAnimation();
        RotAnimation();
    }

    private void PosAnimation()
    {
        interpolation_Animation_pos.DistanceMax = 20f + (AnimationCurve.Evaluate(Random.value) * 20f);


        Vector3 vectorAnim = new Vector3((AnimationCurve.Evaluate(Random.value) * 2f) - 1f,
            (AnimationCurve.Evaluate(Random.value) * 10f) - 5f,
            (AnimationCurve.Evaluate(Random.value) * 2f) - 1f);

        interpolation_Animation_pos.VectorStart = vectorAnim;
    }

    private void RotAnimation()
    {
        interpolation_Animation_Rot.DistanceMax = 40f;


        Vector3 vectorAnim = new Vector3(Random.Range(0f,360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f));

        interpolation_Animation_Rot.VectorStart = vectorAnim;
    }
}
