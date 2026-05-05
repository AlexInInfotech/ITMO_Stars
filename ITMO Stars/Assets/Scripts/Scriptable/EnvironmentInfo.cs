using UnityEngine;

[CreateAssetMenu(menuName = "Envitoment/New Element")]
public class EnvironmentInfo : ScriptableObject
{
    public Vector2 ColliderOffset;
    public Vector2 ColliderSize;
    public RuntimeAnimatorController AnimatorController;
    public EnvironmentType environmentType;
    public TileType baseType;
    public BiomType biomtype;
    public int MaxHealth;
    public Sprite[] sprites;

}
