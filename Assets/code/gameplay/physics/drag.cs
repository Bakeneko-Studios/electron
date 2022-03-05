using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

    Vector3 worldPosition;
    public GameObject[] efield;

    void Start() {
        efield = GameObject.FindGameObjectsWithTag("efield");
    }


    void Update() {
        foreach(GameObject e in efield) {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }
}
