using UnityEngine;
using System.Collections.Generic;
public class WorldUnit
{
    public Vector2Int coord;
    //public TileType[] TypeMap;
    //public BiomType[] BiomTypeMap;
    public GroundData[] tilesData;
    public Color[] transitMap;
    public Surround[] surrounds;
    public MobsCluster mobsCluster;
    public bool isActive = false;



    private static Dictionary<Vector2Int, WorldUnit> dictionary = new Dictionary<Vector2Int, WorldUnit>();
    private WorldUnit(Vector2Int _coord)
    {
        coord = _coord;
        FloatMap MainMap = new FloatMap();
        FloatMap BiomMap = new FloatMap();
        mobsCluster = new MobsCluster(coord);
        MapGenerator.GenerateBaseMaps(ref MainMap, ref BiomMap, coord);
        tilesData = Convecter.GetGroundData(MainMap, BiomMap, out transitMap);
        surrounds = EnvitonmentControl.GetSurrounds(_coord, MainMap, BiomMap);
    }
    public void PrintUnit()
    {
        TileManager.PrintTiles(this);
        EnvironmentManager.PrintSurrounds(this);
        MobsManager.PrintMobCluster(mobsCluster);
    }
    public static bool ExsistWorldUnit(Vector2Int Coord)
    {
        return dictionary.ContainsKey(Coord);
    }

    public static void ClearFarUnits(Vector2Int CurrentCoord)
    {
        foreach (var unit in dictionary)
        {
            if (unit.Value.isActive
                && (unit.Key.x < CurrentCoord.x - 1) || (unit.Key.x > CurrentCoord.x + 1)
                || (unit.Key.y < CurrentCoord.y - 1) || (unit.Key.y > CurrentCoord.y + 1))
            {
                unit.Value.isActive = false;
                TileManager.ClearPart(unit.Key);
                EnvironmentManager.ClearSurrounds(unit.Key);
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