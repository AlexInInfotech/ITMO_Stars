using UnityEngine;
using System;
public static class MapTransitions 
{
    //public static SpriteRenderer spriteRenderer;


    const string TRANSITMAP = "_TransitMap";
    const string TRANSITWIDTH = "_TileWidth";
    const string TRANSITCOORD = "_WorlCoordTransitMap";
    const string BIOMSCOUNT = "_BiomsCount";
    private static Color[] TransitMap = new Color[MapManager.tileMapWidth* MapManager.tileMapWidth*4];
    //private static Vector2Int previousCoord;
    static Material waterMaterial;
    static Material sandMaterial;
    static Material earthMaterial;
    public static void SetMaterials(Material _waterMaterial, Material _sandMaterial, Material _earthMaterial)
    {
        waterMaterial = _waterMaterial;
        sandMaterial = _sandMaterial;
        earthMaterial = _earthMaterial;
    }
    private static void SetTransitionMap(Vector4 coord)
    {
        Texture2D texture = new Texture2D((int)Math.Sqrt(TransitMap.Length), (int)Math.Sqrt(TransitMap.Length), TextureFormat.RGBA32, false, linear: true);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(TransitMap);
        texture.Apply();
        //spriteRenderer.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000.0f);
        waterMaterial.SetTexture(TRANSITMAP, texture);
        waterMaterial.SetVector(TRANSITCOORD, coord);
        waterMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(TransitMap.Length));
        waterMaterial.SetFloat(BIOMSCOUNT, (float)BiomType.CountElements);

        sandMaterial.SetTexture(TRANSITMAP, texture);
        sandMaterial.SetVector(TRANSITCOORD, coord);
        sandMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(TransitMap.Length));
        sandMaterial.SetFloat(BIOMSCOUNT, (float)BiomType.CountElements);

        earthMaterial.SetTexture(TRANSITMAP, texture);
        earthMaterial.SetVector(TRANSITCOORD, coord);
        earthMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(TransitMap.Length));
        earthMaterial.SetFloat(BIOMSCOUNT, (float)BiomType.CountElements);
    }

    public static void UpdateTransitMap(Vector2Int LeftBottomUnitCoord, bool ForseStart = false)
    {
       for (int x= 0;  x < MapManager.tileMapWidth * 2; x++)
            for(int y= 0; y < MapManager.tileMapWidth * 2; y++)
            {
                if (x <  MapManager.tileMapWidth  && y < MapManager.tileMapWidth && WorldUnit.ExsistWorldUnit(LeftBottomUnitCoord))
                    TransitMap[x + y*(MapManager.tileMapWidth * 2)] = WorldUnit.GetWorldUnit(LeftBottomUnitCoord).transitMap[x + y* MapManager.tileMapWidth];

                else if (x >= MapManager.tileMapWidth && y < MapManager.tileMapWidth && WorldUnit.ExsistWorldUnit(LeftBottomUnitCoord + new Vector2Int(1, 0)))
                    TransitMap[x + y * (MapManager.tileMapWidth * 2)] = WorldUnit.GetWorldUnit(LeftBottomUnitCoord + new Vector2Int(1, 0)).transitMap[x - MapManager.tileMapWidth + y * MapManager.tileMapWidth];

                else if (x < MapManager.tileMapWidth && y >= MapManager.tileMapWidth && WorldUnit.ExsistWorldUnit(LeftBottomUnitCoord + new Vector2Int(0, 1)))
                    TransitMap[x + y * (MapManager.tileMapWidth * 2)] = WorldUnit.GetWorldUnit(LeftBottomUnitCoord + new Vector2Int(0, 1)).transitMap[x + (y - MapManager.tileMapWidth) * MapManager.tileMapWidth];

                else if (x >= MapManager.tileMapWidth && y >= MapManager.tileMapWidth && WorldUnit.ExsistWorldUnit(LeftBottomUnitCoord + new Vector2Int(1, 1)))
                    TransitMap[x + y * (MapManager.tileMapWidth * 2)] = WorldUnit.GetWorldUnit(LeftBottomUnitCoord + new Vector2Int(1, 1)).transitMap[x - MapManager.tileMapWidth + (y - MapManager.tileMapWidth) * MapManager.tileMapWidth];

            }
        SetTransitionMap(new Vector4(LeftBottomUnitCoord.x, LeftBottomUnitCoord.y));
    }
}
