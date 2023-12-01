using UnityEngine;

public class RadiusProjectile : BaseProjectile
{
    [SerializeField] private int Damage = 1; 

    protected override void OnObstacleHit(BaseObstacle obstacle)
    {
        base.OnObstacleHit(obstacle);
        Collider[] colliders = Physics.OverlapSphere(transform.position, Size);
        foreach (Collider collider in colliders)
        {
            collider.TryGetComponent(out BaseObstacle obstacleInRadius);
            if(obstacleInRadius != null)
            {
                obstacleInRadius.TakeDamage(Damage);
            }
        }
        DestroyProjectile();
    }
}
