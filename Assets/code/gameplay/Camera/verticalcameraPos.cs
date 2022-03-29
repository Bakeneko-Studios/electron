using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalcameraPos : MonoBehaviour
{
    public GameObject electron;

    private float smoothTime = 0.25f;
    private float velocity;

    void Start () {
        electron = GameObject.Find("electron");
    }

    void Update() {
        float targetPositiony = electron.transform.position.y;

        float posy = Mathf.SmoothDamp(transform.position.y,targetPositiony + 3f, ref velocity, smoothTime);
        
        this.transform.position = new Vector3(0, posy, -10f);
    }
}
