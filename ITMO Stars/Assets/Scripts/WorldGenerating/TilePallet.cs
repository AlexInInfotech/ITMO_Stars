using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilePallet
{
    public static TileStates tileStates;
    public static int CountBioms;
    public static BiomColors WaterBioms = new BiomColors();
    public static BiomColors SandBioms = new BiomColors();
    public static BiomColors EarthBioms = new BiomColors();
    public static TileBase GetTileBase(TileForm tileform)
    {
        switch (tileform)
        {
            case TileForm.Fill:
                return tileStates.Fill;
            case TileForm.Corner_LeftBottom:
                return tileStates.Corner_LeftBottom;
            case TileForm.Corner_LeftTop:
                return tileStates.Corner_LeftTop;
            case TileForm.Corner_RightBottom:
                return tileStates.Corner_RightBottom;
            case TileForm.Corner_RightTop:
                return tileStates.Corner_RightTop;
            case TileForm.Wall_Bottom:
                return tileStates.Wall_Bottom;
            case TileForm.Wall_Left:
                return tileStates.Wall_Left;
            case TileForm.Wall_Right:
                return tileStates.Wall_Right;
            case TileForm.Wall_Top:
                return tileStates.Wall_Top;
            /*     case TileForm.Rit_LeftBottom:
                     return Rit_LeftBottom[index];
                 case TileForm.Rit_LeftTop:
                     return Rit_LeftTop[index];
                 case TileForm.Rit_RightBottom:
                     return Rit_RightBottom[index];
                 case TileForm.Rit_RightTop:
                     return Rit_RightTop[index];*/
            default:
                return null;
        }
    }
}