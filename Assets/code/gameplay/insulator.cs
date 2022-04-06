using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insulator : MonoBehaviour
{
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("game manager");
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<electron>()!=null)
        {
            other.gameObject.GetComponent<repulsion>().stopPhysics();
            other.gameObject.SetActive(false);
            gameManager.GetComponent<scoring>().deaths+=1;
        }
    }
}
