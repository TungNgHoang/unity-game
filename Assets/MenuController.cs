using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene"); // Chuy?n sang scene "Level1"
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("GameplayLevel2"); // Chuy?n sang scene "Level2"
    }

    public void QuitGame()
    {
        Application.Quit(); // Thoát game
    }
}
