using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeWall : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
}
