using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Transform TopPoint;
    [SerializeField] Transform BottomPoint;
    [SerializeField] Transform RightPoint;
    [SerializeField] float AttackRadius;
    [SerializeField] LayerMask DamagableLayer;
    [SerializeField] Movable MoveController;
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
            if (enemy.TryGetComponent<AbstractDamagable>(out AbstractDamagable component))
                component.GetDamage(1f);
    }
}
