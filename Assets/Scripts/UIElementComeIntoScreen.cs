using DG.Tweening;
using UnityEngine;

public class UIElementComeIntoScreen : MonoBehaviour
{
    public AnimationCurve Curve;
    public float Duration;
    public float Delay;

    public Vector3 ComeInDirection;

    private Vector3 _initialPosition;
    public Vector3 GetInitialPosition => _initialPosition;

    private void OnEnable()
    {
        MoveAndAnimate();
    }

    private void MoveAndAnimate()
    {
        _initialPosition = transform.position;

        transform.position += ComeInDirection;

        transform.DOMove(_initialPosition, Duration).SetDelay(Delay).SetEase(Curve);
    }
}
