using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeWall : MonoBehaviour
{
    public int delay = 0;
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            yield return new WaitForSeconds(delay);
            Destroy(this.gameObject);
        }
    }
}
