using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Transform topPoint;
    [SerializeField] Transform bottomPoint;
    [SerializeField] Transform rightPoint;
    [SerializeField] float attackRadius;
    [SerializeField] float attackValue;
    [SerializeField] LayerMask damagableLayer;
    [SerializeField] Movable moveController => GetComponent<Movable>();
    public void SetAttackStrength(float strength)
    {
        attackValue = strength;
    }
    public void AttackInCircle()
    {
        Vector2 direction = moveController.direction;
        Transform TransformPoint;
        if (direction.y > 0)
            TransformPoint = topPoint;
        else if (direction.y < 0)
            TransformPoint = bottomPoint;
        else
            TransformPoint = rightPoint;
        Collider2D[] hitedEnemyes = Physics2D.OverlapCircleAll(TransformPoint.position, attackRadius, damagableLayer);
        foreach (Collider2D enemy in hitedEnemyes)
            if (enemy.gameObject.name != this.name && enemy.TryGetComponent<AbstractDamagable>(out AbstractDamagable component))
                component.GetDamage(attackValue);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(topPoint.position, attackRadius);
        Gizmos.DrawSphere(bottomPoint.position, attackRadius);
        Gizmos.DrawSphere(rightPoint.position, attackRadius);
    }
}
