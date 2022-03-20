using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efArrow : MonoBehaviour
{
    public GameObject spawningArrow;

    LineRenderer lr;

    readonly float k = 8987551792f;
    GameObject[] efield;
    float qt = 0.0001f;
    Vector3 testForceSum;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lr.positionCount; i++)
        {
            if (i % 10 == 0)
            {
                //spawning
                GameObject spawnedArrow = Instantiate(spawningArrow);
                spawnedArrow.transform.position = lr.GetPosition(i);

                //rotate
                efield = GameObject.FindGameObjectsWithTag("efield");
                foreach (GameObject e in efield)
                {
                    float q2 = e.GetComponent<chargepos>().chargeColomb;
                    float d = Vector2.Distance(spawnedArrow.transform.position, e.transform.position);

                    //rotateAngle += new Vector3(0, 0, Mathf.Acos((e.transform.position - transform.position).normalized.x));
                    Vector3 testForce = (e.transform.position - spawnedArrow.transform.position).normalized * (-k * (qt * q2) / (d * d));
                    testForceSum += testForce;
                }

                float rotateAngle = Mathf.Atan(testForceSum.y/testForceSum.x) * 180 / Mathf.PI ;
                spawnedArrow.transform.eulerAngles = new Vector3(0,0,rotateAngle + 90f);
            }
        }
    }
}
