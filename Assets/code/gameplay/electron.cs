using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron : MonoBehaviour
{
    public GameObject gameManager;
    public Vector3 loadPoint;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("game manager");
        loadPoint=this.transform.position;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Finish")
        {
            gameManager.GetComponent<gameplayManager>().win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="checkpoint" && other.gameObject.transform.position!=loadPoint)
        {
            gameManager.GetComponent<gameplayManager>().resetSaves();
            loadPoint=other.gameObject.transform.position;
        }
    }
}
