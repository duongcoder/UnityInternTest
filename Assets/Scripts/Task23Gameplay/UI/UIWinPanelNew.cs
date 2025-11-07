using UnityEngine;
using UnityEngine.UI;

public class UIWinPanelNew : MonoBehaviour, IMenuNew
{
    [SerializeField] private Button btnOk;
    private UIManagerNew m_mngr;

    public void Setup(UIManagerNew manager)
    {
        m_mngr = manager;
        btnOk.onClick.AddListener(() => m_mngr.ShowMainMenu());
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public bool MatchesState(GameManagerNew.State state) => state == GameManagerNew.State.Win;
}
