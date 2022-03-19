using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour
{
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D obj) {
        Vector3 d = transform.position - obj.transform.position;
        obj.transform.position = destination.transform.position + d;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
