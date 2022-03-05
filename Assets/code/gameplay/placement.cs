using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour
{
    public GameObject positive;
    public GameObject negative;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            GameObject a = Instantiate(positive, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            GameObject a = Instantiate(negative, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);
        }
    }
}
