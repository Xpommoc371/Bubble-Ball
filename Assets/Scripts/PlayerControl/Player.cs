using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityEvent OnMinSizeReached = new UnityEvent();
    public static UnityEvent OnReachTarget = new UnityEvent();


    [SerializeField] protected float Size = 5f;
    [SerializeField] protected float decreaseSizeSpeed = 0.01f;
    [SerializeField] protected float minSizeToLose = 0.1f;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] PlayerObstacleChecker obstacleChecker;
    private bool AllowGrow = true;

    protected void SetSize(float size)
    {
        transform.localScale = Vector3.one * size;
    }

    private void OnEnable()
    {
        InputControl.OnMouseHold.AddListener(DecreaseSize);
        PlayerShoot.OnProjectileStart.AddListener(() => { AllowGrow = true; });
        PlayerShoot.OnProjectileEnd.AddListener(() => { AllowGrow = false; });
    }

    private void OnDisable()
    {
        InputControl.OnMouseHold.RemoveListener(DecreaseSize);
        PlayerShoot.OnProjectileStart.RemoveListener(() => { AllowGrow = true; });
        PlayerShoot.OnProjectileEnd.RemoveListener(() => { AllowGrow = false; });
    }

    private void Start()
    {
        SetSize(Size);
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (!obstacleChecker.hasObstacleInFront)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    public void DecreaseSize()
    {
        if(!AllowGrow) return;
        Size -= decreaseSizeSpeed;
        transform.localScale = new Vector3(Size, Size, Size);
        if (Size < minSizeToLose)
            OnMinSizeReached.Invoke();
    }
}
