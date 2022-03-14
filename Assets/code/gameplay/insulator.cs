using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<electron>()!=null)
        {
            Destroy(other.gameObject);
        }
    }
}
