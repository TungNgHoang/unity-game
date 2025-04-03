using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        // Ki?m tra n?u phím ` (backtick) ???c nh?n
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Chuy?n v? scene "Menu"
            SceneManager.LoadScene("Menu");
        }
    }
}
