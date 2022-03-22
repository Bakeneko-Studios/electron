using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public GameObject mySkin;
    static GameObject skinSelected;
    public void equipSkin()
    {
        skinSelected = null;
        skinSelected = mySkin;
    }  
}
