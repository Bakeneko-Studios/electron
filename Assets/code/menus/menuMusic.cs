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
        if(SceneManager.GetActiveScene().name=="main menu" || SceneManager.GetActiveScene().name=="level select")
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
}
