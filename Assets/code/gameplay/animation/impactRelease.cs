using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactRelease : MonoBehaviour
{
    public GameObject myPartical;

    private Vector2 curDirection;
    //Get Direction
    private void Update() 
    {
        curDirection = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
    }

    //Release Partical
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Vector3 daPos = new Vector3(transform.position.x+(curDirection.x/30), transform.position.y+(curDirection.y/30), transform.position.z);
        Quaternion daQuat = Quaternion.LookRotation(Vector3.forward, curDirection);

        GameObject particalC = Instantiate(myPartical, daPos, daQuat);
    }
}
//Quaternion(0.707106829,0,0,0.707106829)