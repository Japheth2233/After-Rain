using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float moveDistance = 2f;
    public float bounceForce = 6f;

    public SpriteRenderer spriteRenderer;

    public AudioClip deathSound;

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

            // 玩家从上方落下来踩怪物
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
                AudioSource playerAudio =
                collision.gameObject.GetComponent<AudioSource>();

                playerAudio.PlayOneShot(deathSound);
                
                Destroy(gameObject);
            }

            // 玩家从侧面碰怪物
            else
            {
                playerHealth.TakeDamage();
            }
        }
    }
}