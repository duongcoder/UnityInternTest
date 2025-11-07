using UnityEngine;
using UnityEngine.UI;

public class UIPanelMainNew : MonoBehaviour, IMenuNew
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnTimeAttack;
    private UIManagerNew m_mngr;

    public void Setup(UIManagerNew manager)
    {
        m_mngr = manager;
        btnPlay.onClick.AddListener(() => m_mngr.ShowGameMenu());
        btnTimeAttack.onClick.AddListener(() => m_mngr.ShowTimeAttackMenu());
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public bool MatchesState(GameManagerNew.State state) => state == GameManagerNew.State.Home;
}
