using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float backgroundSpeed;
    void Update()
    {
        transform.position += new Vector3(backgroundSpeed,0,0) * Time.deltaTime;
        if (transform.position.x >= 40f)
            transform.position = Vector3.zero;
    }
}
