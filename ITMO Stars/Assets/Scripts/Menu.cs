using System.Security.Cryptography;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static string mainSceneName = "MainScene";
    public MapCharcteristics[] MapCharcteristics;
    public void CreateNewGame()
    {
        foreach (MapCharcteristics map in MapCharcteristics)
            map.seed = RandomNumberGenerator.GetInt32(1000);
        MobsManager.mobSeed = RandomNumberGenerator.GetInt32(1000);
        SavingManager.DeleteSavings();
        SceneManager.LoadScene(mainSceneName);
    }
    public void Continue()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
