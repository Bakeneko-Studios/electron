using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterAM;
    public GameObject timerChecked;
    public GameObject timerUnchecked;
    public GameObject flinesChecked;
    public GameObject flinesUnchecked;

    public GameObject loader;

    public float volumeMas;
    public float volumeM;
    public float volumeE;

    public void SetMasterVolume(float masterVloume)
    {
        masterAM.SetFloat("MasterVolume", masterVloume);
        UserData.volumeMas = masterVloume;
    }
    public void SetMusicVolume(float musicVolume)
    {
        masterAM.SetFloat("MusicVolume", musicVolume);
        UserData.volumeM = musicVolume;
    }
    public void SetEffectsVolume(float effectsVolume)
    {
        masterAM.SetFloat("EffectsVolume", effectsVolume);
        UserData.volumeE = effectsVolume;
    }

    public void back()
    {
        loader.GetComponent<levelLoader>().callLevelLoader(UserData.beforeSettings);
    }
    public void toCredits()
    {
        loader.GetComponent<levelLoader>().callLevelLoader(23);
    }
    /*
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullscreen = isFullscreen;
    }
    */

    void Start()
    {
        timerChecked.SetActive(UserData.showtimer);
        timerUnchecked.SetActive(!UserData.showtimer);
        flinesChecked.SetActive(UserData.showfieldLines);
        flinesUnchecked.SetActive(!UserData.showfieldLines);

        foreach (Transform child in GameObject.Find("MasterVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UserData.volumeMas;   
            }
        }
        foreach (Transform child in GameObject.Find("MusicVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UserData.volumeM;   
            }
        }
        foreach (Transform child in GameObject.Find("EffectsVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UserData.volumeE;   
            }
        }                
    }

    public void toggleTimer()
    {
        UserData.showtimer = !UserData.showtimer;
        timerChecked.SetActive(!timerChecked.activeInHierarchy);
        timerUnchecked.SetActive(!timerUnchecked.activeInHierarchy);
    }
    public void toggleFLines()
    {
        UserData.showfieldLines = !UserData.showfieldLines;
        flinesChecked.SetActive(!flinesChecked.activeInHierarchy);
        flinesUnchecked.SetActive(!flinesUnchecked.activeInHierarchy);
    }
    public void saveData()
    {

        SavingSystem.SaveUser();
    }
}
