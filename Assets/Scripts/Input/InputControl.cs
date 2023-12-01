using UnityEngine;
using UnityEngine.Events;

public class InputControl : MonoBehaviour
{
    public static UnityEvent OnMouseDown = new UnityEvent();
    public static UnityEvent<Vector3> OnMouseUp = new UnityEvent<Vector3>();
    public static UnityEvent OnMouseHold = new UnityEvent();
    public static UnityEvent<bool> OnDisableControl = new UnityEvent<bool>();
    private Camera mainCamera;
    private bool IsInputAllowed = true;

    private void OnEnable()
    {
        OnDisableControl.AddListener(OnPlayerMove);
    }

    private void OnDisable()
    {
        OnDisableControl.AddListener(OnPlayerMove);
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnPlayerMove(bool isPlayerMove)
    {
        IsInputAllowed = !isPlayerMove;
    }

    private void Update()
    {
        if (!IsInputAllowed) return;
        if (Input.GetMouseButtonDown(0))
            OnMouseDown.Invoke();
        else if (Input.GetMouseButton(0))
            OnMouseHold.Invoke();
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Vector3 worldMousePos = Vector3.zero;
            if (groundPlane.Raycast(ray, out float rayDistance))
            {
                worldMousePos = ray.GetPoint(rayDistance);
                Debug.Log("Mouse World Position: " + worldMousePos);
            }
            OnMouseUp.Invoke(worldMousePos);
        }
    }
}
