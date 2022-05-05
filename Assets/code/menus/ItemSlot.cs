using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public GameObject mySkin;
    public int skinIndex;
    public GameObject selectedButton;
    GameObject[] slots;

    void Start() 
    {
        slots = GameObject.FindGameObjectsWithTag("slots");
        updateColor();
    }

    public void equipSkin() {
        //GameObject.Find("UserData").GetComponent<UserData>().skin = mySkin;
        GameObject.Find("UserData").GetComponent<UserData>().skinIndex = skinIndex;
        foreach (GameObject slot in slots) {
            slot.GetComponent<ItemSlot>().updateColor();
        }
    }

    public void updateColor() 
    {
        if (skinIndex == GameObject.Find("UserData").GetComponent<UserData>().skinIndex) {
            selectedButton.SetActive(true);
        }
        else {
            selectedButton.SetActive(false);
        }
    }
}
