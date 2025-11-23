using UnityEngine;

public abstract class AbstractDamagable: MonoBehaviour, IDamagable
{
    public abstract float health { get; set; }
    public abstract void GetDamage(float damage);

}
public interface IDamagable 
{
    float health { get; set; }
    void GetDamage(float damage) { }
}
