using UnityEngine;

public class PlayerController : Movable
{
    [SerializeField] float SprintAcceleration = 6f;
    Vector2 movement = Vector2.zero;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            MobsManager.CreateMob(Vector2.zero, "Mob");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (!Visual.IsSprinting)
            Run(movement);
        if (Input.GetKeyDown(KeyCode.Space))
            Visual.ShowSprinting(direction);
        if (Visual.IsSprinting)
            rb.MovePosition(rb.position + direction * SprintAcceleration * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
            Visual.ShowAttack(direction);
    }
   
}




























//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] AnimatorController Visual;
//    [SerializeField] float speed = 5f;
//    [SerializeField] float SprintAcceleration = 6f;
//    [SerializeField] Transform TopPoint;
//    [SerializeField] Transform BottomPoint;
//    [SerializeField] Transform RightPoint;
//    [SerializeField] float AttackRadius;
//    [SerializeField] LayerMask DamagableLayer;
//    Rigidbody2D rb => this.GetComponent<Rigidbody2D>();
//    Vector2 movement = Vector2.zero;
//    public Vector2 direction { get; private set; }
//    public void CauseDamage()
//    {
//        Transform TransformPoint;
//        if (direction.y > 0)
//            TransformPoint = TopPoint;
//        else if (direction.y < 0)
//            TransformPoint = BottomPoint;
//        else
//            TransformPoint = RightPoint;
//        Collider2D[] hitedEnemyes = Physics2D.OverlapCircleAll(TransformPoint.position, AttackRadius, DamagableLayer);
//        foreach (Collider2D enemy in hitedEnemyes)
//            if (enemy.TryGetComponent<AbstractDamagable>(out AbstractDamagable component))
//                component.GetDamage(1f);
//    }
//    void Update()
//    {
//        if (!Visual.IsSprinting)
//            Run();
//        if (Input.GetKeyDown(KeyCode.Space))
//            Visual.Sprint(direction);
//        if (Visual.IsSprinting)
//            rb.MovePosition(rb.position + direction * SprintAcceleration);
//        if (Input.GetMouseButtonDown(0))
//            Visual.ShowAttack(direction);
//    }
//    private void Run()
//    {
//        movement.x = Input.GetAxisRaw("Horizontal");
//        movement.y = Input.GetAxisRaw("Vertical");
//        if (movement.x != 0 || movement.y != 0)
//        {
//            rb.MovePosition(rb.position + movement * Time.deltaTime * speed);
//            Visual.Run(movement);
//            direction = movement;
//        }
//        else
//            Visual.StopRunning();
//    }
//}
