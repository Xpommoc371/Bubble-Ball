using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    bool gameOverTriggered = false;
    private void OnEnable()
    {
        Player.OnMinSizeReached.AddListener(OnPlayerMinSize);
        Player.OnReachTarget.AddListener(OnPlayerReachTarget);
        GameEvents.OnGameRestart.AddListener(Restart);
        GameEvents.OnGameLoadNextLevel.AddListener(LoadNextLevel);
    }

    private void OnDisable()
    {
        Player.OnMinSizeReached.RemoveListener(OnPlayerMinSize);
        Player.OnReachTarget.RemoveListener(OnPlayerReachTarget);
        GameEvents.OnGameRestart.RemoveListener(Restart);
        GameEvents.OnGameLoadNextLevel.RemoveListener(LoadNextLevel);
    }

    private void OnPlayerMinSize()
    {
        if(gameOverTriggered ) return;
        TriggerGameOver();
        GameEvents.OnGameLose.Invoke();
    }

    private void OnPlayerReachTarget()
    {
        if (gameOverTriggered) return;
        TriggerGameOver();
        GameEvents.OnGameWin.Invoke();
    }

    private void TriggerGameOver()
    {
        gameOverTriggered = true;
        InputControl.OnDisableControl.Invoke(true);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
