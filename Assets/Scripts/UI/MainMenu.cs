using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Parking Lot");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}