using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform backgroundTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundTransform.position += new Vector3(1.6f, 0f, 0f) * Time.deltaTime;
        if (backgroundTransform.position.x >= 17.1f)
        {
            backgroundTransform.position = new Vector3(-1.76f, -0.25f, 20f);
        }
    }
}
