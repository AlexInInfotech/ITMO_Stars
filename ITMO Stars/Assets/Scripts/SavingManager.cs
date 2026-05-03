using System.IO;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
//   using UnityEngine;

//public class SaveSystem : MonoBehaviour
//{
//    //
//    public void SaveNickname(string key, string value)
//    {
//        PlayerPrefs.SetString(key, value);
//        PlayerPrefs.Save(); // 
//    }

//    // 
//    public string LoadNickname(string key)
//    {
//        if (PlayerPrefs.HasKey(key))
//        {
//            return PlayerPrefs.GetString(key);
//        }
//        return "Default Name"; // 
//    }
//}

//    using System.IO;
//using UnityEngine;

//public class SaveManager : MonoBehaviour
//{
//    public void SaveGame<T>(T data, string fileName)
//    {
//        // 1. Превращаем класс в строку JSON
//        string json = JsonUtility.ToJson(data, true); // true сделает JSON читаемым

//        // 2. Формируем путь (автоматически подстроится под ПК или Смартфон)
//        string path = Path.Combine(Application.persistentDataPath, fileName + ".json");

//        // 3. Записываем строку в файл. 
//        // Если файла нет — метод создаст его. Если есть — перезапишет.
//        File.WriteAllText(path, json);

//        Debug.Log($"Данные сохранены в: {path}");
//    }
//}
}
