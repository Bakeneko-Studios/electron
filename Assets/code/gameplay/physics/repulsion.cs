using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repulsion : MonoBehaviour {
    readonly float k = 8987551792f;
    public float qt = 1f;
    //GameObject charge;
    GameObject[] efield;
    public bool started = false;
    GameObject room;
    void Start() {
        //charge = GameObject.FindGameObjectWithTag("Player");
        room = GameObject.FindGameObjectWithTag("room");
    }

    public void startPhysics()
    {
        started = true;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    public void stopPhysics()
    {
        started = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }

    void FixedUpdate() {
 
        if (started)
        {
            foreach (Transform e in room.transform)
            {
                float q2 = e.gameObject.GetComponent<chargepos>().chargeColomb;
                float d = Vector2.Distance(transform.position, e.position);

                GetComponent<Rigidbody2D>().AddForce((e.position - transform.position).normalized * (-k * (qt * q2) / (d * d)));
               
            }
        }

    }

    Transform ePlateGO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "room")
        {
            room = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        ePlateGO = collision.gameObject.transform;
        if (collision.gameObject.tag == "ePlate")
        {
            float q2 = ePlateGO.gameObject.GetComponent<chargepos>().chargeColomb;
            float d = Vector2.Distance(transform.position, ePlateGO.position);
            float r = ePlateGO.rotation.z;

            float netforce = ((ePlateGO.position - transform.position).normalized * (-k * (qt * q2) / (d * d))).y;

            float forceY = Mathf.Cos(r) * netforce;
            float forceX = Mathf.Sin(r) * netforce;

            Vector3 force = new Vector3(forceX,forceY,0);
            GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}
