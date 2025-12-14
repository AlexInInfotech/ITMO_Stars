using UnityEngine;

public class Movable : MonoBehaviour
{

    [SerializeField] protected AnimatorController Visual;
    [SerializeField]protected float speed = 5f;
    protected Rigidbody2D rb => this.GetComponent<Rigidbody2D>();
    Transform trans => this.GetComponent<Transform>();
    public Vector2 direction { get; protected set; }
    protected void SetRotation()
    {
        if (direction.x == 0)
                return;
        trans.rotation = (direction.x < 0) ? new Quaternion(0, 180, 0, 0) : new Quaternion();
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    protected void Run(Vector2 _direction)
    {
        if (_direction.x != 0 || _direction.y != 0)
        {
            rb.MovePosition(rb.position + _direction * Time.deltaTime * speed);
            direction = _direction;
            SetRotation();
            Visual.ShowRunning(direction);
        }
        else
            Visual.StopRunning();
    }
}
