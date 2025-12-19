using System;
using UnityEngine;
using System.Collections;

public class MobMovement : Movable
{

    protected Vector2 pointToGo = new Vector2();
    protected float movementRadius = 20f;
    [SerializeField] protected float targetRadius = 2f;
    protected float waitTime = 0f;
    protected float maxWaitTime = 10f;
    protected Vector3 RandomPointInArea(Vector3 Center, float MovementRadius)
    {
        Vector3 Point = new Vector3();
        Point.x = Center.x + UnityEngine.Random.Range(-MovementRadius, MovementRadius);
        Point.y = Center.y + UnityEngine.Random.Range(-MovementRadius, MovementRadius);
        return Point;
    }
    protected Vector2 DirectToPoint( Vector2 Position, Vector2 Point, float PointRadius)
    {
        Vector2 _direction = new Vector2();
        _direction = Point - Position;
        _direction = _direction.magnitude <= PointRadius ? Vector2.zero : _direction;
        if (Math.Abs(_direction.x) <= PointRadius/2)
            _direction.x = 0;
        else if (_direction.x > 0)
            _direction.x = 1;
        else
            _direction.x = -1;
        if (Math.Abs(_direction.y) <= PointRadius /2)
            _direction.y = 0;
        else if (_direction.y > 0)
            _direction.y = 1;
        else
            _direction.y = -1;
        return _direction;
    }
    protected void GoToPoint()
    {
        direction = DirectToPoint(transform.position, pointToGo, targetRadius);
        Run(direction);
    }
    protected void Walk()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            return;
        }
        if (pointToGo == new Vector2())
            pointToGo = RandomPointInArea(transform.position, movementRadius);
        GoToPoint();
        if (direction.x == 0 && direction.y == 0)
        {
            pointToGo = new Vector2();
            waitTime = UnityEngine.Random.Range(0, maxWaitTime);
        }
    }
    private void Update()
    {
        Walk();
    }

  
}
