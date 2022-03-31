using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeNotWall : MonoBehaviour
{
    public Color wallColor;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color=wallColor;
        }
    }
}
