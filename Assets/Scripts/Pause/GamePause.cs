using UnityEngine;

public class GamePause : MonoBehaviour
{
    public delegate void OnGamePaused(bool isPaused);
    public static event OnGamePaused OnGamePausedEvent;
    public static bool IsPaused = false;
    private InputConfig inputActions;

    private void Awake()
    {
        inputActions = new InputConfig();
        inputActions.Player.SetPause.performed += context => CheckPause();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Start() => Time.timeScale = 1;     

    private void CheckPause()
    {
         IsPaused = !IsPaused;
            OnGamePausedEvent?.Invoke(IsPaused);

            if(!IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
    }
}
