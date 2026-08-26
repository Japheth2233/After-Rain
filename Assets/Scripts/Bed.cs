using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                if (player.collectedPlants == 3)
                {
                    SceneManager.LoadScene("EndScreen");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
