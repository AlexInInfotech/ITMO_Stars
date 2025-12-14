using UnityEngine;

[CreateAssetMenu(menuName = "Mobs/New Friendly Mob")]
public class MobInfo : ScriptableObject
{
    public string MobName;
    public Vector2 ColliderOffset;
    public Vector2 ColliderSize;
    public RuntimeAnimatorController AnimatorController;
    public float Speed;
    public float MaxHealth;

}

