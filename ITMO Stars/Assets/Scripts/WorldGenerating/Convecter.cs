public static class Convecter 
{
    private static void SetNeighbors(int CoordMiddle, int width, TileType[] Grounds, BiomType[] Bioms, ref TileType[] neighbors, ref BiomType[] bioms)
    {
        for (byte y = 0; y < 3; y++)
            for (byte x = 0; x < 3; x++)
            {
                neighbors[y * 3 + x] = Grounds[CoordMiddle + width * (1 - y) + x - 1];
                bioms[y * 3 + x] = Bioms[CoordMiddle + width * (1 - y) + x - 1];
            }
    }
    //public static void ConvertPerlinToTypes(FloatMap GroundMap, FloatMap BiomMap, ref TileType[] Grounds, ref BiomType[] Bioms)
    //{
    //    for (int y = 0; y < MapManager.tileMapWidth + 2; y++)
    //        for (int x = 0; x < MapManager.tileMapWidth + 2; x++)
    //        {
    //            Grounds[x + y * (MapManager.tileMapWidth + 2)] = GetTileType(GroundMap.values[x / GroundMap.size + (y / GroundMap.size) * GroundMap.width]);
    //            Bioms[x + y * (MapManager.tileMapWidth + 2)] = GetBiomType(BiomMap.values[x / BiomMap.size + (y / BiomMap.size) * BiomMap.width]);
    //        }
    //}
    public static GroundData[] GetGroundData(TileType[] MainMap, BiomType[] BiomMap, int WidthTypeMaps)
    {
        GroundData[] TileMap = new GroundData[(WidthTypeMaps - 2) * (WidthTypeMaps - 2)];
        TileType[] neighbors = new TileType[9];
        BiomType[] bioms = new BiomType[9];
        for (int y = 1; y < WidthTypeMaps - 1; y++)
        {
            for (int x = 1; x < WidthTypeMaps - 1; x++)
            {
                SetNeighbors(x + y * WidthTypeMaps, WidthTypeMaps, MainMap, BiomMap, ref neighbors, ref bioms);
                TileMap[x - 1 + (y - 1) * (WidthTypeMaps - 2)] = TileControl.GetCorrectTiles(neighbors, bioms);
            }
        }
        return TileMap;
    }

}
