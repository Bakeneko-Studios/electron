using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene("level 1");
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
        SceneManager.LoadScene("Anda's scene");  
    }

    public void levelRay()
    {
        SceneManager.LoadScene("Ray's scene"); 
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
