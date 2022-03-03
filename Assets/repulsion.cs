using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repulsion : MonoBehaviour {
    readonly float k = 8987551792f;
    public float qt = 1f;
    GameObject charge;
    GameObject[] efield;

    void Start() {
        charge = GameObject.Find("Test charge");
        efield = GameObject.FindGameObjectsWithTag("efield");
    }

    void FixedUpdate() {
        foreach(GameObject e in efield) {
            float q2 = e.GetComponent<chargepos>().chargeColomb;
            float d = Vector2.Distance(charge.transform.position,e.transform.position);

            charge.GetComponent<Rigidbody2D>().AddForce((e.transform.position - charge.transform.position).normalized * (-k * (qt * q2) / (d*d)));
        }

    }
}
