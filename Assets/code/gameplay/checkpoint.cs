using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject load;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "electron")
        {
            load.transform.position=this.transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
