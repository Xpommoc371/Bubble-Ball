using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerShoot : MonoBehaviour
{
    public BaseProjectile projectile;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject projectileCreationParticles; 

    private Player player;
    private bool isTouching = false;
    private BaseProjectile currentProjectile;

    public static UnityEvent OnProjectileStart = new UnityEvent();
    public static UnityEvent OnProjectileEnd = new UnityEvent();

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        InputControl.OnMouseUp.AddListener(MouseUp);
        InputControl.OnMouseDown.AddListener(MouseDown);
        InputControl.OnDisableControl.AddListener(DisableGrow);
    }

    private void DisableGrow(bool isDisabled)
    {
        if (isDisabled)
        {
            isTouching = false;
            projectileCreationParticles.SetActive(false);
        }
    }

    private void Update()
    {
        if (isTouching) { GrowProjectile(); }
    }

    void MouseDown()
    {
        isTouching = true;
        CreateProjectile();
    }

    void MouseUp(Vector3 mousePos)
    {
        isTouching = false;
        if(currentProjectile != null)
        {
            OnProjectileEnd.Invoke();
            currentProjectile = null;
            projectileCreationParticles.SetActive(false);
        }
    }

    private void CreateProjectile()
    {
        currentProjectile = Instantiate(projectile, spawnPosition.position, new Quaternion(), null);
        OnProjectileStart.Invoke();
        projectileCreationParticles.SetActive(true);
    }

    private void GrowProjectile()
    {
        if(currentProjectile!=null)
        currentProjectile.Grow();
    }
}
