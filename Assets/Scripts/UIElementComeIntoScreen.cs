using DG.Tweening;
using UnityEngine;

public class UIElementComeIntoScreen : MonoBehaviour
{
    public AnimationCurve Curve;
    public float Duration;
    public float Delay;

    [Space]

    public Vector3 ComeInDirection;

    [Space]

    private Vector3 _initialPosition;
    public Vector3 GetInitialPosition => _initialPosition;

    [Space]

    public AudioClip Audio;

    private void OnEnable()
    {
        MoveAndAnimate();
    }

    private void MoveAndAnimate()
    {
        _initialPosition = transform.position;

        transform.position += ComeInDirection;

        transform.DOMove(_initialPosition, Duration).SetDelay(Delay).SetEase(Curve);

        if (Audio)
            AudioManager.Instance.PlaySFX(Audio);
    }
}
