
using System;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MapManager : MonoBehaviour
{
    //[SerializeField] MapRender visualisation;
    //[SerializeField] MapRender bigCart;

    [SerializeField] Material waterMaterial;
    const string TRANSITMAP = "_TransitMap";

    [SerializeField] MapCharcteristics mainMapCharc;
    [SerializeField] MapCharcteristics riverMapCharac;
    [SerializeField] MapCharcteristics biomMapCharac;
    [SerializeField] Transform playerTransform;
    [SerializeField] const byte mapScale = 10;
    public const int tileMapWidth = 4 * mapScale;
    public const int typeMapWidth = tileMapWidth + 4;

    //FloatMap map = new FloatMap();
    //FloatMap biom = new FloatMap();
    //[SerializeField] Vector2Int MiniOffset = Vector2Int.zero;
    ////[SerializeField] int offsetScale;
    ///
    Vector2Int offset;
    WorldUnit CurrentUnit;

    private void SetTransitionMap()
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colors);
        texture.Apply();
        waterMaterial.SetTexture(TRANSITMAP, texture);
    }
    private void SetConst()
    {
        MapGenerator.SetMapsCharcteristics(mainMapCharc, riverMapCharac, biomMapCharac);
    }
    private void Start()
    {
        SetConst();
        CurrentUnit = WorldUnit.GetWorldUnit(Vector2Int.zero);
        TileManager.PrintWorldUnit(CurrentUnit);


        //MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2Int.zero);
        //visualisation.RenderMap(map.width, map.values);
        //PrintBigMap();

    }
    private void Update()
    {
        //MapGenerator.GeneratePerlinMaps(ref map, ref biom, MiniOffset);
        //visualisation.RenderMap(map.width, map.values);

        //PrintBigMap();
        //SetConst();


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
            // WorldUnit.ClearFarUnits(CurrentUnit.Coord);
            offset.x = 0;
            offset.y = 0;
        }
    }
    //void PrintBigMap()
    //{

    //    FloatMap bmap = new FloatMap();
    //    FloatMap bbiom = new FloatMap();

    //    MapGenerator.BigCart(ref bmap, ref bbiom, Vector2Int.zero);
    //    bigCart.RenderMap(bbiom.width, bbiom.values);
    //}
    
}