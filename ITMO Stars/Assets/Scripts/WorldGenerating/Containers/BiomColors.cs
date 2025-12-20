using UnityEngine;
using UnityEngine.Tilemaps;

public class BiomColors
{
    public Color[] colors;
    public Color GetTileColor(BiomType biom)
    {
        return colors[(int)biom];
    }
}
