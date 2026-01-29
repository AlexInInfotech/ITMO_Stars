public static class Convecter 
{
    private static void SetNeighbors(int CoordMiddle, TileType[] Grounds, BiomType[] Bioms, ref TileType[] neighbors, ref BiomType[] bioms)
    {
        for (byte y = 0; y < 3; y++)
            for (byte x = 0; x < 3; x++)
            {
                neighbors[y * 3 + x] = Grounds[CoordMiddle + MapManager.typeMapWidth * (1 - y) + x - 1];
                bioms[y * 3 + x] = Bioms[CoordMiddle + MapManager.typeMapWidth * (1 - y) + x - 1];
            }
    }
    private static void FloatToTypes(FloatMap GroundMap, FloatMap BiomMap, ref TileType[] Grounds, ref BiomType[] Bioms)
    {
        for (int y = 0; y < MapManager.typeMapWidth; y++)
            for (int x = 0; x < MapManager.typeMapWidth; x++)
            {
                Grounds[x + y * (MapManager.typeMapWidth)] = TileManager.GetTileType(GroundMap.values[x / GroundMap.size + (y / GroundMap.size) * GroundMap.width]);
                Bioms[x + y * (MapManager.typeMapWidth)] = TileManager.GetBiomType(BiomMap.values[x / BiomMap.size + (y / BiomMap.size) * BiomMap.width]);
            }
    }
    public static GroundData[] GetGroundData(FloatMap MainMap, FloatMap BiomMap)
    {
        TileType[] types = new TileType[MapManager.typeMapWidth* MapManager.typeMapWidth];
        BiomType[] bioms = new BiomType[types.Length];
        FloatToTypes(MainMap, BiomMap,ref types,ref bioms);
        GroundData[] TileMap = new GroundData[(MapManager.typeMapWidth - 4) * (MapManager.typeMapWidth - 4)];
        TileType[] neighbors = new TileType[9];
        BiomType[] biomNeighbors = new BiomType[9];
        for (int y = 2; y < MapManager.typeMapWidth - 2; y++)
        {
            for (int x = 2; x < MapManager.typeMapWidth - 2; x++)
            {
                SetNeighbors(x + y * MapManager.typeMapWidth, types, bioms, ref neighbors, ref biomNeighbors);
                TileMap[x - 2 + (y - 2) * (MapManager.typeMapWidth - 4)] = TileControl.GetTile(neighbors, biomNeighbors);
            }
        }
        return TileMap;
    }

}
