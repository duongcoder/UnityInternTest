public interface IMenuNew
{
    void Setup(UIManagerNew manager);
    void Show();
    void Hide();
    bool MatchesState(GameManagerNew.State state);
}
