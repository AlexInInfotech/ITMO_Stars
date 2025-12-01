using UnityEngine;

public class MobsDamagable : AbstractDamagable
{
    public override void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log(damage);
        if (health < 0)
        {
            Debug.Log("Dead");
            health = MaxHealth;
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        health = MaxHealth;
    }
}
