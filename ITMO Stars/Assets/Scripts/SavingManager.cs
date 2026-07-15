using System.IO;
using UnityEngine;

public static class SavingManager
{
    public static Transform playerTransform;
    public static AbstractDamagable playerDamagable;
    private class SaveInf
    {
        public Vector2 playerPosition;
        public int playerHealth;
        //public int baseSeed;
        //public int biomSeed;
        //public int envSeed;
        //public int riverSeed;

    }

    private static SaveInf data = new SaveInf();
    static string fileName = "Savings";

    //public static void SavePosition(string key, string value)
    //{
    //    PlayerPrefs.SetString(key, value);
    //    PlayerPrefs.Save(); // 
    //}   //    // 
    //    public string LoadNickname(string key)
    //    {
    //        if (PlayerPrefs.HasKey(key))
    //        {
    //            return PlayerPrefs.GetString(key);
    //        }
    //        return "Default Name"; // 
    //    }
   
    public static Vector2 GetPosition()
    {
        return data.playerPosition;
    }
    public static int GetHealth()
    {
        if (data.playerHealth >= 0)
            return data.playerHealth;
        return playerDamagable.MaxHealth;
    }
 
    public static void SaveGame()
    {
        data.playerPosition = playerTransform.position;
        data.playerHealth = playerDamagable.health;

        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName + ".json");
        File.WriteAllText(path, json);
        Debug.Log($"Данные сохранены в: {path}");

    }
    //public T LoadData<T>(string fileName)
    //{
    //    string path = Path.Combine(Application.persistentDataPath, fileName);

    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        return JsonUtility.FromJson<T>(json);
    //    }

    //    Debug.LogWarning("Файл сохранения не найден.");
    //    return default;
    //}
    public static void DeleteSavings()
    {
        data.playerHealth = -1;
        data.playerPosition = new Vector2(0, 0);
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName + ".json");
        File.WriteAllText(path, json);
    }
    public static void LoadSaves()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveInf>(json);
        }

    }
    
}
