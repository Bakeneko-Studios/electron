using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterAM;
    public UserData UD;
    public GameObject timerChecked;
    public GameObject timerUnchecked;
    public GameObject flinesChecked;
    public GameObject flinesUnchecked;

    public float volumeMas;
    public float volumeM;
    public float volumeE;

    public void SetMasterVolume(float masterVloume)
    {
        masterAM.SetFloat("MasterVolume", masterVloume);
        UD.volumeMas = masterVloume;
    }
    public void SetMusicVolume(float musicVolume)
    {
        masterAM.SetFloat("MusicVolume", musicVolume);
        UD.volumeM = musicVolume;
    }
    public void SetEffectsVolume(float effectsVolume)
    {
        masterAM.SetFloat("EffectsVolume", effectsVolume);
        UD.volumeE = effectsVolume;
    }

    public void back()
    {
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().beforeSettings);
    }
    public void toCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    /*
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullscreen = isFullscreen;
    }
    */

    void Start()
    {
        UD = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>();
        timerChecked.SetActive(UD.showtimer);
        timerUnchecked.SetActive(!UD.showtimer);
        flinesChecked.SetActive(UD.showfieldLines);
        flinesUnchecked.SetActive(!UD.showfieldLines);

        foreach (Transform child in GameObject.Find("MasterVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UD.volumeMas;   
            }
        }
        foreach (Transform child in GameObject.Find("MusicVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UD.volumeM;   
            }
        }
        foreach (Transform child in GameObject.Find("EffectsVolume").transform)
        {
            if (child.name == "Slider")
            {
                child.gameObject.GetComponent<Slider>().value = UD.volumeE;   
            }
        }                
    }

    public void toggleTimer()
    {
        UD.showtimer = !UD.showtimer;
        timerChecked.SetActive(!timerChecked.activeInHierarchy);
        timerUnchecked.SetActive(!timerUnchecked.activeInHierarchy);
    }
    public void toggleFLines()
    {
        UD.showfieldLines = !UD.showfieldLines;
        flinesChecked.SetActive(!flinesChecked.activeInHierarchy);
        flinesUnchecked.SetActive(!flinesUnchecked.activeInHierarchy);
    }
    public void saveData()
    {

        SavingSystem.SaveUser(GameObject.Find("UserData").GetComponent<UserData>());
    }
}
