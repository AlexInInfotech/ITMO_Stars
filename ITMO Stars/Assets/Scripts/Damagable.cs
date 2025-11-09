using UnityEngine;

public interface Damagable 
{
    public float health { get; set; }
    public void GetDamage(float damage)
    {
        Debug.Log("GEt Damage");
    }
}
