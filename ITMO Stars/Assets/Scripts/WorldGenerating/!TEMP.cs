using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;

public class TEMP : MonoBehaviour
{
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
