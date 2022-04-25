using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    public GameObject[] allSkins; //all skins child applied on the electron 
    public int skinIndex;
    public string[] skinsList = new string[]//will modify to be automatic later on
    {
        "DefultSkin",
        "EchoTrail",
        "FlameTrail",
        "IceTrail",
        "RGBTrailG",
        "TripleTrailG",
        "BloodyBurst",
        "LightningTrail"
    };
    void Awake()
    {
        allSkins = GameObject.FindGameObjectsWithTag("skin");
        foreach (GameObject child in allSkins)
        {
            child.SetActive(false);
        }
        skinIndex = GameObject.Find("UserData").GetComponent<UserData>().skinIndex;
        GameObject.FindGameObjectWithTag("Player").transform.Find(skinsList[skinIndex]).gameObject.SetActive(true);                
    }


}
