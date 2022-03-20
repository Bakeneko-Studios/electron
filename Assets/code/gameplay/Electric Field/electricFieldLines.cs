using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricFieldLines : MonoBehaviour
{
    // Start is called before the first frame update

    // calculate direction & magniute of electric field at a given point

    public GameObject electron;
    public GameObject elecPrefab;
    public GameObject[] charges;
    public GameObject linePrefab;
    LineRenderer[,] lr;
    readonly float k = 8987551792f;
    public GameObject[] points;
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
        lr = new LineRenderer[charges.Length,8];
        for (int i=0; i < charges.Length; i++)
        {
            for (int j=0; j<8; j++)
                lr[i,j] = Instantiate(linePrefab).GetComponent<LineRenderer>();
        }
    }
    void plotPoints()
    {
        points[0].transform.position = Vector2.MoveTowards(electron.transform.position, netE(electron.transform.position), step);
        for (int i = 1; i < numOfPoints; i++)
        {
            if (i > curPoints)
                curPoints = i;

            points[i].SetActive(true);
            points[i].transform.position = Vector2.MoveTowards(points[i - 1].transform.position, netE(points[i-1].transform.position), step);
            Collider2D[]  colliders = Physics2D.OverlapCircleAll(points[i].transform.position, 0.0f);
            for (int j=0; j<colliders.Length; j++)
            {
                if (colliders[j].tag == "efield")
                {
                    for (int k=i; k<=curPoints; k++)
                    {
                        points[k].SetActive(false);
                    }

                    curPoints = i;
                    return;
                }
            }
        }
    }

    void drawLine(Vector2 startPos, int chargeIdx, int pointIdx)
    {
        Vector3[] linePoints = new Vector3[numOfPoints];
        linePoints[0] = startPos;
        for (int i = 1; i < numOfPoints; i++)
        {
            Vector2 newPoint = Vector2.MoveTowards(linePoints[i - 1], netE(linePoints[i - 1]), step);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(linePoints[i], 0.0f);
            for (int j = 0; j < colliders.Length; j++)
            {
                if (colliders[j].tag == "efield")
                {
                    break;
                }
            }
            linePoints[i] = newPoint; // didn't touch charges
        }
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
        for (int i=0; i<charges.Length; i++)
        {
            if (charges[i].GetComponent<chargepos>().chargeColomb > 0)
                invert = true;
            else
                invert = false;
            //up
            drawLine(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y+ margin), i, 0);

            //top right
            drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y + margin), i, 1);

            //right
            drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y), i, 2);

            // bottom right
            drawLine(new Vector2(charges[i].transform.position.x + margin, charges[i].transform.position.y - margin), i, 3);

            // down
            drawLine(new Vector2(charges[i].transform.position.x, charges[i].transform.position.y - margin), i, 4);

            //down left
            drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y - margin), i,5 );

            // left
            drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y), i, 6);

            // top left
            drawLine(new Vector2(charges[i].transform.position.x - margin, charges[i].transform.position.y + margin), i, 7);

        }

        //Debug.Log(netE(electron.transform.position.x, electron.transform.position.y));
        //lr.SetPosition(0, electron.transform.position);
        //lr.SetPosition(1, netE(electron.transform.position.x, electron.transform.position.y));


    }
}
