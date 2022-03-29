using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearcameraPos : MonoBehaviour
{
    public GameObject electron;

    private float smoothTime = 0.25f;
    private float velocity;
    public bool freezex;
    public bool freezey;

    void Start()
    {
        electron = GameObject.Find("electron");
    }

    void Update()
    {
        if(freezex==false)
        {
            float targetPositionx = electron.transform.position.x;
            float posx = Mathf.SmoothDamp(transform.position.x,targetPositionx, ref velocity, smoothTime);
            this.transform.position = new Vector3(posx, 0 , -10f);
        }
        if(freezey==false)
        {
            float targetPositiony = electron.transform.position.y;
            float posy = Mathf.SmoothDamp(transform.position.y,targetPositiony, ref velocity, smoothTime);
            this.transform.position = new Vector3(0, posy , -10f);
        }
        
    }
}
