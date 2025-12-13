using System.Collections.Generic;
using UnityEngine;

public class MobsManager : MonoBehaviour
{
    private class Mob
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public Mob(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
    }
    private static Dictionary<string, Mob> dictionary = new Dictionary<string, Mob>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            dictionary[transform.GetChild(i).name] = new Mob(transform.GetChild(i).gameObject);
    }
    public static void DeleteMob(string name)
    {
        dictionary[name].IsActive = false;
        dictionary[name].gameObject.SetActive(false);

    }
    public static void CreateMob(Vector2 Position, string MobName)
    {
        Mob mob = null;
        byte i = 0;
        while (mob == null && dictionary.ContainsKey(i.ToString() + MobName))
        {
            mob = dictionary[i.ToString() + MobName];
            if (!mob.IsActive)
            {
                mob.gameObject.SetActive(true);
                mob.IsActive = true;
                mob.gameObject.transform.position = Position;
            }
            else
                mob = null;
            i++;
        }
        if (mob == null)
            Debug.Log("Not enough Mobs");
    }
}
