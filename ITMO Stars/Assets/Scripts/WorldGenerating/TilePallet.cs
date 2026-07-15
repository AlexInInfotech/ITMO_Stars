using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilePallet
{
    //public static TileStates tileStates;
    //public static int CountBioms;
    //public static BiomColors WaterBioms = new BiomColors();
    //public static BiomColors SandBioms = new BiomColors();
    //public static BiomColors EarthBioms = new BiomColors();
    public static TileKit WaterKit = new TileKit();
    public static TileKit SandKit = new TileKit();
    public static TileKit EarthKit = new TileKit();
    public static TileKit DefaultKit;

    public static TileBase GetTileBase(TileForm tileform)
    {
        switch (tileform)
        {
            case TileForm.Fill:
                return DefaultKit.Fill[0];
            case TileForm.Corner_LeftBottom:
                return DefaultKit.Corner_LeftBottom[0];
            case TileForm.Corner_LeftTop:
                return DefaultKit.Corner_LeftTop[0];
            case TileForm.Corner_RightBottom:
                return DefaultKit.Corner_RightBottom[0];
            case TileForm.Corner_RightTop:
                return DefaultKit.Corner_RightTop[0];
            case TileForm.Wall_Bottom:
                return DefaultKit.Wall_Bottom[0];
            case TileForm.Wall_Left:
                return DefaultKit.Wall_Left[0];
            case TileForm.Wall_Right:
                return DefaultKit.Wall_Right[0];
            case TileForm.Wall_Top:
                return DefaultKit.Wall_Top[0];
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
        public static TileBase GetTileBase(TileType type, TileForm tileform, BiomType biom)
    {
        TileKit tileStates;
        switch (type)
        {
            case TileType.water:
                tileStates = WaterKit;
                break;
            case TileType.sand:
                tileStates = SandKit;
                break;
            case TileType.earth:
                tileStates = EarthKit;
                break;
            default:
                tileStates = null;
                break;
        }
        switch (tileform)
        {
            case TileForm.Fill:
                return tileStates.Fill[(int)biom];
            case TileForm.Corner_LeftBottom:
                return tileStates.Corner_LeftBottom[(int)biom];
            case TileForm.Corner_LeftTop:
                return tileStates.Corner_LeftTop[(int)biom];
            case TileForm.Corner_RightBottom:
                return tileStates.Corner_RightBottom[(int)biom];
            case TileForm.Corner_RightTop:
                return tileStates.Corner_RightTop[(int)biom];
            case TileForm.Wall_Bottom:
                return tileStates.Wall_Bottom[(int)biom];
            case TileForm.Wall_Left:
                return tileStates.Wall_Left[(int)biom];
            case TileForm.Wall_Right:
                return tileStates.Wall_Right[(int)biom];
            case TileForm.Wall_Top:
                return tileStates.Wall_Top[(int)biom];
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