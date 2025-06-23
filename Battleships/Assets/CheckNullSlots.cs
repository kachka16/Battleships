using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckNullSlots : MonoBehaviour
{

    public Button button;
    public void Awake()
    {
        button.image.color = new Color(0f,0f,0f,0.5f);
     
    }
    public void OnButtonClick()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("boxGrid");
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                return;
            }
        }
        button.image.color = new Color(1f, 1f, 1f, 1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}