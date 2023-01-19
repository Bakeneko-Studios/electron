using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skinsMenu : MonoBehaviour
{
    public GameObject levelLoader;
    public void mainMenu()
    {
        levelLoader.GetComponent<levelLoader>().callLevelLoader(0);
    }
    public void saveData()
    {
        SavingSystem.SaveUser(GameObject.Find("UserData").GetComponent<UserData>());
    }
}
