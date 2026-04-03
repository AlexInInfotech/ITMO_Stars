using UnityEngine;

[CreateAssetMenu(menuName = "Envitoment/New Element")]
public class EnvironmentInfo : ScriptableObject
{
    public string name;
    public Vector2 ColliderOffset;
    public Vector2 ColliderSize;
    public float MaxHealth;
    public Sprite[] sprites;

}
