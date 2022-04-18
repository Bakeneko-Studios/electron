using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailAlign : MonoBehaviour
{
    private GameObject parent;
    private GameObject cTrail;
    public float upX = 0f;

    void Update()
    {
        cTrail.transform.position = new Vector3(parent.transform.position.x + upX, parent.transform.position.y, parent.transform.position.z);
    }
}
