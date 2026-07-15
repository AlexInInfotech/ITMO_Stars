using UnityEngine;

public class MobsCluster 
{
    public string mobName;
    public byte mobsCount;
    public Vector2 position;

   
    public MobsCluster(Vector2 unitCoord)
    {
        int seed = (int)(long)((unitCoord.x.GetHashCode() + unitCoord.y.GetHashCode())*MobsManager.mobSeed);
        //Debug.Log(seed);
        System.Random rand = new System.Random(seed);
        mobsCount = (byte)rand.Next(0, MobsManager.maxMobCount);
        position = unitCoord* MapManager.tileMapWidth + new Vector2(rand.Next(0, MapManager.tileMapWidth), rand.Next(0, MapManager.tileMapWidth));

        mobName = MobsManager.GetRandomMobName(rand.Next());
        //Debug.Log(unitCoord.x + " " + unitCoord.y + " " + seed);
    }
}
