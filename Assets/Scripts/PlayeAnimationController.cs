using UnityEngine;

public class BallAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb2d.linearVelocity.y > 0)
        {
            animator.Play("JumpStretch");
        }
        else if (rb2d.linearVelocity.y < 0)
        {
            animator.Play("LandSquash");
        }
    }
}
