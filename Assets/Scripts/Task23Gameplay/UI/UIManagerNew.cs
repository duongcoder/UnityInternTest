using UnityEngine;
using UnityEngine.UI;

public class UIManagerNew : MonoBehaviour
{
    private GameManagerNew gm;
    private Text timeAttackClockText;

    public void Setup(GameManagerNew gameManager)
    {
        gm = gameManager;
        foreach (var menu in GetComponentsInChildren<IMenuNew>(true))
        {
            menu.Setup(this);
        }
    }

    public void OnGameStateChange(GameManagerNew.State state)
    {
        foreach (var menu in GetComponentsInChildren<IMenuNew>(true))
        {
            if (menu.MatchesState(state)) menu.Show();
            else menu.Hide();
        }
    }

    public void ShowGameMenu() => gm.StartGame();
    public void ShowTimeAttackMenu() => gm.StartTimeAttack();
    public void ShowMainMenu() => gm.ShowHome();

    public void UpdateTimeAttackClock(int secondsLeft)
    {
        if (timeAttackClockText) timeAttackClockText.text = $"{secondsLeft}s";
    }

    public void SetTimeAttackClock(Text txt) => timeAttackClockText = txt;
}
