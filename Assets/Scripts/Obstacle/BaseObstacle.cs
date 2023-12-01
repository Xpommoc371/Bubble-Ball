using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseObstacle : MonoBehaviour
{
    [SerializeField] protected int health = 1;
    [SerializeField] protected GameObject deathParticles;
    [SerializeField] protected AudioClip deathSound; 
    protected Material material;
    [SerializeField] Color deathColor = Color.white;

    public static UnityEvent OnObstacleDestroy = new UnityEvent();

    protected void DeatchColorAnimation(float duration)
    {
        Renderer obstacleRenderer = GetComponent<Renderer>();
        if (obstacleRenderer != null)
        {
            Material originalMaterial = obstacleRenderer.material;
            Material clonedMaterial = new Material(originalMaterial);
            obstacleRenderer.material = clonedMaterial;
        }
        obstacleRenderer.material.DOColor(deathColor, duration/2)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) Death();
    }

    protected virtual void Death()
    {
        OnObstacleDestroy.Invoke();
        AudioControl.OnPlayClip.Invoke(deathSound);
    }
}
