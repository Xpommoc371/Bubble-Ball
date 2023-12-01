using System;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;

    private void OnEnable()
    {
        GameEvents.OnGameWin.AddListener(EnableWinUI);
        GameEvents.OnGameLose.AddListener(EnableLoseUI);
    }

    private void EnableLoseUI()
    {
        LoseUI.SetActive(true);
    }

    private void EnableWinUI()
    {
        WinUI.SetActive(true);
    }
}
