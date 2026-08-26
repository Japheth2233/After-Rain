using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject dryPlant;
    public GameObject wateredPlant;
    public GameObject grownPlant;

    public bool isWatered;
    public bool isGrown;

    bool playerInRange;
    PlayerController player;

    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                if (isWatered == false)
                {
                    WaterPlant();
                }
                else if (isGrown == false)
                {
                    GrowPlant();
                }
                else
                {
                    HarvestPlant();
                }
            }
        }
    }

    void WaterPlant()
    {
        dryPlant.SetActive(false);
        wateredPlant.SetActive(true);

        isWatered = true;

        player.playerInteracting = false;
    }

    void GrowPlant()
    {
        wateredPlant.SetActive(false);
        grownPlant.SetActive(true);

        isGrown = true;

        player.playerInteracting = false;
    }

    void HarvestPlant()
    {
        player.CollectPlant();

        player.playerInteracting = false;

        gameObject.SetActive(false);
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
