using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skinsMenu : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
    public void saveData()
    {
        SavingSystem.SaveUser(GameObject.Find("UserData").GetComponent<UserData>());
    }
}
