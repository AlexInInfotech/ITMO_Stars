using System;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public static class MapGenerator
{
    private static MapCharcteristics mainMapCharac;
    private static MapCharcteristics riverMapCharac;
    private static MapCharcteristics biomMapCharac;

    public const byte mainMapSize = 2;
    public const byte biomMapSize = 4;
    public static void SetMapsCharcteristics(MapCharcteristics _MainMapCharac, MapCharcteristics _RiverMapCharac, MapCharcteristics _BiomMapCharac)
    {
        mainMapCharac = _MainMapCharac;
        riverMapCharac = _RiverMapCharac;
        biomMapCharac = _BiomMapCharac;
    }

    public static void GeneratePerlinMaps(ref FloatMap MainMap, ref FloatMap BiomMap, Vector2Int Coord)
    {
        MainMap.size = mainMapSize;
        BiomMap.size = biomMapSize;
        MainMap.width = (MapManager.tileMapWidth) / mainMapSize + 2;
        BiomMap.width = (MapManager.tileMapWidth ) / biomMapSize+ 2;
        MainMap.values = GetFloatMap(MainMap.width, mainMapCharac, Coord* (MainMap.width-2));
        float[] RiverMap = GetFloatMap(MainMap.width, riverMapCharac, Coord * (MainMap.width - 2));
        UniteMainWithRiver(MainMap.values, RiverMap);
        float[][] BiomsMaps = new float[1][];
        BiomsMaps[0] =  GetFloatMap(BiomMap.width, biomMapCharac, Coord*(BiomMap.width-2));
        BiomMap.values = MapGenerator.UniteBioms(BiomMap.width, BiomsMaps);

    }
    //public static void BigCart(ref FloatMap MainMap, ref FloatMap BiomMap, Vector2Int Coord)
    //{
    //    MainMap.size = mainMapSize;
    //    BiomMap.size = biomMapSize;
    //    MainMap.width = ((MapManager.tileMapWidth) / mainMapSize + 2)*10;
    //    BiomMap.width = ((MapManager.tileMapWidth) / biomMapSize + 2)*10;
    //    MainMap.values = GetFloatMap(MainMap.width, mainMapCharac, Coord * (MainMap.width - 2));
    //    BiomMap.values = GetFloatMap(BiomMap.width, biomMapCharac, Coord * (BiomMap.width - 2));
    //    float[] RiverMap = GetFloatMap(MainMap.width, riverMapCharac, Coord * (MainMap.width - 2));
    //    // BiomMaps[2] = MapGenerator.Generate(BiomMap.width, BloodMapCharac, Coord * OffsetBiom);

    //    MapGenerator.UniteMainWithRiver(MainMap.values, RiverMap);
    //    //BiomMap.floatArray = MapGenerator.UniteBioms(BiomMap.width, BiomMaps);

    //}
    private static void UniteMainWithRiver(float[] MainMap, float[] RiverMap)
    {
        for (int i = 0; i < MainMap.Length; i++)
            if (TileManager.IsItRiver(RiverMap[i]))
                MainMap[i] = 0;
    }
    private static float[] GetFloatMap(int width, MapCharcteristics mapCharac, Vector2Int offset)
    {
        float[] Map = new float[width * width];
        System.Random RandomCreature = new System.Random(mapCharac.seed);
        int random;
        Vector2Int[] octavesOffset = new Vector2Int[mapCharac.octaves];
        for (int i = 0; i < mapCharac.octaves; i++)
        {
            random = RandomCreature.Next(-100000, 100000);
            int xOffset = random + offset.x;
            int yOffset = random + offset.y;
            octavesOffset[i] = new Vector2Int(xOffset, yOffset);
        }
        if (mapCharac.scale < 0) mapCharac.scale = 0.0001f;

        int halfWidth = width / 2;
        int halfHeight = width / 2;

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                float superpositionCompensation = 0;

                for (int i = 0; i < mapCharac.octaves; i++)
                {
                    float xResult = (x - halfWidth  + octavesOffset[i].x) / mapCharac.scale * frequency;
                    float yResult = (y - halfHeight + octavesOffset[i].y) / mapCharac.scale * frequency;

                    float generatedValue = Mathf.PerlinNoise(xResult, yResult);
                    noiseHeight += generatedValue * amplitude;
                    noiseHeight -= superpositionCompensation;

                    amplitude *= mapCharac.persistence;
                    frequency *= mapCharac.lacunarity;
                    superpositionCompensation = amplitude / 2;
                }

                Map[y * width + x] = Mathf.Clamp01(noiseHeight);
            }
        }
        return Map;
    }

    public static float[] UniteBioms(int width, float[][] BiomsMap)
    {
        float[] Bioms = BiomsMap[0];
        BiomType biomType = BiomType.atlantic;
        foreach (float[] value in BiomsMap)
        {
            for (int i = 0; i < value.Length; i++)
                if (TileManager.IsItBiom(value[i]))
                    Bioms[i] = (int)biomType + value[i];
            biomType++;
        }
        return Bioms;
    }

}
