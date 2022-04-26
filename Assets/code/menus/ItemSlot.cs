using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    //public GameObject mySkin;
    public int skinIndex;
    public void equipSkin() {
        //GameObject.Find("UserData").GetComponent<UserData>().skin = mySkin;
        GameObject.Find("UserData").GetComponent<UserData>().skinIndex = skinIndex;
    }
}
