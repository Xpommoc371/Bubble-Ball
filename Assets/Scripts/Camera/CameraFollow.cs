using DG.Tweening;
using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer; 
    public float smoothTime = 0.5f; 
    public Vector3 offset;



    void Start()
    {
        if (targetPlayer != null)
        {
            offset = transform.position - targetPlayer.position;
        }
    }

    /*
     * 
    private void OnEnable()
    {
        Player.OnMove.AddListener(FollowPlayer);
    }

    private void OnDisable()
    {
        Player.OnMove.RemoveListener(FollowPlayer);
    }
     private void FollowPlayer(bool isMovementStop)
    {
        if (targetPlayer != null)
        {
            Vector3 targetPosition = targetPlayer.position + offset;
            transform.DOMove(targetPosition, smoothTime);
        }
    }*/

    void LateUpdate()
    {
        if (targetPlayer != null)
        {
            Vector3 desiredPosition = targetPlayer.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
            transform.position = smoothedPosition;

            //transform.LookAt(targetPlayer);
        }
    }
}
