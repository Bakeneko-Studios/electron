using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skinsMenu : MonoBehaviour
{
    public Camera cam;

    public void mainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
