using UnityEngine;

public class Flower : MonoBehaviour
{
    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.CollectFlower();

            Destroy(gameObject);
        }
    }
}