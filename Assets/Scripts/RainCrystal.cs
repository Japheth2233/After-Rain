using UnityEngine;

public class RainCrystal : MonoBehaviour
{
    public GameObject restoredArea;
    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                restoredArea.SetActive(true);

                gameObject.SetActive(false);
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
