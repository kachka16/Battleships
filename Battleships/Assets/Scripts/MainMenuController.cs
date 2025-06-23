using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
 
    public void NextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
