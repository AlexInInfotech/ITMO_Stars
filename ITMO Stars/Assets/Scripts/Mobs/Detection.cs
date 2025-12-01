using UnityEngine;

public class Detection : MonoBehaviour
{
    EnemyMovement body => GetComponentInParent<EnemyMovement>();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        body.ChaseObject(collision);
    }
}
