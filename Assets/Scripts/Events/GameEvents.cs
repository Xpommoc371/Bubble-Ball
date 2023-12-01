using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent OnGameWin = new UnityEvent();
    public static UnityEvent OnGameLose = new UnityEvent();
    public static UnityEvent OnGameRestart = new UnityEvent();
    public static UnityEvent OnGameLoadNextLevel = new UnityEvent();
}
