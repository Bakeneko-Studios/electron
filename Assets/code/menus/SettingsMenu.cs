using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterAM;
    public UserData UD;
    public GameObject timerChecked;
    public GameObject timerUnchecked;
    public GameObject flinesChecked;
    public GameObject flinesUnchecked;

    public void SetMasterVolume(float volumeMas)
    {
        masterAM.SetFloat("MasterVolume", volumeMas);
    }
    public void SetMusicVolume(float volumeM)
    {
        masterAM.SetFloat("MusicVolume", volumeM);
    }
    public void SetEffectsVolume(float volumeE)
    {
        masterAM.SetFloat("EffectsVolume", volumeE);
    }

    public void back()
    {
        SceneManager.LoadScene("main menu");
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
}
