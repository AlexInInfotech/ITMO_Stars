using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Maps/New MapCharcteristic")]

public class MapCharcteristics : ScriptableObject
{
     public float scale;
     public int seed;
     public byte octaves;
    public float persistence;
    public float lacunarity;
}
