using UnityEngine;

public class MobsDamagable : AbstractDamagable
{
    AnimatorController animator => GetComponentInChildren<AnimatorController>();
    ParticleSystem InjuryEffect = null;
    public override void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log(damage);
        animator.ShowInjury();
        if (InjuryEffect != null)
            InjuryEffect.Play();
        if (health < 0)
        {
            Debug.Log(name + " Dead");
            health = MaxHealth;
            MobsManager.DeleteMob(gameObject);
        }
    }
    private void Start()
    {
        health = MaxHealth;
        TryGetComponent<ParticleSystem>(out InjuryEffect);
    }
}
