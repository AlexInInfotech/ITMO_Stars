
using UnityEngine;
public class MapManager : MonoBehaviour
{
    //[SerializeField] MapRender visualisation;
    //[SerializeField] MapRender bigCart;

    //public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    [SerializeField] Material waterMaterial;
    [SerializeField] Material sandMaterial;
    [SerializeField] Material earthMaterial;

    [SerializeField] MapCharcteristics mainMapCharc;
    [SerializeField] MapCharcteristics riverMapCharac;
    [SerializeField] MapCharcteristics biomMapCharac;
    [SerializeField] MapCharcteristics environmentMapCharac;
    [SerializeField] Transform playerTransform;
    [SerializeField] float LoadRadius;
    const byte mapScale = 30;
    public const int tileMapWidth = 4 * mapScale;
    public const int typeMapWidth = tileMapWidth + 4;
    //FloatMap map = new FloatMap();
    //FloatMap biom = new FloatMap();
    //[SerializeField] Vector2Int MiniOffset = Vector2Int.zero;
    ////[SerializeField] int offsetScale;
    ///
    Vector2Int offset;
    Vector2Int transitOffset;
    WorldUnit currentUnit;
   

    private void SetConst()
    {
        MapGenerator.SetMapsCharcteristics(mainMapCharc, riverMapCharac, biomMapCharac, environmentMapCharac);
    }
    private void Start()
    {
        SetConst();
        currentUnit = WorldUnit.GetWorldUnit(Vector2Int.zero);
        currentUnit.PrintUnit();
        MapTransitions.SetMaterials(waterMaterial, sandMaterial, earthMaterial);
        //MapTransitions.spriteRenderer = spriteRenderer;
        MapTransitions.UpdateTransitMap(currentUnit.coord, true);
        //MapGenerator.GeneratePerlinMaps(ref map, ref biom, Vector2Int.zero);
        //visualisation.RenderMap(map.width, map.values);
        //PrintBigMap();

    }
    private void Update()
    {
        //MapGenerator.GeneratePerlinMaps(ref map, ref biom, MiniOffset);
        //visualisation.RenderMap(currentUnit.width, map.values);

        //PrintBigMap();
        //SetConst();


        UpdateCurrentUnit();
        LoadNearestUnits();


    }
    public static BiomType GetBiomOnPosition(Vector2 localPosition, WorldUnit unit)
    {
        int ArrayCoord = ((int)localPosition.x + tileMapWidth * (int)localPosition.y) ;
        return (BiomType)(unit.transitMap[ArrayCoord].r * (int)BiomType.CountElements);
    }
    public static TileType GetBaseTypeOnPosition(Vector2 localPosition, WorldUnit unit)
    {
        int ArrayCoord = ((int)localPosition.x + tileMapWidth * (int)localPosition.y) / 1;
        return unit.tilesData[ArrayCoord].tileType;
    }
    private void LoadNearestUnits()
    {
        if (playerTransform.position.x <= currentUnit.coord.x * tileMapWidth + LoadRadius)
            offset.x = -1;
        if (playerTransform.position.x >= (currentUnit.coord.x + 1) * tileMapWidth - LoadRadius)
            offset.x = 1;
        if (playerTransform.position.y <= currentUnit.coord.y * tileMapWidth + LoadRadius)
            offset.y = -1;
        if (playerTransform.position.y >= (currentUnit.coord.y + 1) * tileMapWidth - LoadRadius)
            offset.y = 1;

        if (offset != new Vector2Int(0, 0))
        {
            Vector2Int offsetX = new Vector2Int(offset.x, 0);
            Vector2Int offsetY = new Vector2Int(0, offset.y);
            bool IsNewUnitCreated = !WorldUnit.GetWorldUnit(currentUnit.coord + offsetX).isActive || !WorldUnit.GetWorldUnit(currentUnit.coord + offsetY).isActive || !WorldUnit.GetWorldUnit(currentUnit.coord + offsetY + offsetX).isActive;
            if (!WorldUnit.GetWorldUnit(currentUnit.coord + offsetX).isActive)
                WorldUnit.GetWorldUnit(currentUnit.coord + offsetX).PrintUnit();
            if (!WorldUnit.GetWorldUnit(currentUnit.coord + offsetY).isActive)
                WorldUnit.GetWorldUnit(currentUnit.coord + offsetY).PrintUnit();
            if (!WorldUnit.GetWorldUnit(currentUnit.coord + offsetY + offsetX).isActive)
                WorldUnit.GetWorldUnit(currentUnit.coord + offsetY + offsetX).PrintUnit();
            // WorldUnit.ClearFarUnits(CurrentUnit.Coord);
            transitOffset = Vector2Int.zero;
            if (offset.x < 0)
                transitOffset.x = -1;
            if (offset.y < 0)
                transitOffset.y = -1;
            MapTransitions.UpdateTransitMap(currentUnit.coord + transitOffset, IsNewUnitCreated);
            //Debug.Log(currentUnit.Coord + transitOffset);
            offset.x = 0;
            offset.y = 0;
        }

    }
    private void UpdateCurrentUnit()
    {
        if (playerTransform.position.x <= currentUnit.coord.x * tileMapWidth)
            offset.x = -1;
        if (playerTransform.position.x >= (currentUnit.coord.x + 1) * tileMapWidth)
            offset.x = 1;
        if (playerTransform.position.y <= currentUnit.coord.y * tileMapWidth)
            offset.y = -1;
        if (playerTransform.position.y >= (currentUnit.coord.y + 1) * tileMapWidth)
            offset.y = 1;
        if (offset != new Vector2Int(0, 0))
        {
            currentUnit = WorldUnit.GetWorldUnit(currentUnit.coord + offset);
            if (!currentUnit.isActive)
                currentUnit.PrintUnit();
        }
        offset.x = 0;
        offset.y = 0;
    }
    //void PrintBigMap()
    //{

    //    FloatMap bmap = new FloatMap();
    //    FloatMap bbiom = new FloatMap();

    //    MapGenerator.BigCart(ref bmap, ref bbiom, Vector2Int.zero);
    //    bigCart.RenderMap(bbiom.width, bbiom.values);
    //}
    
}