using NaughtyAttributes;
using UnityEngine;

public enum interpolation_animation_type
{
    X = 0, Y = 1, Z = 2,
    XYZ = 3
}

public enum interpolation_animation_vector
{
    Position = 0, Rotation = 1, Scale = 2
}

public enum interpolation_animated
{
    Linear = 0, AnimationCurve = 1
}

public class interpolation_animation : MonoBehaviour
{
    [SerializeField]
    private interpolation_animation_type TypeAnimation;

    private void Start()
    {
        if (TransformAnimation == null)
        {
            TransformAnimation = transform;
        }

        switch (TypeVectorAnimaton)
        {
            case interpolation_animation_vector.Position:
                TransformAnimation.localPosition = VectorStart;
                break;

            case interpolation_animation_vector.Rotation:
                TransformAnimation.localRotation = Quaternion.Euler(VectorStart);
                break;

            case interpolation_animation_vector.Scale:
                TransformAnimation.localScale = VectorStart;
                break;
        }
    }

    void Update()
    {
        Animation();
    }

    [Space]
    public Transform TransformAnimation;
    public Transform TransformPoint;

    [Space]
    public float DistanceMin;
    public float DistanceMax;

    [Space]
    [Space]
    [SerializeField]
    private interpolation_animation_vector TypeVectorAnimaton;
    [Space]
    public Vector3 VectorStart;
    public Vector3 VectorEnd;

    [Space]
    [SerializeField]
    private interpolation_animated InterpolationAnimated;
    [SerializeField, ShowIf("InterpolationAnimated", interpolation_animated.AnimationCurve)]
    private AnimationCurve AnimationCurve;

    private void Animation()
    {
        float t = 0f;
        float Distance = 0f;

        switch (TypeAnimation)
        {
            case interpolation_animation_type.XYZ:
                Distance = Vector3.Distance(transform.position, TransformPoint.position);
                break;

            case interpolation_animation_type.X:
                Distance = Mathf.Abs(transform.position.x - TransformPoint.position.x);
                break;
            case interpolation_animation_type.Y:
                Distance = Mathf.Abs(transform.position.y - TransformPoint.position.y);
                break;
            case interpolation_animation_type.Z:
                Distance = Mathf.Abs(transform.position.z - TransformPoint.position.z);
                break;

        }

        t = (Distance - DistanceMin) / DistanceMax;

        switch (InterpolationAnimated)
        {
            case interpolation_animated.AnimationCurve:
                t = AnimationCurve.Evaluate(t);
                break;

            case interpolation_animated.Linear:
                break;
        }

        Vector3 vector = Vector3.LerpUnclamped(VectorEnd, VectorStart, t);

        switch (TypeVectorAnimaton)
        {
            case interpolation_animation_vector.Position:
                TransformAnimation.localPosition = vector;
                break;

            case interpolation_animation_vector.Rotation:
                TransformAnimation.localRotation = Quaternion.Euler(vector);
                break;

            case interpolation_animation_vector.Scale:
                TransformAnimation.localScale = vector;
                break;
        }
    }
}
