using UnityEngine;

public class Player : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    public int Totalscore { get; private set; }
    public int DeathCount {get; private set;}
    
    public delegate void OnPlayerDead();
    public static event OnPlayerDead OnPlayerDeadEvent;

    public delegate void OnScoreCollected(int score);
    public static event OnScoreCollected OnScoreCollectedEvent;

    private void Start() => LoadPlayer();
    private void OnEnable() => Asteroid.OnAsterdoidDestroyedEvent += AddScore;
    private void OnDisable() => Asteroid.OnAsterdoidDestroyedEvent -= AddScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            DeathCount++;
            OnPlayerDeadEvent?.Invoke();
            SavePlayer();            
            Destroy(gameObject);
        }
    }  

    private void SavePlayer()
    {
        SaveSystem.SavePlayerStats(this);
    }

    private void LoadPlayer()
    {
        PlayerData data = (PlayerData)SaveSystem.LoadPlayerStats();
        Totalscore = data.score;
        DeathCount = data.deathCount;

        Debug.Log($"<color=blue>Total score: {Totalscore}</color>");
        Debug.Log($"<color=red>Death count: {DeathCount}</color>");
    }

    private void AddScore()
    {
        Totalscore++;
        CurrentScore++;
        OnScoreCollectedEvent?.Invoke(CurrentScore);
    }    
}
