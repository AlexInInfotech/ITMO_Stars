using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator => GetComponent<Animator>();
    const string IS_RUNNING = "IsRunning";
    const string VERTICAL = "Vertical";
    const string SPRINT = "Sprint";
    const string ATTACK = "Attack";
    const string INJURY = "Injury";

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
    public void ShowRunning(Vector2 direction)
    {
        SetDirection(direction);
        animator.SetBool(IS_RUNNING, true);
    }
    public void ShowInjury()
    {
        animator.SetTrigger(INJURY);
    }
    public void ShowSprinting(Vector2 direction)
    {
        if (IsSprinting) 
            return;
        animator.SetTrigger(SPRINT);
        IsSprinting = true;
        SetDirection(direction);
    }
    public void StopRunning()
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
    }
    public void EndSprint()
    {
        IsSprinting = false;
    }
    private void Attack()
    {
        GetComponentInParent<AttackController>().AttackInCircle();
    }

}
