using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap _WaterTilemap;
    public Tilemap _SandTilemap;
    public Tilemap _EarthTilemap;
    public Material WaterMaterial;
    public Material SandMaterial;
    public Material EarthMaterial;

    static float RiverLow;
    static float RiverHight;
    static float BiomLow;
    static float WaterHight;
    static float SandHight;
    static Tilemap WaterTilemap;
    static Tilemap SandTilemap;
    static Tilemap EarthTilemap;

    public float _RiverLow = 0.43f;
    public float _RiverHight = 0.54f;
    public float _BiomLow = 0.3f;
    public float _WaterHight = 0.14f;
    public float _SandHight = 0.4f;

    public TileBase Fill;
    public TileBase Wall_Right;
    public TileBase Wall_Top;
    public TileBase Wall_Left;
    public TileBase Wall_Bottom;
    public TileBase Corner_RightBottom;
    public TileBase Corner_RightTop;
    public TileBase Corner_LeftTop;
    public TileBase Corner_LeftBottom;
    //private void SetConst()
    //{
    //    RiverLow = _RiverLow;
    //    RiverHight = _RiverHight;
    //    BiomLow = _BiomLow;
    //    WaterHight = _WaterHight;
    //    SandHight = _SandHight;
    //    WaterTilemap = _WaterTilemap;
    //    SandTilemap = _SandTilemap;
    //    EarthTilemap = _EarthTilemap;
    //}
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
    //private void PushTileBases()
    //{
    //    TilePallet.CountBioms = 2;
    //    TilePallet.Water.tilemap = _WaterTilemap;
    //    TilePallet.Water.CountStates = WaterTexture.depth;
    //    TilePallet.Water.Filled = waterFill;

    //}



    //public static void PrintWorldUnit(WorldUnit unit)
    //{
    //    Vector3Int[] WaterPos = new Vector3Int[unit.TilesData.Length];
    //    Vector3Int[] SandPos = new Vector3Int[unit.TilesData.Length];
    //    Vector3Int[] EarthPos = new Vector3Int[unit.TilesData.Length];
    //    TileBase[] WaterBases = new TileBase[unit.TilesData.Length];
    //    TileBase[] SandBases = new TileBase[unit.TilesData.Length];
    //    TileBase[] EarthBases = new TileBase[unit.TilesData.Length];
    //    int WaterI = 0;
    //    int SandI = 0;
    //    int EarthI = 0;
    //    int OffsetX = MapManager.TileMapWidth * unit.Coord.x;
    //    int OffsetY = MapManager.TileMapWidth * unit.Coord.y;
    //    for (int y = 0; y < MapManager.TileMapWidth; y++)
    //        for (int x = 0; x < MapManager.TileMapWidth; x++)
    //            switch (unit.TilesData[x + y * MapManager.TileMapWidth].TileType)
    //            {
    //                case TileType.water:
    //                    WaterPos[WaterI].x = OffsetX + x;
    //                    WaterPos[WaterI].y = OffsetY + y;
    //                    WaterBases[WaterI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
    //                    WaterI++;
    //                    break;
    //                case TileType.sand:
    //                    SandPos[SandI].x = OffsetX + x;
    //                    SandPos[SandI].y = OffsetY + y;
    //                    SandBases[SandI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
    //                    SandI++;
    //                    break;
    //                case TileType.earth:
    //                    EarthPos[EarthI].x = OffsetX + x;
    //                    EarthPos[EarthI].y = OffsetY + y;
    //                    EarthBases[EarthI] = unit.TilesData[x + y * MapManager.TileMapWidth].Tile;
    //                    EarthI++;
    //                    break;
    //            }
    //    WaterTilemap.SetTiles(WaterPos, WaterBases);
    //    SandTilemap.SetTiles(SandPos, SandBases);
    //    EarthTilemap.SetTiles(EarthPos, EarthBases);
    //    for (int y = 0; y < MapManager.TileMapWidth; y++)
    //        for (int x = 0; x < MapManager.TileMapWidth; x++)
    //        {
    //            Debug.Log(unit.TilesData[x + y * MapManager.TileMapWidth].States3);
    //            unit.TilesData[x + y * MapManager.TileMapWidth].Tilemap.SetColor(new Vector3Int(x + OffsetX, y + OffsetY), unit.TilesData[x + y * MapManager.TileMapWidth].States3);
    //        }
    //    unit.IsActive = true;

    //}


    //public static void ClearPart(Vector2Int offset)
    //{
    //    Vector3Int[] Pos = new Vector3Int[MapManager.TileMapWidth * MapManager.TileMapWidth];
    //    TileBase[] Bases = new TileBase[Pos.Length];
    //    int OffsetX = MapManager.TileMapWidth * offset.x;
    //    int OffsetY = MapManager.TileMapWidth * offset.y;
    //    for (int y = 0; y < MapManager.TileMapWidth; y++)
    //        for (int x = 0; x < MapManager.TileMapWidth; x++)
    //        {
    //            Pos[x + y * MapManager.TileMapWidth].x = x + OffsetX;
    //            Pos[x + y * MapManager.TileMapWidth].y = y + OffsetY;
    //        }
    //    WaterTilemap.SetTiles(Pos, Bases);
    //    SandTilemap.SetTiles(Pos, Bases);
    //    EarthTilemap.SetTiles(Pos, Bases);
    //}


}
