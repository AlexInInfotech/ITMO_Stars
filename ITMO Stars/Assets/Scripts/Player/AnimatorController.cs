using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();
    Transform trans => GetComponent<Transform>();
    const string IS_RUNNING = "IsRunning";
    const string HORIZONTAL = "Horizontal";
    void Start()
    {
        animator.SetBool("IsRunning", false);
    }
    public void Run(float TransformX)
    {
        animator.SetBool(IS_RUNNING, true);
        animator.SetBool(HORIZONTAL, TransformX != 0);
        if (TransformX > 0)
            trans.rotation = new Quaternion(0, 180, 0, 0);
        else
            trans.rotation = new Quaternion();
    }
    public void Stop()
    {
        animator.SetBool(IS_RUNNING, false);
    }



}
