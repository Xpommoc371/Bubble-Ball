using DG.Tweening;
using UnityEngine;

public class DefaultObstacle : BaseObstacle
{
    [SerializeField] float UpDownAnimationDistance = 1f;
    [SerializeField] float deathAnimation = 0.3f;

    private float endHeight = 0f;
    float MoveSpeed = 0f;

    private void Awake()
    {
        endHeight = transform.position.y + UpDownAnimationDistance;
        MoveSpeed = Random.Range(0, 1f);
    }

    private void Start()
    {
        MoveAnimation();
    }

    void MoveAnimation()
    {
        transform.DOLocalMoveY(endHeight, 1/ MoveSpeed)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    protected override void Death()
    {
        base.Death();
        GameObject particles = Instantiate(deathParticles, transform.position, new Quaternion(), null);
        Destroy(particles, 5f);
        float randomDelay = Random.Range(0.1f, deathAnimation);
        DeatchColorAnimation(randomDelay);
        Destroy(gameObject, randomDelay);
    }
}
