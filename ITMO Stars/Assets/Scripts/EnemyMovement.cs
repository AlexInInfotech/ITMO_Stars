using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MobMovement
{
    private BehaviourState state;
    private Transform _transform => GetComponent<Transform>();
    [SerializeField]private float ChaseRadius;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PointToGo = collision.gameObject.transform.position;
            state = BehaviourState.Fighting;
        }
    }
    private void Fighting()
    {
        if ((_transform.position - PointToGo).magnitude >= ChaseRadius)
        {
            state = BehaviourState.Walk;
            return;
        }
        if ((_transform.position - PointToGo).magnitude >= TargetRadius)
        {
            WaitTime = 0;
            Walk();
        }
        else 
        {
            Debug.Log("Hit");
        }
    }
    private void Update()
    {

        Debug.Log(state);
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
