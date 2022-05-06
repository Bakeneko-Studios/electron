using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insulator : MonoBehaviour
{
    GameObject gameManager;
    AudioSource death;
    public AudioClip deathSound;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("game manager");
        death = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            death.PlayOneShot(deathSound);
            other.gameObject.GetComponent<repulsion>().stopPhysics();
            other.gameObject.SetActive(false);
            gameManager.GetComponent<scoring>().deaths+=1;
            gameManager.GetComponent<buttonFunctions>().loadCheckpoint();
        }
    }
}
