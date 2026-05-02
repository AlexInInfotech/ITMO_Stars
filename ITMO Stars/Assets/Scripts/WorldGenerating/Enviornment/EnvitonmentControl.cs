
using UnityEngine;

public static class EnvitonmentControl 
{
    public static Surround[] GetSurrounds(Vector2Int coord,FloatMap bases,  FloatMap bioms)
    {
        int len = 0;
        int i = 0;
        FloatMap map = MapGenerator.GenerateEnvironmentMap(coord);
        EnvironmentType[] types = Convecter.FloatToType( map, ref len);
        Surround[] surrounds = new Surround[len];
        for (int y = 0; y < map.width; y++)
            for (int x = 0; x < map.width; x++)
                if (types[x + y * map.width] != EnvironmentType.none)
                {

                    //Debug.Log(i + " " + len);
                    surrounds[i] = new Surround();
                    surrounds[i].position = new Vector2(x, y);
                    surrounds[i].name = EnvironmentManager.GetSurroundName(types[x + y * map.width], TileManager.GetTileType(bases.values[x / bases.size + (y / bases.size) * bases.width]), TileManager.GetBiomType(bioms.values[x / bioms.size + (y / bioms.size) * bioms.width]));
                    surrounds[i].state = EnviromentState.unharmed;
                    i++;
                }
        //Debug.Log(i + "  " + len);
        return surrounds;
    }
    
}
