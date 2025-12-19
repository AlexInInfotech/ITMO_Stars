using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MobMovement
{
    private BehaviourState state;
    [SerializeField]private float chaseRadius;
    private Transform objectToChase;
    public void ChaseObject(Collider2D collision)
    {
        objectToChase = collision.gameObject.transform;
        state = BehaviourState.Fighting;
    }
    private void Fighting()
    {
        pointToGo = objectToChase.position;
        if ((rb.position - pointToGo).magnitude >= chaseRadius)
            state = BehaviourState.Walk;
        else if ((rb.position - pointToGo).magnitude >= targetRadius)
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
