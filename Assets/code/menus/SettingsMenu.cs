using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterAM;

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
}
