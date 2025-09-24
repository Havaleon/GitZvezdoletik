using UnityEngine;

public class interpolation_animation_obstacle : MonoBehaviour
{
    [SerializeField]
    private interpolation_animation interpolationAnimationPos,
        interpolationAnimationRot, interpolationAnimationScale;

    private void Awake()
    {
        interpolationAnimationPos.TransformPoint = player.instance.transform;
        interpolationAnimationRot.TransformPoint = player.instance.transform;
        interpolationAnimationScale.TransformPoint = player.instance.transform;
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
        interpolationAnimationPos.DistanceMax = 20f + (AnimationCurve.Evaluate(Random.value) * 20f);


        Vector3 vectorAnim = new Vector3((AnimationCurve.Evaluate(Random.value) * 2f) - 1f,
            (AnimationCurve.Evaluate(Random.value) * 10f) - 5f,
            (AnimationCurve.Evaluate(Random.value) * 2f) - 1f);

        interpolationAnimationPos.VectorStart = vectorAnim;
    }

    private void RotAnimation()
    {
        interpolationAnimationRot.DistanceMax = 40f;


        Vector3 vectorAnim = new Vector3(Random.Range(0f,360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f));

        interpolationAnimationRot.VectorStart = vectorAnim;
    }
}
