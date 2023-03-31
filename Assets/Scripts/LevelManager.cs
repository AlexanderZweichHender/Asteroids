using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnEnable() => Player.OnPlayerDeadEvent += RestartLevel;
    private void OnDisable() => Player.OnPlayerDeadEvent -= RestartLevel;

    private void RestartLevel()
    {
        Debug.Log("<color=green>Level has been restarted successfully</color>");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
