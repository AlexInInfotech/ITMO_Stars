using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : AbstractDamagable
{
    [SerializeField] Slider healthBar;
    public override void GetDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = MaxHealth;
        healthBar.value = (float)health / MaxHealth;
    }
    public void LoadHealth()
    {

        health = SavingManager.GetHealth();
    }
    
}
