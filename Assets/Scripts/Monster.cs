using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2f;
    public float bounceForce = 6f;

    public SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    float startX;
    int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startX = transform.position.x;
    }

    void FixedUpdate()
    {
        if (transform.position.x >= startX + moveDistance)
        {
            direction = -1;
        }

        if (transform.position.x <= startX - moveDistance)
        {
            direction = 1;
        }

        rb.linearVelocity =
            new Vector2(
                direction * moveSpeed,
                rb.linearVelocity.y
            );

        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb =
                collision.gameObject.GetComponent<Rigidbody2D>();

            PlayerHealth playerHealth =
                collision.gameObject.GetComponent<PlayerHealth>();

            if (
                playerRb.linearVelocity.y < 0 &&
                collision.transform.position.y >
                transform.position.y + 0.5f
            )
            {
                playerRb.linearVelocity =
                    new Vector2(
                        playerRb.linearVelocity.x,
                        bounceForce
                    );

                Destroy(gameObject);
            }
            else
            {
                playerHealth.Die();
            }
        }
    }
}