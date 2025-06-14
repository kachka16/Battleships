using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool isButtonTrue;
    public void StartGame()
    {
        SceneManager.LoadScene("One_Scene");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
