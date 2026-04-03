using UnityEngine;

public class EnvironmentDamagable : AbstractDamagable
{

    ParticleSystem injuryEffect = null;
    public override void GetDamage(float damage)
    {
        health -= damage;
        if (injuryEffect != null)
            injuryEffect.Play();
        if (health < 0)
        {
            health = MaxHealth;
            // MobsManager.DeleteMob(gameObject);
        }
    }
}
