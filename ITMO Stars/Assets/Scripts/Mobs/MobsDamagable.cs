using UnityEngine;

public class MobsDamagable : AbstractDamagable
{
    public override void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log(damage);
        if (health < 0)
        {
            Debug.Log(name + " Dead");
            health = MaxHealth;
            MobsManager.DeleteMob(name);
        }
    }
    private void Start()
    {
        health = MaxHealth;
    }
}
