using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
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

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
