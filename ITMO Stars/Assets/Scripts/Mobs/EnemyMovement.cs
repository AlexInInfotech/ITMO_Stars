using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MobMovement
{
    private BehaviourState state;
    [SerializeField]private float ChaseRadius;
    private Transform ObjectToChase;
    public void ChaseObject(Collider2D collision)
    {
        ObjectToChase = collision.gameObject.transform;
        state = BehaviourState.Fighting;
    }
    private void Fighting()
    {
        PointToGo = ObjectToChase.position;
        if ((rb.position - PointToGo).magnitude >= ChaseRadius)
            state = BehaviourState.Walk;
        else if ((rb.position - PointToGo).magnitude >= TargetRadius)
            GoToPoint();
        else
            Visual.ShowAttack(direction);
    }
    private void Update()
    {
        switch (state)
        {
            case BehaviourState.Walk:
                Walk();
                break;
            case BehaviourState.Fighting:
                Fighting();
                break;
        }
    }
}
