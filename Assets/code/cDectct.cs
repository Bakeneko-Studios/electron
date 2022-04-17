using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDectct : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log(other.gameObject.name);
    }
}
