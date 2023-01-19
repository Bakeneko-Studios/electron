using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public Button[] lvlButtons;
    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel + 1;

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

    public void loadLevel(int level)
    {
        levelLoader.GetComponent<levelLoader>().callLevelLoader(level + 1);
    }

    public void levelDylan()
    {
        SceneManager.LoadScene("Dylan's scene");
    }

    public void levelAlan()
    {
        SceneManager.LoadScene("Alan's scene");
    }
    public void levelAnda()
    {
        SceneManager.LoadScene("Trail Testing Area");  
    }

    public void levelRay()
    {
        SceneManager.LoadScene("Ray's scene"); 
    }

    public void levelMinchan()
    {
        SceneManager.LoadScene("Minchan's scene");
    }

    public void loadScene(int Index)
    {
        SceneManager.LoadScene(Index);
    }


    public void mainMenu()
    {
        levelLoader.GetComponent<levelLoader>().callLevelLoader(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
