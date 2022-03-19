using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron : MonoBehaviour
{
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("gameManager");
    }

    // Update is called once per frame
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
}
