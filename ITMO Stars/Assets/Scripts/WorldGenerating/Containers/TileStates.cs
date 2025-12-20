using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class TileStates
{
    public TileBase Fill;
    public TileBase Wall_Right;
    public TileBase Wall_Top;
    public TileBase Wall_Left;
    public TileBase Wall_Bottom;
    public TileBase Corner_RightBottom;
    public TileBase Corner_RightTop;
    public TileBase Corner_LeftTop;
    public TileBase Corner_LeftBottom;
}
