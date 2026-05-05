using UnityEngine;

public class EnvironmentDamagable : AbstractDamagable
{

    ParticleSystem injuryEffect = null;
    public override void GetDamage(int damage)
    {
        health -= damage;
        if (injuryEffect != null)
            injuryEffect.Play();
        if (health < 0)
        {
            health = MaxHealth;
            EnvironmentManager.ChangeSurroundstate(this.name, EnviromentState.destroyed);
        }
    }
}
