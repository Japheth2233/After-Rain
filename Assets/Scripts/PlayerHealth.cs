using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject[] hearts;

    public void TakeDamage()
    {
        health -= 1;

        if (health >= 0)
        {
            hearts[health].SetActive(false);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void HealFull()
    {
        health = 3;

        hearts[0].SetActive(true);
        hearts[1].SetActive(true);
        hearts[2].SetActive(true);
    }

    public void Die()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}