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
    GameObject[] arrows;
    int step = 10;
    int prevCount = 0;
    Vector3[] prevPositions;
    GameObject electricField;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        initArrows();
    }

    public void setVariables(int steps, GameObject efield)
    {
        electricField = efield;
        step = steps;
    }

    void initArrows()
    {

        int newSize = lr.positionCount / 10 + 1;
        arrows = new GameObject[newSize];
        for (int i = 0; i < lr.positionCount; i++)
        {
            if (i % step == 0)
            {
                arrows[i/10] = Instantiate(spawningArrow);
                arrows[i / 10].transform.SetParent(this.transform);
                arrows[i / 10].transform.position = lr.GetPosition(i);
                //rotate
                efield = GameObject.FindGameObjectsWithTag("efield");
                foreach (GameObject e in efield)
                {
                    float q2 = e.GetComponent<chargepos>().chargeColomb;
                    float d = Vector2.Distance(arrows[i / 10].transform.position, e.transform.position);

                    //rotateAngle += new Vector3(0, 0, Mathf.Acos((e.transform.position - transform.position).normalized.x));
                    Vector3 testForce = (e.transform.position - arrows[i / 10].transform.position).normalized * (-k * (qt * q2) / (d * d));
                    testForceSum += testForce;
                }

                float rotateAngle = Mathf.Atan(testForceSum.y / testForceSum.x) * 180 / Mathf.PI;
                arrows[i / 10].transform.eulerAngles = new Vector3(0, 0, rotateAngle + 90f);
            }
        }
    }

    void destroyArrows()
    {
        for (int i = 0; i < arrows.Length; i++)
            Destroy(arrows[i]);
     
    }
    // Update is called once per frame
    void Update()
    {
        if (prevCount != lr.positionCount)
        {
            destroyArrows();
            initArrows();
            prevCount = lr.positionCount;
        }

        Vector3[] newPositions = new Vector3[lr.positionCount];
        lr.GetPositions(newPositions);
        //if (prevPositions != newPositions)
        //{
        //    destroyArrows();
        //    initArrows();
        //    prevPositions = newPositions;
        //}


        for (int i = 0; i < lr.positionCount; i++)
        {
            if (i % 10 == 0)
            {
                arrows[i / 10].transform.position = newPositions[i];
                //rotate
                efield = GameObject.FindGameObjectsWithTag("efield");
                foreach (GameObject e in efield)
                {
                    float q2 = e.GetComponent<chargepos>().chargeColomb;
                    float d = Vector2.Distance(arrows[i / 10].transform.position, e.transform.position);

                    //rotateAngle += new Vector3(0, 0, Mathf.Acos((e.transform.position - transform.position).normalized.x));
                    Vector3 testForce = (e.transform.position - arrows[i / 10].transform.position).normalized * (-k * (qt * q2) / (d * d));
                    testForceSum += testForce;
                }

                float rotateAngle = Mathf.Atan(testForceSum.y / testForceSum.x) * 180 / Mathf.PI;
                arrows[i / 10].transform.eulerAngles = new Vector3(0, 0, rotateAngle + 90f);
            }
        }
    }
}
