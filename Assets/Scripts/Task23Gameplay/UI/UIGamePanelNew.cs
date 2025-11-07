using UnityEngine;

public class UIGamePanelNew : MonoBehaviour, IMenuNew
{
    public void Setup(UIManagerNew manager) { }
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public bool MatchesState(GameManagerNew.State state) => state == GameManagerNew.State.Game;
}
