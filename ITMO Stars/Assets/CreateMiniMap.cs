using UnityEngine;

public class CreateMiniMap : MonoBehaviour
{
    public Material material;
    const string MINIMAP = "_MiniMap";
    [SerializeField]MapCharcteristics map;
    void Start()
    {
        map.seed = 9;
        Color[] colors = { Color.yellow, Color.blue, Color.green, Color.red };
        Texture2D texture = new Texture2D(2, 2);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colors);
        texture.Apply();
        material.SetTexture(MINIMAP, texture);
        
    }

}
