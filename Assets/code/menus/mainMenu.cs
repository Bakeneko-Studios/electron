using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenu : MonoBehaviour
{
    public AudioMixer masterAM;
    public GameObject[] titles;
    public GameObject loader;

    public void playGame()
    {
        loader.GetComponent<levelLoader>().callLevelLoader(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Game Should Quit");
        Application.Quit();
    }
    public void toSettings()
    {
        loader.GetComponent<levelLoader>().callLevelLoader(24);
    }
    public void toSkins()
    {
        loader.GetComponent<levelLoader>().callLevelLoader(25);
    }
    public void website()
    {
        Application.OpenURL("https://www.bakeneko.games/");
    }
    public int[,] levels;
    void Start()
    {
        //Loads in the saved data the first time mainmenu is loaded
        SavedData data = SavingSystem.LoadUser();
        if(data==null) SavingSystem.SaveUser();
        else if (UserData.reloadActivate == true)
        {
            UserData.skinIndex = data.skinIndex;
            UserData.unlockedLevel = data.unlockedLevel;
            UserData.showfieldLines = data.showfieldLines;
            UserData.showtimer = data.showtimer;
            UserData.volumeMas = data.volumeMas;
            UserData.volumeM = data.volumeM;
            UserData.volumeE = data.volumeE;
            UserData.language = data.language;


            //levels
            levels = UserData.levels;
            //stars
            for (int i = 0; i < data.stars.Length; i++)
            {
                levels[i,0] = data.stars[i];
            }
            //score
            for (int i = 0; i < data.score.Length; i++)
            {
                levels[i,1] = data.stars[i];
            }        
            UserData.levels = levels;

            //set initial volume
            masterAM.SetFloat("MasterVolume", data.volumeMas);
            masterAM.SetFloat("MusicVolume", data.volumeM);
            masterAM.SetFloat("EffectsVolume", data.volumeE);

            //load once
            UserData.reloadActivate = false;
        }
        
    }
    public void saveData()
    {
        SavingSystem.SaveUser();
    }

    void Update()
    {
        for (int i = 0; i < titles.Length; i++)
        {
            if (i != UserData.language - 1) {
                titles[i].SetActive(false);
            } else {
                titles[i].SetActive(true);                
            }
        }
    }
}
