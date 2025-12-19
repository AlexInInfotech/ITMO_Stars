using System;
using UnityEngine;

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

    public static void GeneratePerlinMaps(ref FloatMap MainMap, ref FloatMap BiomMap, Vector2 Coord)
    {
        MainMap.size = mainMapSize;
        BiomMap.size = biomMapSize;
        MainMap.width = (MapManager.tileMapWidth + 2) / mainMapSize;
        BiomMap.width = (MapManager.tileMapWidth + 2) / biomMapSize;
        // BiomMap.floatArray = MapGenerator.Generate(BiomMap.width, BiomMapCharac, Coord * OffsetBiom);
        MainMap.values = GetFloatMap(MainMap.width, mainMapCharac, Coord);
        //float[] RiverMap = GerFloatMap(MainMap.width, riverMapCharac, Coord);
        BiomMap.values = GetFloatMap(BiomMap.width, biomMapCharac, Coord);
        // BiomMaps[2] = MapGenerator.Generate(BiomMap.width, BloodMapCharac, Coord * OffsetBiom);
        //MapGenerator.UniteMainWidthRiver(MainMap.floatArray, RiverMap);
        //BiomMap.floatArray = MapGenerator.UniteBioms(BiomMap.width, BiomMaps);

    }
    private static float[] GetFloatMap(int width, MapCharcteristics mapCharac, Vector2 offset)
    {
        int random;
        float[] Map = new float[width * width];
        System.Random RandomCreature = new System.Random(mapCharac.seed);

        Vector2[] octavesOffset = new Vector2[mapCharac.octaves];
        for (int i = 0; i < mapCharac.octaves; i++)
        {
            random = RandomCreature.Next(-100000, 100000);
            float xOffset = random + offset.x;
            float yOffset = random + offset.y;
            octavesOffset[i] = new Vector2(xOffset, yOffset);
        }
        if (mapCharac.scale < 0) mapCharac.scale = 0.0001f;

        float halfWidth = width / 2f;
        float halfHeight = width / 2f;

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
                    float xResult = (x - halfWidth) / mapCharac.scale * frequency + octavesOffset[i].x * frequency;
                    float yResult = (y - halfHeight) / mapCharac.scale * frequency + octavesOffset[i].y * frequency;

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
    //public static void UniteMainWidthRiver(float[] MainMap, float[] RiverMap)
    //{
    //    for (int i = 0; i < MainMap.Length; i++)
    //        if (TileManager.IsItRiver(RiverMap[i]))
    //            MainMap[i] = 0;
    //}
    //public static float[] UniteBioms(int width, float[][] BiomsMap)
    //{
    //    float[] Bioms = BiomsMap[0];
    //    BiomType biomType = BiomType.atlantic;
    //    foreach (float[] value in BiomsMap)
    //    {
    //        for (int i = 0; i < value.Length; i++)
    //            if (TileManager.IsItBiom(value[i]))
    //                Bioms[i] = (int)biomType + value[i];
    //        biomType++;
    //    }
    //    return Bioms;
    //}

}
