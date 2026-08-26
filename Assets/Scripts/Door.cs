using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination;
    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                player.transform.position = destination.position;
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
