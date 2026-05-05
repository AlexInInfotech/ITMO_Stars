using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] TileManager tileManager;
    [SerializeField] MobsManager mobsManager;
    [SerializeField] MapManager mapManager;
    [SerializeField] EnvironmentManager environmentManager;
    [SerializeField] PlayerController playerController;

    [SerializeField] Transform playerTransform;
    [SerializeField] AbstractDamagable playerDamagable;
    void Start()
    {
        SavingManager.playerTransform = playerTransform;
        SavingManager.playerDamagable = playerDamagable;
        SavingManager.LoadSaves();
        playerController.LoadPosition();
        environmentManager.Preparing();
        mobsManager.Preparing();
        TileControl.SetRules();
        tileManager.SetConst();
        mapManager.StartMap();
    }

    
}
