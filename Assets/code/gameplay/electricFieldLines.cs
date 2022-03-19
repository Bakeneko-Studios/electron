using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricFieldLines : MonoBehaviour
{
    // Start is called before the first frame update

    // calculate direction & magniute of electric field at a given point

    public GameObject electron;
    public GameObject[] charges;
    readonly float k = 8987551792f;

    (float,float) netE(float x, float y)
    {
        float netMagnitude = 0;
        int netDir = 0;
        
        for (int i=0; i<charges.Length; i++)
        {
            float d = Vector2.Distance(charges[i].transform.position, new Vector2(x,y));
            float magnitude = -k * charges[i].GetComponent<chargepos>().chargeColomb  / (d * d);

            netMagnitude += magnitude;
        }
        
        
        return (netMagnitude, netDir);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(netE(electron.transform.position.x, electron.transform.position.y));
    }
}
