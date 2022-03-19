using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour
{
    GameObject electron;

    private Vector3 offset = new Vector3(0f,0f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    void Start () {
        electron = GameObject.Find("electron");
    }

    void Update() {
        Vector3 targetPosition = electron.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition, ref velocity, smoothTime);
    }
}
