using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]PlayerController controller;
    Animator animator => GetComponent<Animator>();
    Transform trans => GetComponent<Transform>();
    const string IS_RUNNING = "IsRunning";
    const string VERTICAL = "Vertical";
    const string SPRINT = "Sprint";
    const string ATTACK = "Attack";

    public bool IsSprinting {  get; private set; }
    void Start()
    {
        animator.SetBool("IsRunning", false);
        IsSprinting = false;
    }
    public void ShowAttack(Vector2 direction)
    {
        SetDirection(direction);
        animator.SetTrigger(ATTACK);
    }
    public void Run(Vector2 direction)
    {
        SetDirection(direction);
        animator.SetBool(IS_RUNNING, true);
    }
    public void Sprint(Vector2 direction)
    {
        animator.SetTrigger(SPRINT);
        IsSprinting = true;
        SetDirection(direction);
    }
    public void Stop()
    {
        animator.SetBool(IS_RUNNING, false);
    }

    private void SetDirection(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 0)
            return;
        if (direction.y < 0)
            direction.y = -1;
        else if (direction.y > 0)
            direction.y = 1;
        else
            direction.y = 0;
        animator.SetFloat(VERTICAL, direction.y);
        trans.rotation = (direction.x < 0) ? new Quaternion(0, 180, 0, 0) : new Quaternion();
    }
    private void EndSprint()
    {
        IsSprinting = false;
    }
    private void Attack()
    {
        controller.CauseDamage();
    }

}
