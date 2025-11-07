using UnityEngine;

public class GameManagerNew : MonoBehaviour
{
    public enum State { Home, Game, Pause, Win, Lose, TimeAttack }
    public State CurrentState { get; private set; } = State.Home;

    [SerializeField] private UIManagerNew uiManager;
    [SerializeField] private TileManagerNew tileManager;
    [SerializeField] private BottomBarNew bottomBar;

    private float timeLeft;
    private bool timeAttackRunning;

    private void Awake()
    {
        uiManager.Setup(this);
        tileManager.Setup(this, bottomBar);
        bottomBar.Setup(this);
    }

    public void StartGame()
    {
        CurrentState = State.Game;
        tileManager.GenerateBoardEnsureAllTypes();
        bottomBar.ResetBar();
        uiManager.OnGameStateChange(CurrentState);
    }

    public void StartTimeAttack()
    {
        CurrentState = State.TimeAttack;
        timeLeft = 60f;
        timeAttackRunning = true;
        tileManager.GenerateBoardEnsureAllTypes();
        bottomBar.ResetBar();
        uiManager.OnGameStateChange(CurrentState);
    }

    private void Update()
    {
        if (timeAttackRunning && CurrentState == State.TimeAttack)
        {
            timeLeft -= Time.deltaTime;
            uiManager.UpdateTimeAttackClock(Mathf.CeilToInt(timeLeft));
            if (timeLeft <= 0f)
            {
                timeAttackRunning = false;
                if (!tileManager.IsBoardEmpty()) ShowLose();
                else ShowWin();
            }
        }
    }

    public void ShowWin() { CurrentState = State.Win; uiManager.OnGameStateChange(CurrentState); }
    public void ShowLose() { CurrentState = State.Lose; uiManager.OnGameStateChange(CurrentState); }
    public void ShowPause() { CurrentState = State.Pause; uiManager.OnGameStateChange(CurrentState); }
    public void ShowHome() { CurrentState = State.Home; uiManager.OnGameStateChange(CurrentState); }

    public void OnBoardEmptied() => ShowWin();
    public void OnBottomBarFull()
    {
        if (CurrentState == State.Game) ShowLose();
    }
}
