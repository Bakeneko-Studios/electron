using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeildLinesTog : MonoBehaviour
{
    public bool showLines = true;
    void Awake() 
    {
        showLines =  GameObject.Find("UserData").GetComponent<UserData>().feildLines;

        gameObject.SetActive(showLines);
    }
}
