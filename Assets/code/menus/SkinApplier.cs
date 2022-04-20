using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    //private GameObject[] daParent;
    //public GameObject mySkin;
    static GameObject skinSelected; 
    public GameObject[] allSkins;
    void Awake()
    {
        allSkins = GameObject.FindGameObjectsWithTag("skin");
        foreach (GameObject child in allSkins)
        {
            child.SetActive(false);
        }
        skinSelected = GameObject.Find("UserData").GetComponent<UserData>().skin;
        //Debug.Log("Awake function called");
        GameObject.FindGameObjectWithTag("Player").transform.Find(skinSelected.name).gameObject.SetActive(true);


        //daParent = GameObject.FindGameObjectsWithTag("player");     
        ///*   
        ////Method1: make children
        //foreach (GameObject electron in daParent)
        //{
        //    foreach (Transform child in electron.transform)
        //    {
        //        if (child.tag == "Skin")
        //        {
        //            GameObject.Destroy(child);
        //        }
        //    }        

        //    Instantiate(skinSelected);
        //    skinSelected.transform.SetParent(electron.transform);
        //}
        //*/
        ////Method2: make visible
        //foreach (GameObject electron in daParent)
        //{
        //    foreach (Transform child in electron.transform)
        //    {
        //        if (child.tag == "Skin")
        //        {
        //            child.gameObject.SetActive(false);
        //        }
        //    }
        //    skinSelected.SetActive(true);
        //}
        ////Method3: spawn electron with the correct skin
        
    }      
}
