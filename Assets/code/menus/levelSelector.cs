using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel + 2;

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

    public void level1() {
        SceneManager.LoadScene("level1");
    }

    public void level2() {
        SceneManager.LoadScene("level2");
    }

    public void level3() {
        SceneManager.LoadScene("level3");
    }

    public void level4() {
        SceneManager.LoadScene("level4");
    }

    public void level5() {
        SceneManager.LoadScene("level5");
    }

    public void level6() {
        SceneManager.LoadScene("level6");
    }

    public void level7() {
        SceneManager.LoadScene("level7");
    }

    public void level8() {
        SceneManager.LoadScene("level8");
    }

    public void level9() {
        SceneManager.LoadScene("level9");
    }

    public void level10() {
        SceneManager.LoadScene("level10");
    }

    public void level11() {
        SceneManager.LoadScene("level11");
    }

    public void level12() {
        SceneManager.LoadScene("level12");
    }

    public void level13() {
        SceneManager.LoadScene("level13");
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

    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
