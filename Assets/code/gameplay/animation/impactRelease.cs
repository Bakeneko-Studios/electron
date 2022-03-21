using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactRelease : MonoBehaviour
{
    public GameObject myPartical;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //change z rotation
        Instantiate(myPartical, transform.position, Quaternion.identity);
    }
}
