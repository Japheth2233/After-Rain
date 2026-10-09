using UnityEngine;

public class StemTrigger : MonoBehaviour
{
    public int flowerNumber;

    public GameObject flower;

    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (levelManager.flowersCollected >= flowerNumber)
            {
                flower.SetActive(true);
            }
        }
    }
}