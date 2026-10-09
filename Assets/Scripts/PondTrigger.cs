using UnityEngine;

public class PondTrigger : MonoBehaviour
{
    public int flowerNumber;

    public GameObject lotus;

    public LevelManager levelManager;

    bool hasActivated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasActivated)
        {
            if (levelManager.flowersCollected >= flowerNumber)
            {
                lotus.SetActive(true);
            }

            hasActivated = true;
        }
    }
}