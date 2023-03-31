using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private void OnEnable() => Player.OnPlayerDeadEvent += DisplayDeath;
    private void OnDisable() => Player.OnPlayerDeadEvent -= DisplayDeath;

    private void DisplayDeath()
    {
        Debug.Log("<color=red>Game over</color>");
    }
}
