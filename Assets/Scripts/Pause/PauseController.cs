using UnityEngine;
using UnityEngine.UIElements;

public class PauseController : MonoBehaviour
{
    [SerializeField] private UIDocument pauseMenu;
    private VisualElement pauseUI;
    private Button resumeButton;
    private Button exitButton;

    private void Start()
    {
        pauseUI = pauseMenu.rootVisualElement;
    }
    private void OnEnable() => GamePause.OnGamePausedEvent += SetPausePanelActivity;
    private void OnDisable() => GamePause.OnGamePausedEvent -= SetPausePanelActivity;    
    
    private void SetPausePanelActivity(bool isPaused)
    {
        if(isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
        }
    }
}
