using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour
{
    public GameObject destination;
    public float teleportForce = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D obj) {
        Vector3 d = transform.position - obj.transform.position;
        obj.transform.position = destination.transform.position + d;
        Vector2 dir = destination.transform.position - destination.transform.parent.position;
        obj.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir.normalized * teleportForce);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
