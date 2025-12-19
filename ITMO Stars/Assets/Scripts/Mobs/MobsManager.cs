    using System.Collections.Generic;
using UnityEngine;

public class MobsManager : MonoBehaviour
{
    [SerializeField] MobInfo[] _friendlyMobs;
    [SerializeField] EnemyInfo[] _enemies;
    private static MobInfo[] friendlyMobs;
    private static EnemyInfo[] enemies;
    private class Mob
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public Mob(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
    }
    private static Dictionary<string, Mob> basesForFriendlyMobs = new Dictionary<string, Mob>();
    private static Dictionary<string, Mob> basesForEnemies = new Dictionary<string, Mob>();
    private static Transform managerTransform;
    const string FRIENDLYMOB = "FriendlyMob";
    const string ENEMY = "Enemy";
    
    void Start()
    {
        friendlyMobs = _friendlyMobs;
        enemies = _enemies;
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).name.Contains(FRIENDLYMOB))
                basesForFriendlyMobs[transform.GetChild(i).name] = new Mob(transform.GetChild(i).gameObject);
            else
                basesForEnemies[transform.GetChild(i).name] = new Mob(transform.GetChild(i).gameObject);
        managerTransform = GetComponent<Transform>();
    }
    private static MobInfo GetFriendlyMobInfo(string name)
    {
        foreach (MobInfo info in friendlyMobs)
            if (info.name == name)
                return info;
        return null;
    }
    private static EnemyInfo GetEnemyInfo(string name)
    {
        foreach (EnemyInfo info in enemies)
            if (info.name == name)
                return info;
        return null;
    }
    private static bool IsMobFriendly(string mobName)
    {
        foreach (MobInfo info in friendlyMobs)
            if (info.name == mobName)
                return true;
        return false;
    }
    private static void ApplyInfoToBase(GameObject Base, MobInfo inf)
    {
        Base.GetComponent<BoxCollider2D>().offset = inf.ColliderOffset;
        Base.GetComponent<BoxCollider2D>().size = inf.ColliderSize;
        Base.GetComponent<Movable>().SetSpeed(inf.Speed);
        Base.GetComponent<AbstractDamagable>().MaxHealth = inf.MaxHealth;
        Base.GetComponentInChildren<Animator>().runtimeAnimatorController = inf.AnimatorController;
       // Base.GetComponentInChildren<SpriteRenderer>().color= new Color(0, 0, 0);
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
            basesForFriendlyMobs[name].IsActive = false;
            basesForFriendlyMobs[name].gameObject.SetActive(false);
        }
        else
        {
            basesForEnemies[name].IsActive = false;
            basesForEnemies[name].gameObject.SetActive(false);
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
            dictionary = basesForFriendlyMobs;
            cluster = FRIENDLYMOB;
        }
        else
        {
            enemyInfo = GetEnemyInfo(MobName);
            dictionary = basesForEnemies;
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
            mob.gameObject.transform.SetParent(managerTransform);
            ActivateMob(mob, Position, mobInfo, enemyInfo);
            if (IsMobFriendly(MobName))
                basesForFriendlyMobs.Add(i+ cluster, mob);
            else
                basesForEnemies.Add(i+ cluster, mob);
        }
    }
}
