using UnityEngine;
using UnityEngine.UI;

public class UITimeAttackPanelNew : MonoBehaviour, IMenuNew
{
    [SerializeField] private Text clockText;
    private UIManagerNew m_mngr;

    public void Setup(UIManagerNew manager)
    {
        m_mngr = manager;
        // liên kết clockText với UIManagerNew
        m_mngr.SetTimeAttackClock(clockText);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public bool MatchesState(GameManagerNew.State state) => state == GameManagerNew.State.TimeAttack;
}
