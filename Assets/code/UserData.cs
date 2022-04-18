using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public GameObject skin;
    public int unlockedLevel;
    public bool coin0=false;
    public bool coin1=false;
    public bool coin2=false;
    public bool coin3=false;
    public bool coin4=false;
    void Start()
    {

    }

    void Update()
    {
        
    }

    void Awake()
    {
        GameObject[] dataCarriers = GameObject.FindGameObjectsWithTag("user data");
        if (dataCarriers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
