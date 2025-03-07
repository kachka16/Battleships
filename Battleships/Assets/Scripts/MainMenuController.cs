using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool isButtonTrue;
    public void StartGame()
    {
        SceneManager.LoadScene("SceneOne");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
