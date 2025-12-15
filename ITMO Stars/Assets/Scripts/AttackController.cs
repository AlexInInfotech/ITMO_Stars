using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Transform TopPoint;
    [SerializeField] Transform BottomPoint;
    [SerializeField] Transform RightPoint;
    [SerializeField] float AttackRadius;
    [SerializeField] float AttackValue;
    [SerializeField] LayerMask DamagableLayer;
    [SerializeField] Movable MoveController => GetComponent<Movable>();
    public void SetAttackStrength(float strength)
    {
        AttackValue = strength;
    }
    public void AttackInCircle()
    {
        Vector2 direction = MoveController.direction;
        Transform TransformPoint;
        if (direction.y > 0)
            TransformPoint = TopPoint;
        else if (direction.y < 0)
            TransformPoint = BottomPoint;
        else
            TransformPoint = RightPoint;
        Collider2D[] hitedEnemyes = Physics2D.OverlapCircleAll(TransformPoint.position, AttackRadius, DamagableLayer);
        foreach (Collider2D enemy in hitedEnemyes)
            if (enemy.gameObject.name != this.name && enemy.TryGetComponent<AbstractDamagable>(out AbstractDamagable component))
                component.GetDamage(AttackValue);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(TopPoint.position, AttackRadius);
        Gizmos.DrawSphere(BottomPoint.position, AttackRadius);
        Gizmos.DrawSphere(RightPoint.position, AttackRadius);
    }
}
