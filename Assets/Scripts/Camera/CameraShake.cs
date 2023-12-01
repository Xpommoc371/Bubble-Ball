using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeStrength = 1.0f;

    private void OnEnable()
    {
        BaseObstacle.OnObstacleDestroy.AddListener(Shake);
    }

    private void OnDisable()
    {
        BaseObstacle.OnObstacleDestroy.RemoveListener(Shake);
    }

    public void Shake()
    {
        transform.DOShakePosition(shakeDuration, shakeStrength);
    }
}
