public class ReloadLevelButton : BaseButton
{
    private void OnEnable()
    {
        SetButtonListener(GameEvents.OnGameRestart);
    }

    private void OnDisable()
    {
        RemoveButtonListener(GameEvents.OnGameRestart);
    }
}
