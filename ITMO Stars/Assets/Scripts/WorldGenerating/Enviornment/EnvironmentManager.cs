using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] EnvironmentInfo[] _elementInfo;
    //private static EnvironmentInfo[] elementInfo;
    public static float bushLow;
    public static float treeLow;
    public float _bushLow;
    public float _treeLow;
    private class ElementBase
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public ElementBase(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
    }
    //public static Dictionary<string, byte> countElements = new Dictionary<string, byte>();
    private static Dictionary<string, EnvironmentInfo> elementInfo = new Dictionary<string, EnvironmentInfo>(); 
    private static Dictionary<string, ElementBase> basesForElements = new Dictionary<string, ElementBase>();
    private static Transform managerTransform;
    const string ELEMENT = "Element";
    public static string GetSurroundName(EnvironmentType environmentType,TileType baseType, BiomType biomtype)
    {
        return environmentType.ToString() + baseType.ToString() +  biomtype.ToString();
    }

    private static EnvironmentInfo GetElementInfo(string name)
    {
        if (elementInfo.ContainsKey(name))
            return elementInfo[name];
        return null;
    }
    void Awake()
    {
        string name = "";
        bushLow = _bushLow;
        treeLow = _treeLow;
        foreach (EnvironmentInfo inf in _elementInfo)
        {
            name = inf.environmentType.ToString() + inf.baseType.ToString()+ inf.biomtype.ToString();
            elementInfo[name] = inf;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).name);
            basesForElements[transform.GetChild(i).name] = new ElementBase(transform.GetChild(i).gameObject);
        }
        managerTransform = GetComponent<Transform>();
    }
    public static EnvironmentType GetEnvironmentType(float value)
    {
        if (value < bushLow)
            return EnvironmentType.none;
        else if (value < treeLow)
            return EnvironmentType.bush;
        else
            return EnvironmentType.tree;
    }
    public static void PrintSurrounds(WorldUnit unit)
    {
        foreach (Surround surround in unit.surrounds)
        {
            //Debug.Log(surround);
            SetSurround(surround, unit.coord);
        }
    }
    //public static void Test()
    //{
    //    Surround surround = new Surround();
    //    surround.name = GetSurroundName(EnvironmentType.tree, TileType.earth, BiomType.usual);
    //    surround.state = EnviromentState.unharmed;
    //    surround.position = new Vector2(0, 0);
    //    SetSurround(surround, new Vector2Int(0, 0));
    //    SetSurround(surround, new Vector2Int(0, 0));
    //    SetSurround(surround, new Vector2Int(0, 0));
    //}

    private static void SetSurround(Surround surround, Vector2Int unitCoord)
    {
        if (GetElementInfo(surround.name) == null)
            return;
        byte i = 0;
        ElementBase elementBase = null;
        while (elementBase == null && basesForElements.ContainsKey(i.ToString() + ELEMENT))
        {
            elementBase = basesForElements[i.ToString() + ELEMENT];
            if (!elementBase.IsActive)
                ActivateElement(elementBase, surround, unitCoord);
            else
                elementBase = null;
            i++;
        }
        if (elementBase == null)
        {
            elementBase = new ElementBase(Instantiate(basesForElements["0" + ELEMENT].gameObject, unitCoord*MapManager.tileMapWidth+surround.localPosition, new Quaternion()));
            elementBase.gameObject.name = i + ELEMENT;
            elementBase.gameObject.transform.SetParent(managerTransform);
            ActivateElement(elementBase, surround, unitCoord);
            basesForElements.Add(i + ELEMENT, elementBase);
        }
    }

    private static void ApplyInfoToBase(GameObject Base, string name, EnviromentState state = EnviromentState.unharmed)
    {
        EnvironmentInfo inf = GetElementInfo(name);
        Base.GetComponent<BoxCollider2D>().offset = inf.ColliderOffset;
        Base.GetComponent<BoxCollider2D>().size = inf.ColliderSize;
        Base.GetComponent<AbstractDamagable>().MaxHealth = inf.MaxHealth;
        Base.GetComponent<SpriteRenderer>().sprite = inf.sprites[(int)state];
        // Base.GetComponentInChildren<SpriteRenderer>().color= new Color(0, 0, 0);
    }

    private static void ActivateElement(ElementBase element, Surround surround, Vector2Int unitCoord)
    {
        element.gameObject.SetActive(true);
        element.IsActive = true;
        element.gameObject.transform.position = new Vector2(surround.localPosition.x + unitCoord.x*MapManager.tileMapWidth, surround.localPosition.y + unitCoord.y * MapManager.tileMapWidth);
        ApplyInfoToBase(element.gameObject, surround.name, surround.state);
    }
    private static void DeleteElement(GameObject gameObject)
    {
        string name = gameObject.name;
        basesForElements[name].IsActive = false;
        basesForElements[name].gameObject.SetActive(false);
    }


    //public static void PrintEnvironment(Vector2[] Positions, string[] names, EnviromentState[] states)
    //{
    //    for (int i = 0; i < Positions.Length; i++)
    //    {

    //    }
    //}
}
