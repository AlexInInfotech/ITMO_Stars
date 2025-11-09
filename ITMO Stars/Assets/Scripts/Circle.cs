using UnityEngine;

public class Circle : MonoBehaviour, Damagable
{
    public float health { get; set; }
    public void GetDamage(float damage)
    {
        Debug.Log("GEt Damage");
    }
}
