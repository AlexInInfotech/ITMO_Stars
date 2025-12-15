using UnityEngine;

public class MobsDamagable : AbstractDamagable
{
    AnimatorController animator => GetComponentInChildren<AnimatorController>();
    ParticleSystem InjuryEffect = null;
    public override void GetDamage(float damage)
    {
        health -= damage;
        animator.ShowInjury();
        if (InjuryEffect != null)
            InjuryEffect.Play();
        if (health < 0)
        {
            animator.ShowDead();
            health = MaxHealth;
           // MobsManager.DeleteMob(gameObject);
        }
    }
    private void Start()
    {
        health = MaxHealth;
        TryGetComponent<ParticleSystem>(out InjuryEffect);
    }
}
