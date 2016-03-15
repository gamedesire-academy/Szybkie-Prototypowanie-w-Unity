using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator Animator = null;

    public void Attack()
    {
        Animator.SetBool("Attack", true);
        Animator.SetBool("Walk", false);
    }

    public void Walk()
    {
        Animator.SetBool("Walk", true);
        Animator.SetBool("Attack", false);

    }

    public void Idle()
    {
        Animator.SetBool("Attack", false);
        Animator.SetBool("Walk", false);
    }
}
