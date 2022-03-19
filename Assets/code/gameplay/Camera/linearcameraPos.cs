using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearcameraPos : MonoBehaviour
{
    public GameObject electron;

    private float smoothTime = 0.25f;
    private float velocity;

    void Start () {
        electron = GameObject.Find("electron");
    }

    void Update() {
        float targetPositionx = electron.transform.position.x;

        float posx = Mathf.SmoothDamp(transform.position.x,targetPositionx, ref velocity, smoothTime);
        
        this.transform.position = new Vector3(posx, 0 , -10f);
    }
}
