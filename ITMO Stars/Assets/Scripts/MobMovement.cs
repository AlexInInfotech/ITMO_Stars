using System;
using UnityEngine;
using System.Collections;

public class MobMovement : MonoBehaviour
{

    [SerializeField]protected float speed = 10f;
    protected Vector3 direction;
    protected Vector3 PointToGo = new Vector3();
    protected float MovementRadius = 20f;
    [SerializeField] protected float TargetRadius = 2f;
    protected float WaitTime = 0f;
    protected float MaxWaitTime = 10f;
    protected Vector3 RandomPointInArea(Vector3 Center, float MovementRadius)
    {
        Vector3 Point = new Vector3();
        Point.x = Center.x + UnityEngine.Random.Range(-MovementRadius, MovementRadius);
        Point.y = Center.y + UnityEngine.Random.Range(-MovementRadius, MovementRadius);
        return Point;
    }
    protected Vector3 DirectToPoint(Vector3 Point, Vector3 Position, float PointRadius)
    {
        Vector3 direction = new Vector3();
        direction = Point - Position;
        if (Math.Abs(direction.x) <= PointRadius)
            direction.x = 0;
        else if (direction.x > 0)
            direction.x = 1;
        else
            direction.x = -1;
        if (Math.Abs(direction.y) <= PointRadius)
            direction.y = 0;
        else if (direction.y > 0)
            direction.y = 1;
        else
            direction.y = -1;
        return direction;
    }
    protected void Walk()
    {
        if (WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
            return;
        }
        if (PointToGo == new Vector3())
            PointToGo = RandomPointInArea(transform.position, MovementRadius);
        direction = DirectToPoint(PointToGo, transform.position, TargetRadius);
        if (direction.x == 0 && direction.y == 0)
        {
            PointToGo = new Vector3();
            WaitTime = UnityEngine.Random.Range(0, MaxWaitTime);
        }
        transform.position += direction * speed * Time.deltaTime;

    }
    private void Update()
    {
        Walk();
    }

  
}
