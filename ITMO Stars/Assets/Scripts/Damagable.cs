using UnityEngine;
public interface IDamagable 
    {
        int health { get; set; }
        void GetDamage(float damage) { }
    }
public abstract class AbstractDamagable: MonoBehaviour, IDamagable
{
    public int health { get; set; }
    [SerializeField] public int MaxHealth;
    public abstract void GetDamage(int damage);

    

}