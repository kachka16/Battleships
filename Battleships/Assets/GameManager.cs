using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject spritePrefab;
    private GameObject [, ] spriteGrid;

    public void Start()
    {
     for(int i = 0; i<10; i++)
        {
            for (int j= 0; j < 10; j++)
            {
                GameObject newSprite = Instantiate(spritePrefab, new Vector3(i * 2, j * 2, 0), Quaternion.identity);
                spriteGrid[i, j] = newSprite;
            }
        }   
    }
}
