using UnityEngine;

public class Flower : MonoBehaviour
{
    public LevelManager levelManager;
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource playerAudio =
                collision.gameObject.GetComponent<AudioSource>();

            playerAudio.PlayOneShot(collectSound);

            levelManager.CollectFlower();

            Destroy(gameObject);
        }
    }
}