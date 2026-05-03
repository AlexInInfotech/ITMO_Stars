using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] EnvironmentInfo[] _elementInfo;
    //private static EnvironmentInfo[] elementInfo;
    public static float bushLow;
    public static float treeLow;
    public static float bushHight;
    public static float treeHight;
    public float _bushHight;
    public float _treeHight;
    public float _bushLow;
    public float _treeLow;
    private class ElementBase
    {
        public GameObject gameObject;
        public bool IsActive = false;
        public Surround currentSurround;
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
   
    void Awake()
    {
        string name = "";
        bushLow = _bushLow;
        bushHight = _bushHight;
        treeLow = _treeLow;
        treeHight = _treeHight;
        foreach (EnvironmentInfo inf in _elementInfo)
        {
            name = inf.environmentType.ToString() + inf.baseType.ToString()+ inf.biomtype.ToString();
            elementInfo[name] = inf;
        }
        for (int i = 0; i < transform.childCount; i++)
            basesForElements[transform.GetChild(i).name] = new ElementBase(transform.GetChild(i).gameObject);
        managerTransform = GetComponent<Transform>();
    }
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
    public static EnvironmentType GetEnvironmentType(float value)
    {
        if (bushLow < value && value < bushHight)
            return EnvironmentType.bush;
        else if (treeLow < value && value < treeHight)
            return EnvironmentType.tree;
        return EnvironmentType.none;
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
    public static void ChangeSurroundstate(string name, EnviromentState state)
    {
        basesForElements[name].currentSurround.state = state;
        ApplyInfoToBase(basesForElements[name].gameObject, basesForElements[name].currentSurround.name, state);
    }
    private static void SetSurround(Surround surround, Vector2Int unitCoord)
    {
        if (GetElementInfo(surround.name) == null)
            return;
        int i = 0;
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
    public static void ClearSurrounds(Vector2Int unitCoord)
    {
        int i = 0;
        while (basesForElements.ContainsKey(i.ToString() + ELEMENT))
        {
            //bool t = Math.Floor(basesForElements[i.ToString() + ELEMENT].gameObject.transform.position.x / MapManager.tileMapWidth) == unitCoord.x
            //    && Math.Floor(basesForElements[i.ToString() + ELEMENT].gameObject.transform.position.y / MapManager.tileMapWidth) == unitCoord.y;
            //Debug.Log(basesForElements[i.ToString() + ELEMENT].gameObject.transform.position + "  " + MapManager.tileMapWidth + " " + unitCoord + "  " + t);
            if (Math.Floor(basesForElements[i.ToString() + ELEMENT].gameObject.transform.position.x / MapManager.tileMapWidth) == unitCoord.x
                && Math.Floor(basesForElements[i.ToString() + ELEMENT].gameObject.transform.position.y / MapManager.tileMapWidth) == unitCoord.y)
                DeleteElement(i.ToString() + ELEMENT);
            i++;
        }
    }
    private static void ApplyInfoToBase(GameObject Base, string elementName, EnviromentState state = EnviromentState.unharmed)
    {
        EnvironmentInfo inf = GetElementInfo(elementName);
        Base.gameObject.SetActive(true);
        Base.GetComponent<BoxCollider2D>().offset = inf.ColliderOffset;
        Base.GetComponent<BoxCollider2D>().size = inf.ColliderSize;
        Base.GetComponent<AbstractDamagable>().MaxHealth = inf.MaxHealth;
        Base.GetComponent<SpriteRenderer>().sprite = inf.sprites[(int)state];
        // Base.GetComponentInChildren<SpriteRenderer>().color= new Color(0, 0, 0);
    }

    private static void ActivateElement(ElementBase element, Surround surround, Vector2Int unitCoord)
    {
        element.gameObject.SetActive(true);
        element.currentSurround = surround;
        element.IsActive = true;
        element.gameObject.transform.position = new Vector2(surround.localPosition.x + unitCoord.x*MapManager.tileMapWidth, surround.localPosition.y + unitCoord.y * MapManager.tileMapWidth);
        ApplyInfoToBase(element.gameObject, surround.name, surround.state);
    }
    private static void DeleteElement(string name)
    {
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
