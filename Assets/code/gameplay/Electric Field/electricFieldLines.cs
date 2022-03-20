using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class electricFieldLines : MonoBehaviour
{
    // Start is called before the first frame update

    // calculate direction & magniute of electric field at a given point

    public GameObject[] charges;
    public GameObject linePrefab;
    public GameObject arrowPrefab;
    LineRenderer[,] lr;
    readonly float k = 8987551792f;
    public GameObject[,] arrows;
    public float arrowRoationOffset;
    public bool spawnArrows = false;
    public bool showElectricField = false;
    public float arrowPositionOffset;
    public int arrowStep = 50;
    public int numOfPoints;
    public float step;
    int curPoints = 0;
    bool touchingCharge = false;
    public float margin = 3;
    bool invert = false; // switch electron to proton for testing
    Vector3 netE(Vector2 pos)
    {
        float x = pos.x;
        float y = pos.y;

        double ex = x;
        double ey = y;

        for (int i=0; i<charges.Length; i++)
        {
            float xDist = charges[i].transform.position.x - x;
            float yDist = charges[i].transform.position.y - y;
            float denom = Mathf.Pow(Mathf.Pow(xDist, 2) + Mathf.Pow(yDist, 2), 2);
            double num = charges[i].GetComponent<chargepos>().chargeColomb / (4 * Mathf.PI * 8.85e-12); // permittivity of free space
            if (invert)
                num *= -1;

            ex += num * xDist / denom;
            ey += num * yDist / denom;
        }
        //ex /= 100;
        //ey /= 100;
        return new Vector3((float)ex,(float)ey,0);
    }



    void Start()
    {
        updateCharges();
        //numOfPoints = linePrefab.GetComponent<LineRenderer>().positionCount;
    }

    public void updateCharges()
    {
        //remove current lines
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        if (showElectricField)
        {

            charges = GameObject.FindGameObjectsWithTag("efield");
            lr = new LineRenderer[charges.Length, 8];
            for (int i = 0; i < charges.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    lr[i, j] = Instantiate(linePrefab).GetComponent<LineRenderer>();
                    lr[i, j].transform.SetParent(this.transform);
                    //lr[i, j].positionCount = numOfPoints;
                }
            }

        }

        if (spawnArrows)
        {
            arrows = new GameObject[charges.Length, 8];
            for (int i = 0; i < charges.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arrows[i, j] = Instantiate(arrowPrefab);
                    arrows[i, j].transform.SetParent(this.transform);
                    //arrows[i, j].SetActive(false);
                }
            }
        }
            


    }

    //void plotPoints()
    //{
    //    points[0].transform.position = Vector2.MoveTowards(electron.transform.position, netE(electron.transform.position), step);
    //    for (int i = 1; i < numOfPoints; i++)
    //    {
    //        if (i > curPoints)
    //            curPoints = i;

    //        points[i].SetActive(true);
    //        points[i].transform.position = Vector2.MoveTowards(points[i - 1].transform.position, netE(points[i-1].transform.position), step);
    //        Collider2D[]  colliders = Physics2D.OverlapCircleAll(points[i].transform.position, 0.0f);
    //        for (int j=0; j<colliders.Length; j++)
    //        {
    //            if (colliders[j].tag == "efield")
    //            {
    //                for (int k=i; k<=curPoints; k++)
    //                {
    //                    points[k].SetActive(false);
    //                }

    //                curPoints = i;
    //                return;
    //            }
    //        }
    //    }
    //}

    void plotArrow(Vector2 startPos, int chargeIdx, int pointIdx)
    {
        if (!spawnArrows)
            return;
        arrows[chargeIdx, pointIdx].transform.position = startPos;
        // roatate arrow towards/away charge\Vector3 targ = staticCompassTarget.transform.position;
        Vector3 targ = charges[chargeIdx].transform.position;
        targ.z = 0f;

        Vector3 objectPos = arrows[chargeIdx, pointIdx].transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg + arrowRoationOffset;
        arrows[chargeIdx, pointIdx].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void drawLine(Vector2 startPos, int chargeIdx, int pointIdx)
    {

        Vector3[] linePoints = new Vector3[numOfPoints];
        linePoints[0] = startPos;
        for (int i = 1; i < numOfPoints; i++)
        {
            linePoints[i] = Vector2.MoveTowards(linePoints[i - 1], netE(linePoints[i - 1]), step);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(linePoints[i], 0.0f);

            for (int j = 0; j < colliders.Length; j++)
            {
                if (colliders[j].tag == "efield")
                {
                    //remove repeating lines
                    if (colliders[j].GetComponent<chargepos>().chargeColomb > 0 && charges[chargeIdx].GetComponent<chargepos>().chargeColomb < 0)
                    {

                        lr[chargeIdx, pointIdx].gameObject.SetActive(false);
                       
                        return;
                    }
                    Array.Resize(ref linePoints, i+1);
                    lr[chargeIdx, pointIdx].positionCount = linePoints.Length;
                    lr[chargeIdx, pointIdx].SetPositions(linePoints);
                   
                    return;
                }
            }
        }

        lr[chargeIdx, pointIdx].positionCount = linePoints.Length;
        lr[chargeIdx,pointIdx].SetPositions(linePoints);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "efield")
            touchingCharge = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "efield")
            touchingCharge = false;
    }
    // Update is called once per frame
    void Update()
    {
        //plotPoints();
        if (showElectricField)
        {

            for (int i = 0; i < charges.Length; i++)
            {
                if (charges[i].GetComponent<chargepos>().chargeColomb > 0)
                    invert = true;
                else
                    invert = false;
                //up
                drawLine(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y + margin), i, 0);
                //plotArrow(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y + margin + arrowPositionOffset), i, 0);
                //top right
                drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y + margin), i, 1);
                //plotArrow(new Vector2(charges[i].transform.position.x + margin + arrowPositionOffset, charges[i].transform.position.y + margin + arrowPositionOffset), i, 1);
                //right
                drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y), i, 2);
                //plotArrow(new Vector2(charges[i].transform.position.x + margin + arrowPositionOffset, charges[i].transform.position.y), i, 2);
                // bottom right
                drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y - margin), i, 3);
                //plotArrow(new Vector2(charges[i].transform.position.x + margin + arrowPositionOffset, charges[i].transform.position.y - margin - arrowPositionOffset), i, 3);
                // down
                drawLine(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y - margin), i, 4);
                //plotArrow(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y - margin - arrowPositionOffset), i, 4);
                //down left
                drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y - margin), i, 5);
                //plotArrow(new Vector2(charges[i].transform.position.x - margin - arrowPositionOffset, charges[i].transform.position.y - margin - arrowPositionOffset), i, 5);
                // left
                drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y), i, 6);
                //plotArrow(new Vector2(charges[i].transform.position.x - margin - arrowPositionOffset, charges[i].transform.position.y), i, 6);
                // top left
                drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y + margin), i, 7);
                //plotArrow(new Vector2(charges[i].transform.position.x - margin - arrowPositionOffset, charges[i].transform.position.y + margin + arrowPositionOffset), i, 7);
            }

            //Debug.Log(netE(electron.transform.position.x, electron.transform.position.y));
            //lr.SetPosition(0, electron.transform.position);
            //lr.SetPosition(1, netE(electron.transform.position.x, electron.transform.position.y));


        }
    }
}
