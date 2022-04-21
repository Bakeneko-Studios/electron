using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMusic : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioClip music;
    void Awake()
    {
        GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("menu music");
        if (musicPlayers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        musicPlayer=GetComponent<AudioSource>();
        
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded+=OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode scenemode)
    {
        if(scene.name=="main menu" || scene.name=="level select")
        {
            if(musicPlayer.isPlaying==false)
            {
                musicPlayer.Play();
            } 
        }
        else
        {
            musicPlayer.Stop();
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded-=OnSceneLoaded;
    }
}