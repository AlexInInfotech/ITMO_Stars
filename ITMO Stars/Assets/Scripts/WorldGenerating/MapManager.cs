
using UnityEngine;
using System;
public class MapManager : MonoBehaviour
{
    //[SerializeField] MapRender visualisation;
    //[SerializeField] MapRender bigCart;

    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    [SerializeField] Material waterMaterial;
    [SerializeField] Material sandMaterial;
    [SerializeField] Material earthMaterial;
    const string TRANSITMAP = "_TransitMap";
    const string TRANSITWIDTH = "_TileWidth";
    private static Color[] CurrentTransitMap;

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
        Color[] colors = {
            Color.yellow, Color.blue, Color.green, Color.red,
            Color.red,Color.green, Color.blue,  Color.yellow,
            Color.yellow, Color.blue, Color.green, Color.red,
            Color.red,Color.green, Color.blue,  Color.yellow,
        };
        Texture2D texture = new Texture2D((int)Math.Sqrt(CurrentTransitMap.Length), (int)Math.Sqrt(CurrentTransitMap.Length));
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(CurrentTransitMap);
        texture.Apply();
        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000.0f);
        waterMaterial.SetTexture(TRANSITMAP, texture);
        waterMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(CurrentTransitMap.Length));
        sandMaterial.SetTexture(TRANSITMAP, texture);
        sandMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(CurrentTransitMap.Length));
        earthMaterial.SetTexture(TRANSITMAP, texture);
        earthMaterial.SetInt(TRANSITWIDTH, (int)Math.Sqrt(CurrentTransitMap.Length));
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
        CurrentTransitMap = CurrentUnit.transitMap;
        SetTransitionMap();
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