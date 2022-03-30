using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echo : MonoBehaviour
{
    private Vector2 curDirection;
    public float minDistance = 1f;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float dTime = 1f;
    
    public GameObject[] echos;

    void Update()
    {
        curDirection = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
        //Debug.Log(curDirection);
        if (curDirection.y > minDistance | curDirection.y < -minDistance | curDirection.x > minDistance | curDirection.x < -minDistance)
        {
            if(timeBtwSpawns <= 0)
            {
                int rand = Random.Range(0, echos.Length);
                GameObject instance = (GameObject)Instantiate(echos[rand], transform.position, Quaternion.identity);
                Destroy(instance, dTime);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
