using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneController : MonoBehaviour
{
    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
