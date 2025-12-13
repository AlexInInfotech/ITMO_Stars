using UnityEngine;

public class PlayerDamage : AbstractDamagable
{
    public override void GetDamage(float damage)
    {
        //health -= damage;
        //if (health < 0)
        //{
        //    Debug.Log("Dead");
        //    health = MaxHealth;
        //}
    }
    private void Start()
    {
        health = MaxHealth;
    }
}
