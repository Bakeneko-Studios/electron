using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echo : MonoBehaviour
{
    //This Script just spawns a list of objects randomly on the position of the trail
    //The stuff you attach on this thing should be animated with fadding animation
    //Still room for improvement, I want to make it not spawn when the onject is moving
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    
    public GameObject[] echos;
    void Start()
    {


    }
    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, echos.Length);
            GameObject instance = (GameObject)Instantiate(echos[rand], transform.position, Quaternion.identity);
            Destroy(instance, 8f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
