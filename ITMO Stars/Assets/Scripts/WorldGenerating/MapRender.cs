using UnityEngine;

public class MapRender : MonoBehaviour
{
    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    public void RenderMap(int width, float[] map)
    {
        ApplyColorMap(width, GenerateNoiseMap(map));
    }

    private void ApplyColorMap(int width, Color[] colors)
    {
        Texture2D texture = new Texture2D(width, width);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colors);
        texture.Apply();

        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000.0f); ;
    }

    private Color[] GenerateNoiseMap(float[] noiseMap)
    {
        Color[] colorMap = new Color[noiseMap.Length];
        for (int i = 0; i < noiseMap.Length; i++)
        {
            //colorMap[i] = Color.Lerp(Color.white, Color.black, noiseMap[i]);
            switch (TileManager.GetTileType(noiseMap[i]))
            {
                case TileType.earth:
                    colorMap[i] = Color.green;
                    break;
                case TileType.water:
                    colorMap[i] = Color.blue;
                    break;
                case TileType.sand:
                    colorMap[i] = Color.yellow;
                    break;
            }
            //if (TileManager.IsItRiver(noiseMap[i]))
            //    colorMap[i] = Color.blue;
            //else
            //    colorMap[i] = Color.green;
        }
        return colorMap;
    }
}
