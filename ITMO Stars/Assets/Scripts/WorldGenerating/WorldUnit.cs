using UnityEngine;
using System.Collections.Generic;
public class WorldUnit
{
    public Vector2Int Coord;
    //public TileType[] TypeMap;
    //public BiomType[] BiomTypeMap;
    public GroundData[] TilesData;
    public Color[] transitMap;
    public bool IsActive = false;
    private static Dictionary<Vector2Int, WorldUnit> dictionary = new Dictionary<Vector2Int, WorldUnit>();
    private WorldUnit(Vector2Int _Coord)
    {
        Coord = _Coord;
        FloatMap MainMap = new FloatMap();
        FloatMap BiomMap = new FloatMap();
        MapGenerator.GeneratePerlinMaps(ref MainMap, ref BiomMap, Coord);
        TilesData = Convecter.GetGroundData(MainMap, BiomMap, out transitMap);
    }

    public static void ClearFarUnits(Vector2Int CurrentCoord)
    {
        foreach (var unit in dictionary)
        {
            if (unit.Value.IsActive
                && (unit.Key.x < CurrentCoord.x - 1) || (unit.Key.x > CurrentCoord.x + 1)
                || (unit.Key.y < CurrentCoord.y - 1) || (unit.Key.y > CurrentCoord.y + 1))
            {
                unit.Value.IsActive = false;
                TileManager.ClearPart(unit.Key);
            }
        }
    }
    public static WorldUnit GetWorldUnit(Vector2Int Coord)
    {
        if (dictionary.ContainsKey(Coord))
            return dictionary[Coord];
        else
        {
            WorldUnit unit = new WorldUnit(Coord);
            dictionary.Add(Coord, unit);
            return unit;
        }
    }

}