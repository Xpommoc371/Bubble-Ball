using UnityEngine;
using DG.Tweening;
using System;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected GameObject particles;
    [SerializeField] protected AudioClip chargingSFX;
    [SerializeField] protected AudioClip hitSFX;
    public float Size = 1f;
    public float SizeIncreaseRate = 0.01f;
    public float MoveSpeed = 1f;

    [SerializeField] protected float hitDistance = 0.1f;
    private float maxTravelDistance = 50f;

    private void OnEnable()
    {
        InputControl.OnMouseUp.AddListener(OnMouseRelease);
        AudioControl.OnPlayClip.Invoke(chargingSFX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BaseObstacle obstacle))
        {
            Debug.Log("Hit obstacle");
            OnObstacleHit(obstacle);
        }
    }

    protected virtual void OnObstacleHit(BaseObstacle obstacle)
    {
    }

    protected void OnMouseRelease(Vector3 mousePos)
    {
        Vector3 direction = mousePos - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        MoveProjectile(direction);
        AudioControl.OnPlayClip.Invoke(hitSFX);
        particles.SetActive(false);
        InputControl.OnMouseUp.RemoveListener(OnMouseRelease);
    }

    void MoveProjectile(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction.normalized * maxTravelDistance;

        transform.DOMove(targetPosition, 1/MoveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(DestroyProjectile);
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void Grow()
    {
        Size += SizeIncreaseRate;
        transform.localScale = new Vector3(Size, Size, Size);
    }
}
