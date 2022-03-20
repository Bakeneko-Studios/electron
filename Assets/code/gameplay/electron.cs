using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron : MonoBehaviour
{
    GameObject manager;
    public Vector3 loadPoint;

    void Start()
    {
        manager = GameObject.Find("gameManager");
        loadPoint=this.transform.position;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Finish")
        {
            manager.GetComponent<gameplayManager>().win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="checkpoint" && other.gameObject.transform.position!=loadPoint)
        {
            loadPoint=other.gameObject.transform.position;
        }
    }
}
