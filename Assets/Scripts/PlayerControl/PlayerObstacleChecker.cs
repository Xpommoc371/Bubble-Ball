using UnityEngine;

public class PlayerObstacleChecker : MonoBehaviour
{
    public bool hasObstacleInFront = false;
    public Vector3 overlappingBoxSize = new Vector3(1, 0, 2.5f);

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BaseTarget target))
        {
            Player.OnReachTarget.Invoke();
        }
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Collider[] colliders = Physics.OverlapBox(transform.position+forward, overlappingBoxSize);
        Debug.DrawRay(transform.position + forward, overlappingBoxSize, Color.green);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out BaseObstacle obstacle))
            {
                hasObstacleInFront = true;
                Debug.Log("Collider found: " + collider.name);
                return;
            }
        }
        hasObstacleInFront = false;
    }

    private void HitCollider(Collider other)
    {
        hasObstacleInFront = other.TryGetComponent(out BaseObstacle obstacle);
    }
}
