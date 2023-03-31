using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/player.data";

    public static void SavePlayerStats(Player player)
    {        
        BinaryFormatter formatter = new BinaryFormatter();

        using(FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            PlayerData data = new PlayerData(player);
            formatter.Serialize(fileStream, data);
        }
    }

    public static PlayerData LoadPlayerStats()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using(FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = (PlayerData)formatter.Deserialize(fileStream);
                return data;
            }
        }
        else
        {
            Debug.LogError($"<color=red>File not found. {path}</color>");
            return null;
        }
    }
}
