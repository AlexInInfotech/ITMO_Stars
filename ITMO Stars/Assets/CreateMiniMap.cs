using UnityEngine;

public class CreateMiniMap : MonoBehaviour
{
    public Material material;
    const string MINIMAP = "_TransitMap";
    void Start()
    {
        Color[] colors = { 
            Color.yellow, Color.blue, Color.green, Color.red,
            Color.red,Color.green, Color.blue,  Color.yellow,
            Color.yellow, Color.blue, Color.green, Color.red,
            Color.red,Color.green, Color.blue,  Color.yellow,
        };
        Texture2D texture = new Texture2D(4, 4);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colors);
        texture.Apply();
        material.SetTexture(MINIMAP, texture);
        
    }

}
