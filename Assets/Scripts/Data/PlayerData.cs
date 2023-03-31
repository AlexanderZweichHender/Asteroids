using System;

[Serializable]
public class PlayerData
{
    public int score;
    public int deathCount;

    public PlayerData(Player player)
    {
        score = player.Totalscore;
        deathCount = player.DeathCount;
    }
}