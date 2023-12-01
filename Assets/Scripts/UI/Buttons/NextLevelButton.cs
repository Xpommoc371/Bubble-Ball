public class NextLevelButton : BaseButton
{

    private void OnEnable()
    {
        SetButtonListener(GameEvents.OnGameLoadNextLevel);
    }

    private void OnDisable()
    {
        RemoveButtonListener(GameEvents.OnGameLoadNextLevel);
    }
}
