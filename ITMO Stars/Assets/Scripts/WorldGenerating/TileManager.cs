using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    static Tilemap waterTilemap;
    static Tilemap sandTilemap;
    static Tilemap earthTilemap;

    public Color[] WaterColors;
    public Color[] SandColors;
    public Color[] EarthColors;
    public Tilemap _WaterTilemap;
    public Tilemap _SandTilemap;
    public Tilemap _EarthTilemap;
    public Material WaterMaterial;
    public Material SandMaterial;
    public Material EarthMaterial;


    public static float RiverLow = 0.43f;
    public static float RiverHight = 0.54f;
    public static float BiomLow = 0.3f;
    public static float WaterHight =0;
    public static float SandHight = 0.4f;
    public float _RiverLow = 0.43f;
    public float _RiverHight = 0.54f;
    public  float _BiomLow = 0.3f;
    public  float _WaterHight =0;
    public  float _SandHight = 0.4f;

    [SerializeField]public TileStates tileStates;
    private void Awake()
    {

        RiverLow = _RiverLow;
        RiverHight = _RiverHight;
        BiomLow = _BiomLow;
        WaterHight = _WaterHight;
        SandHight = _SandHight;
        TileControl.SetRules();
        TilePallet.tileStates = tileStates;
        TilePallet.WaterBioms.colors = WaterColors;
        TilePallet.SandBioms.colors = SandColors;
        TilePallet.EarthBioms.colors = EarthColors;
        waterTilemap = _WaterTilemap;
        sandTilemap = _SandTilemap;
        earthTilemap = _EarthTilemap;

    }
    private void Update()
    {

        RiverLow = _RiverLow;
        RiverHight = _RiverHight;
        BiomLow = _BiomLow;
        WaterHight = _WaterHight;
        SandHight = _SandHight;
    }
    public static BiomType GetBiomType(float color)
    {
        if (color <= (int)BiomType.atlantic)
            return BiomType.usual;
        else if (color <= (int)BiomType.blood)
            return BiomType.atlantic;
        else
            // return BiomType.blood
            return BiomType.atlantic;
    }
    public static TileType GetTileType(float color)
    {
        if (color <= WaterHight)
            return TileType.water;
        else if (color <= SandHight)
            return TileType.sand;
        else
            return TileType.earth;
    }
    public static bool IsItRiver(float color)
    {
        return color <= RiverHight && color >= RiverLow;
    }
    public static bool IsItBiom(float color)
    {
        return color >= BiomLow;
    }
    public static TileType GetTileType(Vector2 WorldCoord, FloatMap map)
    {
        int ArrayCoord = ((int)WorldCoord.x + map.width * (int)WorldCoord.y) / map.size;
        return GetTileType(map.values[ArrayCoord]);
    }


    public static void PrintWorldUnit(WorldUnit unit)
    {
        Vector3Int[] WaterPos = new Vector3Int[unit.TilesData.Length];
        Vector3Int[] SandPos = new Vector3Int[unit.TilesData.Length];
        Vector3Int[] EarthPos = new Vector3Int[unit.TilesData.Length];
        TileBase[] WaterBases = new TileBase[unit.TilesData.Length];
        TileBase[] SandBases = new TileBase[unit.TilesData.Length];
        TileBase[] EarthBases = new TileBase[unit.TilesData.Length];
        int WaterI = 0;
        int SandI = 0;
        int EarthI = 0;
        int OffsetX = MapManager.tileMapWidth * unit.Coord.x;
        int OffsetY = MapManager.tileMapWidth * unit.Coord.y;
        for (int y = 0; y < MapManager.tileMapWidth; y++)
            for (int x = 0; x < MapManager.tileMapWidth; x++)
                switch (unit.TilesData[x + y * MapManager.tileMapWidth].tileType)
                {
                    case TileType.water:
                        WaterPos[WaterI].x = OffsetX + x;
                        WaterPos[WaterI].y = OffsetY + y;
                        WaterBases[WaterI] = unit.TilesData[x + y * MapManager.tileMapWidth].tileBase;
                        WaterI++;
                        break;
                    case TileType.sand:
                        SandPos[SandI].x = OffsetX + x;
                        SandPos[SandI].y = OffsetY + y;
                        SandBases[SandI] = unit.TilesData[x + y * MapManager.tileMapWidth].tileBase;
                        SandI++;
                        break;
                    case TileType.earth:
                        EarthPos[EarthI].x = OffsetX + x;
                        EarthPos[EarthI].y = OffsetY + y;
                        EarthBases[EarthI] = unit.TilesData[x + y * MapManager.tileMapWidth].tileBase;
                        EarthI++;
                        break;
                }
        waterTilemap.SetTiles(WaterPos, WaterBases);
        sandTilemap.SetTiles(SandPos, SandBases);
        earthTilemap.SetTiles(EarthPos, EarthBases);
        for (int y = 0; y < MapManager.tileMapWidth; y++)
            for (int x = 0; x < MapManager.tileMapWidth; x++)
                GetTileMap(unit.TilesData[x + y * MapManager.tileMapWidth].tileType).SetColor(new Vector3Int(x + OffsetX, y + OffsetY), unit.TilesData[x + y * MapManager.tileMapWidth].color);
        unit.IsActive = true;

    }

    private static Tilemap GetTileMap(TileType type)
    {
        if (type == TileType.water)
            return waterTilemap;
        else if (type == TileType.sand)
            return sandTilemap;
        else
            return earthTilemap;
    }
    public static void ClearPart(Vector2Int offset)
    {
        Vector3Int[] Pos = new Vector3Int[MapManager.tileMapWidth * MapManager.tileMapWidth];
        TileBase[] Bases = new TileBase[Pos.Length];
        int OffsetX = MapManager.tileMapWidth * offset.x;
        int OffsetY = MapManager.tileMapWidth * offset.y;
        for (int y = 0; y < MapManager.tileMapWidth; y++)
            for (int x = 0; x < MapManager.tileMapWidth; x++)
            {
                Pos[x + y * MapManager.tileMapWidth].x = x + OffsetX;
                Pos[x + y * MapManager.tileMapWidth].y = y + OffsetY;
            }
        waterTilemap.SetTiles(Pos, Bases);
        sandTilemap.SetTiles(Pos, Bases);
        earthTilemap.SetTiles(Pos, Bases);
    }


}
