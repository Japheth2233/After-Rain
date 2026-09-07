using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform destination;

    public GameObject currentArea;
    public GameObject nextArea;

    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                nextArea.SetActive(true);

                player.transform.position = destination.position;

                player.playerInteracting = false;

                currentArea.SetActive(false);
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