using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public GameObject skin;
    public int unlockedLevel;
    public List<int[]> levels = new List<int[]>
    {
        new int[2] {0,0},  //level 1
        new int[2] {0,0},  //level 2
        new int[2] {0,0},  //level 3
        new int[2] {0,0},  //level 4
        new int[2] {0,0},  //level 5
        new int[2] {0,0},  //level 6
        new int[2] {0,0},  //level 7
        new int[2] {0,0},  //level 8
        new int[2] {0,0},  //level 9
        new int[2] {0,0},  //level 10
        new int[2] {0,0},  //level 11
        new int[2] {0,0},  //level 12
        new int[2] {0,0},  //level 13
        new int[2] {0,0},  //level 14
        new int[2] {0,0},  //level 15
        new int[2] {0,0},  //level 16
        new int[2] {0,0},  //level 17
        new int[2] {0,0},  //level 18
        new int[2] {0,0},  //level 19
        new int[2] {0,0},  //level 20
        new int[2] {0,0},  //level bonus
    };

    public bool feildLines=true;
    public bool timer=true;

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
