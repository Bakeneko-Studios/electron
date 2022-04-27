using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Debug.Log("Game Should Quit");
        Application.Quit();
    }
    public void toSettings()
    {
        SceneManager.LoadScene("settings menu");
    }
    public void skinsMenu()
    {
        SceneManager.LoadScene("skins menu");
    }

    public UserData dataDest;
    public List<int[]> levels;
    void Start()
    {
        //Loads in the saved data the first time mainmenu is loaded
        dataDest = GameObject.Find("UserData").GetComponent<UserData>();
        SavedData data = SavingSystem.LoadUser();
        if (dataDest.reloadActivate == true)
        {
            dataDest.skinIndex = data.skinIndex;
            dataDest.unlockedLevel = data.unlockedLevel;
            dataDest.showfieldLines = data.showfieldLines;
            dataDest.showtimer = data.showtimer;
            dataDest.volumeMas = data.volumeMas;
            dataDest.volumeM = data.volumeM;
            dataDest.volumeE = data.volumeE;

            //levels
            levels = dataDest.levels;
            //stars
            for (int i = 0; i < data.stars.Length; i++)
            {
                levels[i][0] = data.stars[i];
            }
            //score
            for (int i = 0; i < data.score.Length; i++)
            {
                levels[i][1] = data.stars[i];
            }        
            dataDest.levels = levels;

            //load once
            dataDest.reloadActivate = false;
        }

        
    }
    public void saveData()
    {
        SavingSystem.SaveUser(dataDest);
    }
}
