using System.Collections.Generic;
using UnityEngine;

public class MobsManager : MonoBehaviour
{
    [SerializeField] MobInfo[] _FriendlyMobs;
    [SerializeField] EnemyInfo[] _Enemies;
    private static MobInfo[] FriendlyMobs;
    private static EnemyInfo[] Enemies;
    private class Mob
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public Mob(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
    }
    private static Dictionary<string, Mob> BasesForFriendlyMobs = new Dictionary<string, Mob>();
    private static Dictionary<string, Mob> BasesForEnemies = new Dictionary<string, Mob>();
    private static Transform ManagerTransform;
    const string FRIENDLYMOB = "FriendlyMob";
    const string ENEMY = "Enemy";
    
    void Start()
    {
        FriendlyMobs = _FriendlyMobs;
        Enemies = _Enemies;
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).name.Contains(FRIENDLYMOB))
            {
                BasesForFriendlyMobs[transform.GetChild(i).name] = new Mob(transform.GetChild(i).gameObject);
                Debug.Log("Friendluy");
            }
            else
            { 
                BasesForEnemies[transform.GetChild(i).name] = new Mob(transform.GetChild(i).gameObject);
                Debug.Log("EENMy");
            }
        ManagerTransform = GetComponent<Transform>();
    }
    private static MobInfo GetFriendlyMobInfo(string name)
    {
        foreach (MobInfo info in FriendlyMobs)
            if (info.name == name)
                return info;
        return null;
    }
    private static EnemyInfo GetEnemyInfo(string name)
    {
        foreach (EnemyInfo info in Enemies)
            if (info.name == name)
                return info;
        return null;
    }
    private static bool IsMobFriendly(string mobName)
    {
        foreach (MobInfo info in FriendlyMobs)
            if (info.name == mobName)
                return true;
        return false;
    }
    private static void ApplyInfoToBase(GameObject Base, MobInfo inf)
    {
        Base.GetComponent<BoxCollider2D>().offset = inf.ColliderOffset;
        Base.GetComponent<BoxCollider2D>().size = inf.ColliderSize;
        Base.GetComponent<Movable>().SetSpeed(inf.Speed);
        Base.GetComponentInChildren<Animator>().runtimeAnimatorController = inf.AnimatorController;
    }
    private static void ApplyInfoToBase(GameObject Base, EnemyInfo inf)
    {
        ApplyInfoToBase(Base, inf as MobInfo);
        Base.GetComponent<AttackController>().SetAttackStrength(inf.AttackStrength);
    }
    private static void ActivateMob(Mob mob, Vector2 Position, MobInfo mobInfo, EnemyInfo enemyInfo)
    {
        mob.gameObject.SetActive(true);
        mob.IsActive = true;
        mob.gameObject.transform.position = Position;
        if (mobInfo != null)
            ApplyInfoToBase(mob.gameObject, mobInfo);
        else
            ApplyInfoToBase(mob.gameObject, enemyInfo);
    }
    public static void DeleteMob(GameObject gameObject)
    {
        string name = gameObject.name;
        if (IsMobFriendly(name))
        {
            BasesForFriendlyMobs[name].IsActive = false;
            BasesForFriendlyMobs[name].gameObject.SetActive(false);
        }
        else
        {
            BasesForEnemies[name].IsActive = false;
            BasesForEnemies[name].gameObject.SetActive(false);
        }
    }

    public static void CreateMob(Vector2 Position, string MobName)
    {
        Mob mob = null;
        Dictionary<string, Mob> dictionary;
        byte i = 0;
        MobInfo mobInfo = null;
        EnemyInfo enemyInfo = null;
        string cluster;
        if (IsMobFriendly(MobName))
        {
            mobInfo = GetFriendlyMobInfo(MobName);
            dictionary = BasesForFriendlyMobs;
            cluster = FRIENDLYMOB;
        }
        else
        {
            enemyInfo = GetEnemyInfo(MobName);
            dictionary = BasesForEnemies;
            cluster = ENEMY;
        }

        while (mob == null && dictionary.ContainsKey(i.ToString() + cluster))
        {
            mob = dictionary[i.ToString() + cluster];
            if (!mob.IsActive)
                ActivateMob(mob, Position, mobInfo, enemyInfo);
            else
                mob = null;
            i++;
        }
        if (mob == null)
        {
            mob = new Mob(Instantiate(dictionary["0" + cluster].gameObject, Position, new Quaternion()));
            mob.gameObject.name = i+cluster;
            mob.gameObject.transform.SetParent(ManagerTransform);
            ActivateMob(mob, Position, mobInfo, enemyInfo);
            if (IsMobFriendly(MobName))
                BasesForFriendlyMobs.Add(i+ cluster, mob);
            else
                BasesForEnemies.Add(i+ cluster, mob);
        }
    }
}
