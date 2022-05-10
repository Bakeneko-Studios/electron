using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positiveCharge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            GetComponent<chargepos>().chargeColomb=0f;
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            GetComponent<BoxCollider2D>().enabled=false;
        }
    }
}
