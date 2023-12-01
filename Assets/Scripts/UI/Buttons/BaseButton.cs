using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class BaseButton : MonoBehaviour
{
    protected Button button;

    protected void Awake()
    {
        button = GetComponent<Button>();
    }

    protected virtual void SetButtonListener(UnityEvent listener)
    {
        button.onClick.AddListener(() => listener.Invoke());
    }

    protected virtual void RemoveButtonListener(UnityEvent listener)
    {
        button.onClick.RemoveListener(() => listener.Invoke());
    }
}
