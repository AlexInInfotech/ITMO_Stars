
using System;
using System.Drawing;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] MapRender Visualisation;
    [SerializeField] MapCharcteristics mainMapCharc;
    [SerializeField] MapCharcteristics riverMapCharac;
    [SerializeField] MapCharcteristics biomMapCharac;
    [SerializeField] byte mapScale = 1;
    public static int tileMapWidth { get; private set; }

    FloatMap map = new FloatMap();
    FloatMap biom = new FloatMap();
    private void SetConst()
    {
        MapGenerator.SetMapsCharcteristics(mainMapCharc, riverMapCharac, biomMapCharac);
        tileMapWidth = 4*mapScale + 2;
        //OffsetConst = (2 * Koefficient - 1) / main_scale; // (нок(mainSize, BiomSize) * Koef - 2 / ...Size) / ...Scale
        //OffsetBiom = (Koefficient - 1) / biom_scale;
        //OffsetRiver = (2 * Koefficient - 1) / river_scale;
        //TileMapWidth = Koefficient * 4 - 2;
        // NoiseWidth = (TileMapWidth + 2) / MainSize;
    }
    //private void Update()
    //{
    //    //  CheckOffset(new Vector2(x,u)); 
    //    //  RiverMapCharac = new MapCharcteristics(river_seed, river_scale, river_octaves, river_persistence, river_lacunarity);
    //    if (PlayerTrans.position.x <= CurrentUnit.Coord.x * TileMapWidth)
    //        offset.x = -1;
    //    if (PlayerTrans.position.x >= (CurrentUnit.Coord.x + 1) * TileMapWidth )
    //        offset.x = 1;
    //    if (PlayerTrans.position.y <= CurrentUnit.Coord.y * TileMapWidth)
    //        offset.y = -1;
    //    if (PlayerTrans.position.y >= (CurrentUnit.Coord.y + 1) * TileMapWidth)
    //        offset.y = 1;
    //    if (offset != new Vector2Int(0, 0))
    //    {
    //        CurrentUnit = WorldUnit.GetWorldUnit(CurrentUnit.Coord + offset);
    //        if (!CurrentUnit.IsActive)
    //            TileManager.PrintWorldUnit(CurrentUnit);
    //        //Stopwatch stopwatch = Stopwatch.StartNew();
    //        //stopwatch.Stop();
    //       // UnityEngine.Debug.Log("SetTile " + stopwatch.ElapsedMilliseconds);
    //        WorldUnit.ClearFarUnits(CurrentUnit.Coord);
    //        offset.x = 0;
    //        offset.y = 0;
    //    }
    private void Start()
    {
        SetConst();
        MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2.zero);
        Visualisation.RenderMap(map.width, map.values);
    }
    private void Update()
    {
        MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2.zero);
        Visualisation.RenderMap(map.width, map.values);

    }
}