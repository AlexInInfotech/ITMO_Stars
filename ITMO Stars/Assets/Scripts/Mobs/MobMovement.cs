using System;
using UnityEngine;
using System.Collections;

public class MobMovement : Movable
{

    protected Vector2 PointToGo = new Vector2();
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
        direction = DirectToPoint(transform.position, PointToGo, TargetRadius);
        Run(direction);
    }
    protected void Walk()
    {
        if (WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
            return;
        }
        if (PointToGo == new Vector2())
            PointToGo = RandomPointInArea(transform.position, MovementRadius);
        GoToPoint();
        if (direction.x == 0 && direction.y == 0)
        {
            PointToGo = new Vector2();
            WaitTime = UnityEngine.Random.Range(0, MaxWaitTime);
        }
    }
    private void Update()
    {
        Walk();
    }

  
}
