using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour
{
    public GameObject destination;
    public float teleportForce = 5;
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D obj) {
        if (obj.collider.tag == "Player")
        {
            //Vector3 d = transform.position - transform.GetChild(0).position;
            obj.transform.position = destination.transform.position;
            Vector2 dir = destination.transform.position - destination.transform.parent.position;
            Debug.Log(dir);
            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * teleportForce);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
