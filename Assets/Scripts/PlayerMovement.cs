using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementInput;

    public float moveSpeed = 5f;
    public float jumpHeight = 10f;

    public bool isGrounded;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check if there is ground below the player
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
         );

        // Move left and right
        rb.linearVelocity =
            new Vector2(
                movementInput.x * moveSpeed,
                rb.linearVelocity.y
            );

        // Animation
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("IsGrounded", isGrounded);

        // Flip character
        if (rb.linearVelocity.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.linearVelocity.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            rb.linearVelocity =
                new Vector2(
                    rb.linearVelocity.x,
                    jumpHeight
                );
        }
    }
}