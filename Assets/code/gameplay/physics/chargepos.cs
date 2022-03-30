using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargepos : MonoBehaviour
{
    public float chargeColomb = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "room")
        {
            this.transform.SetParent(collision.transform);
        }
    }

}
