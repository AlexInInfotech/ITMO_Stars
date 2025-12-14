using UnityEngine;
public interface IDamagable 
    {
        float health { get; set; }
        void GetDamage(float damage) { }
    }
public abstract class AbstractDamagable: MonoBehaviour, IDamagable
{
    public float health { get; set; }
    [SerializeField] public float MaxHealth;
    public abstract void GetDamage(float damage);

    

}