using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    public string nextScene;

    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player =
                collision.gameObject.GetComponent<PlayerController>();

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