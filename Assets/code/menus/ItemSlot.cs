using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public GameObject mySkin;
    public int skinIndex;
    public GameObject selectedButton;
    public GameObject lockIcon;
    public GameObject prompt;
    public bool unlocked;
    public int cost;
    GameObject[] slots;
    void Awake()
    {
        UserData.unlockedSkins[skinIndex] = unlocked;
    }
    void Start() 
    {
        slots = GameObject.FindGameObjectsWithTag("slots");
        updateColor();
    }
    public void equipSkin()
    {
        if(unlocked)
        {
            UserData.skinIndex = skinIndex;
            foreach (GameObject slot in slots) {
                slot.GetComponent<ItemSlot>().updateColor();
            }
            SavingSystem.SaveUser();
        }
        else if(UserData.coinCount >= cost)
        {
            prompt.SetActive(true);
        }
        else Debug.Log("too poor lmao");
    }
    public void updateColor() 
    {
        selectedButton.SetActive(skinIndex == UserData.skinIndex);
        lockIcon.SetActive(!UserData.unlockedSkins[skinIndex]);
    }
    public void unlockSkin()
    {
        UserData.coinCount-=cost;
        unlocked=true;
        StartCoroutine(unlock());
        SavingSystem.SaveUser();
    }
    IEnumerator unlock()
    {
        Image a = lockIcon.GetComponent<Image>();
        for (float i = 1; i > 0; i-=0.01f)
        {
            a.color = new Color(a.color.r,a.color.g,a.color.b,i);
            yield return new WaitForSeconds(0.01f);
        }
        lockIcon.SetActive(false);
    }
}
