using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class lineGlow : MonoBehaviour
{

    LineRenderer lr;
    Light2D lightScript;
    // Start is called before the first frame update
    void Start()
    {

        lr = GetComponent<LineRenderer>();
        lightScript = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (lightScript.freeFormPoints.points.Count != lr.positionCount)
        {
            lightScript.freeFormPoints.points = new List<Vector2>(new Vector2[lr.positionCount]);
            //GameObject.Find("Lighting Manager 2D").GetComponent<LightingManager2D>().UpdateProfile();
        }
        try{
            for (int i = 0; i < lr.positionCount; i++)
            {

                lightScript.freeFormPoints.points[i] = lr.GetPosition(i);
            }
        }
        catch
        {
            Debug.Log(lightScript.freeFormPoints.points.Count);
        }
    }
}
