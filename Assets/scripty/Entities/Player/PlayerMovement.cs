using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal EntityDirection PlayerDirection => ((isRight) ? EntityDirection.RIGHT : EntityDirection.LEFT);

    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 6f;
    private bool isRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetTrigger("isJumping");
        }

        Flip();
        CheckForMovement();

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f)
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void CheckForMovement()
    {   
        animator.SetBool("isRunning", !Mathf.Approximately(horizontal, 0));
        //Debug.Log(animator.GetBool("isRunning"));
    }
}

