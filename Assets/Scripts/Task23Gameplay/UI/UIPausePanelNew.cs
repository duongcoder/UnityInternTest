using UnityEngine;
using UnityEngine.UI;

public class UIPausePanelNew : MonoBehaviour, IMenuNew
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnHome;
    private UIManagerNew m_mngr;

    public void Setup(UIManagerNew manager)
    {
        m_mngr = manager;
        btnResume.onClick.AddListener(() => m_mngr.ShowGameMenu());
        btnHome.onClick.AddListener(() => m_mngr.ShowMainMenu());
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public bool MatchesState(GameManagerNew.State state) => state == GameManagerNew.State.Pause;
}
