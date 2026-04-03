using System.Collections.Generic;
using UnityEngine;

public class EnviornmentManager : MonoBehaviour
{
    [SerializeField] EnvironmentInfo[] _elementInfo;
    //private static EnvironmentInfo[] elementInfo;
    private class Element
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public Element(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
    }

    private static Dictionary<string, EnvironmentInfo> elementInfo = new Dictionary<string, EnvironmentInfo>(); 
    private static Dictionary<string, Element> basesForElements = new Dictionary<string, Element>();
    private static Transform managerTransform;
    const string ELEMENT = "Element";
    void Start()
    {
        foreach (EnvironmentInfo info in _elementInfo)
            elementInfo[info.name] = info;
        for (int i = 0; i < transform.childCount; i++)
            basesForElements[transform.GetChild(i).name] = new Element(transform.GetChild(i).gameObject);
      
        managerTransform = GetComponent<Transform>();
    }
   
    private static void ApplyInfoToBase(GameObject Base, string name, EnviromentState state = EnviromentState.unharmed)
    {
        EnvironmentInfo inf = elementInfo[name];
        Base.GetComponent<BoxCollider2D>().offset = inf.ColliderOffset;
        Base.GetComponent<BoxCollider2D>().size = inf.ColliderSize;
        Base.GetComponent<AbstractDamagable>().MaxHealth = inf.MaxHealth;
        Base.GetComponent<SpriteRenderer>().sprite = inf.sprites[(int)state];
        // Base.GetComponentInChildren<SpriteRenderer>().color= new Color(0, 0, 0);
    }
   
    private static void ActivateElement(Element mob, Vector2 Position, string name, EnviromentState state = EnviromentState.unharmed)
    {
        mob.gameObject.SetActive(true);
        mob.IsActive = true;
        mob.gameObject.transform.position = Position;
        ApplyInfoToBase(mob.gameObject, name, state);
    }
    private static void DeleteElement(GameObject gameObject)
    {
        string name = gameObject.name;
        basesForElements[name].IsActive = false;
        basesForElements[name].gameObject.SetActive(false);
    }

    public static void CreateElement(Vector2 Position, string name, EnviromentState state = EnviromentState.unharmed)
    {
        byte i = 0;
        Element element = null;
        while (element == null && basesForElements.ContainsKey(i.ToString() + ELEMENT))
        {
            element = basesForElements[i.ToString() + ELEMENT];
            if (!element.IsActive)
                ActivateElement(element, Position, name);
            else
                element = null;
            i++;
        }
        if (element == null)
        {
            element = new Element(Instantiate(basesForElements["0" + ELEMENT].gameObject, Position, new Quaternion()));
            element.gameObject.name = i + ELEMENT;
            element.gameObject.transform.SetParent(managerTransform);
            ActivateElement(element, Position, name, state);
            basesForElements.Add(i + ELEMENT, element);
        }
    }

    //public static void PrintEnvironment(Vector2[] Positions, string[] names, EnviromentState[] states)
    //{
    //    for (int i = 0; i < Positions.Length; i++)
    //    {

    //    }
    //}
}
