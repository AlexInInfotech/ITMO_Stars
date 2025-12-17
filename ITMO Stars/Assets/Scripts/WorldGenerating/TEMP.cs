using UnityEngine;

public class TEMP : MonoBehaviour
{
   // public static WorldUnit CurrentUnit;
    public static int TileMapWidth;
    public static int NoiseWidth;
    public static int MainSize = 2;
    public static int BiomSize = 4;
    public static float OffsetConst;
    public static float OffsetBiom;
    public static float OffsetRiver;
    private static MapCharcteristics MainMapCharac;
    private static MapCharcteristics RiverMapCharac;
    private static MapCharcteristics UsualMapCharac;
    private static MapCharcteristics AtlanticMapCharac;
    private static MapCharcteristics BloodMapCharac;
    public Transform PlayerTrans;
    public int Koefficient;

    public int _MainSize;
    public int _BiomSize;

    [Header("Main Settings")]
    public float main_scale;
    public byte main_octaves;
    public float main_persistence;
    public float main_lacunarity;
    public int main_seed;

    [Header("River Settings")]
    public float river_scale;
    public byte river_octaves;
    public float river_persistence;
    public float river_lacunarity;
    public int river_seed;

    [Header("Biom Settings")]
    public float biom_scale;
    public byte biom_octaves;
    public float biom_persistence;
    public float biom_lacunarity;
    public int biom_seed;


    private Vector2Int offset = new Vector2Int(0, 0);

    private void Awake()
    {
      //  SetConst();

    }
    private void Start()
    {
      //  CurrentUnit = null; // WorldUnit.GetWorldUnit(new Vector2Int(0, 0));
                            // TileManager.PrintWorldUnit(CurrentUnit);


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

    //}
    //private void SetConst()
    //{
    //    OffsetConst = (2 * Koefficient - 1) / main_scale; // (нок(mainSize, BiomSize) * Koef - 2 / ...Size) / ...Scale
    //    OffsetBiom = (Koefficient - 1) / biom_scale;
    //    OffsetRiver = (2 * Koefficient - 1) / river_scale;
    //    MainMapCharac = new MapCharcteristics(main_seed, main_scale, main_octaves, main_persistence, main_lacunarity);
    //    RiverMapCharac = new MapCharcteristics(river_seed, river_scale, river_octaves, river_persistence, river_lacunarity);
    //    UsualMapCharac = new MapCharcteristics(biom_seed, biom_scale, biom_octaves, biom_persistence, biom_lacunarity);
    //    AtlanticMapCharac = new MapCharcteristics(biom_seed + 30, biom_scale, biom_octaves, biom_persistence, biom_lacunarity);
    //    BloodMapCharac = new MapCharcteristics(biom_seed + 40, biom_scale, biom_octaves, biom_persistence, biom_lacunarity);
    //    TileMapWidth = Koefficient * 4 - 2;
    //    // NoiseWidth = (TileMapWidth + 2) / MainSize;
    //}
    //private void CheckOffset(Vector2 offset)
    //{
    //    PerlinMap MainMap = new PerlinMap();
    //    MainMap.size = MainSize;
    //    MainMap.width = (TileMapWidth + 2) / MainSize;
    //    MainMap.floatArray = MapGenerator.Generate(MainMap.width, MainMapCharac, offset * OffsetConst);
    //    float[] RiverMap = MapGenerator.Generate(MainMap.width, RiverMapCharac, offset * OffsetRiver);
    //    MapGenerator.UniteMainWidthRiver(MainMap.floatArray, RiverMap);
    //    mp.RenderMap(MapType.Noise, MainMap);

    //}

    //public static void GeneratePerlinMaps(ref PerlinMap MainMap, ref PerlinMap BiomMap, Vector2 Coord)
    //{
    //    MainMap.size = MainSize;
    //    BiomMap.size = BiomSize;
    //    MainMap.width = (TileMapWidth + 2) / MainSize;
    //    BiomMap.width = (TileMapWidth + 2) / BiomSize;
    //    // BiomMap.floatArray = MapGenerator.Generate(BiomMap.width, BiomMapCharac, Coord * OffsetBiom);
    //    MainMap.floatArray = MapGenerator.Generate(MainMap.width, MainMapCharac, Coord * OffsetConst);
    //    float[] RiverMap = MapGenerator.Generate(MainMap.width, RiverMapCharac, Coord * OffsetRiver);
    //    float[][] BiomMaps = new float[2][];
    //    BiomMaps[0] = MapGenerator.Generate(BiomMap.width, UsualMapCharac, Coord * OffsetBiom);
    //    BiomMaps[1] = MapGenerator.Generate(BiomMap.width, AtlanticMapCharac, Coord * OffsetBiom);
    //    // BiomMaps[2] = MapGenerator.Generate(BiomMap.width, BloodMapCharac, Coord * OffsetBiom);
    //    MapGenerator.UniteMainWidthRiver(MainMap.floatArray, RiverMap);
    //    BiomMap.floatArray = MapGenerator.UniteBioms(BiomMap.width, BiomMaps);

    //}
}
