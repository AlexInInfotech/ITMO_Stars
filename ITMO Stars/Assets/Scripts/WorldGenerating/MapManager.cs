
using System;
using System.Drawing;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] MapRender Visualisation;
    [SerializeField] MapCharcteristics mainMapCharc;
    [SerializeField] MapCharcteristics riverMapCharac;
    [SerializeField] MapCharcteristics biomMapCharac;
    [SerializeField] Transform playerTransform;
    [SerializeField] const byte mapScale = 1;
    public const int tileMapWidth = 4 * mapScale + 2;
    public const int typeMapWidth = tileMapWidth + 2;

    FloatMap map = new FloatMap();
    FloatMap biom = new FloatMap();
    Vector2Int offset;
    WorldUnit CurrentUnit;
    private void SetConst()
    {
        MapGenerator.SetMapsCharcteristics(mainMapCharc, riverMapCharac, biomMapCharac);
        //OffsetConst = (2 * Koefficient - 1) / main_scale; // (нок(mainSize, BiomSize) * Koef - 2 / ...Size) / ...Scale
        //OffsetBiom = (Koefficient - 1) / biom_scale;
        //OffsetRiver = (2 * Koefficient - 1) / river_scale;
        //TileMapWidth = Koefficient * 4 - 2;
        // NoiseWidth = (TileMapWidth + 2) / MainSize;
    }
    private void Start()
    {
        SetConst();
        CurrentUnit= WorldUnit.GetWorldUnit(Vector2Int.zero);
        TileManager.PrintWorldUnit(CurrentUnit);
        //MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2.zero);
        //Visualisation.RenderMap(map.width, map.values);
    }
    private void Update()
    {
        //  CheckOffset(new Vector2(x,u)); 
        //  RiverMapCharac = new MapCharcteristics(river_seed, river_scale, river_octaves, river_persistence, river_lacunarity);
        if (playerTransform.position.x <= CurrentUnit.Coord.x * tileMapWidth)
            offset.x = -1;
        if (playerTransform.position.x >= (CurrentUnit.Coord.x + 1) * tileMapWidth)
            offset.x = 1;
        if (playerTransform.position.y <= CurrentUnit.Coord.y * tileMapWidth)
            offset.y = -1;
        if (playerTransform.position.y >= (CurrentUnit.Coord.y + 1) * tileMapWidth)
            offset.y = 1;
        if (offset != new Vector2Int(0, 0))
        {
            CurrentUnit = WorldUnit.GetWorldUnit(CurrentUnit.Coord + offset);
            if (!CurrentUnit.IsActive)
                TileManager.PrintWorldUnit(CurrentUnit);
            WorldUnit.ClearFarUnits(CurrentUnit.Coord);
            offset.x = 0;
            offset.y = 0;
        }
    }
    //private void Update()
    //{
    //    MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2.zero);
    //    Visualisation.RenderMap(map.width, map.values);

    //}
}