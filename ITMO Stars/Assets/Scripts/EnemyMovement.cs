using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MobMovement
{
    private BehaviourState state;
    [SerializeField]private float ChaseRadius;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        PointToGo = collision.gameObject.transform.position;
        state = BehaviourState.Fighting;
        
    }
    private void Fighting()
    {
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
