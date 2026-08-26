using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
}
