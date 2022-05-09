using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactRelease : MonoBehaviour
{
    public GameObject myPartical;
    public bool directional = true;

    private Vector2 curDirection;
    private void Update() 
    {
        //Get Direction
        curDirection = gameObject.GetComponentInParent<Rigidbody2D>().velocity;

        //Release Partical
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<electron>().colliding == true)
        {
            Vector3 daPos = new Vector3(transform.position.x+(curDirection.x/30), transform.position.y+(curDirection.y/30), transform.position.z);
            Quaternion daQuat = Quaternion.LookRotation(Vector3.forward, curDirection);

            if (directional == true)
            {
                GameObject particalC = Instantiate(myPartical, daPos, daQuat);
                Destroy(particalC,3f);
            }
            else
            {
                GameObject particalC = Instantiate(myPartical, gameObject.transform.position, Quaternion.identity);
                Destroy(particalC,3f);
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<electron>().colliding = false;
        }
    }
}