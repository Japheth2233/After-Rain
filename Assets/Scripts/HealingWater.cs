using UnityEngine;

public class HealingWater : MonoBehaviour
{
    public AudioClip healSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.gameObject.GetComponent<PlayerHealth>();

            AudioSource playerAudio =
                collision.gameObject.GetComponent<AudioSource>();

            playerHealth.HealFull();

            playerAudio.PlayOneShot(healSound);
        }
    }
}