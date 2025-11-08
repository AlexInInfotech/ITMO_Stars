using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AnimatorController Visual;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb => this.GetComponent<Rigidbody2D>();
    Vector2 movement = Vector2.zero;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement *= Time.deltaTime * speed; 
        if (movement.x != 0 || movement.y != 0)
        {
            rb.MovePosition(rb.position + movement);
            Visual.Run(movement.x);
        }
        else
            Visual.Stop();


    }
}
