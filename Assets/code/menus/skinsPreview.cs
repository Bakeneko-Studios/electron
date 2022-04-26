using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinsPreview : MonoBehaviour
{
    public GameObject slot;
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
        skinIndex = slot.GetComponent<ItemSlot>().skinIndex;
        transform.Find(skinsList[skinIndex]).gameObject.SetActive(true);                
    }

    public int steps = 100;
    private bool offSet;

    void FixedUpdate()
    {
        if (skinIndex == slot.transform.parent.gameObject.GetComponent<swipeManager>().selectedPanel)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(40f,40f),0.1f);
            if (!offSet) {
                transform.localPosition = new Vector3(50f,0,0);
                offSet = true;
            }
            transform.RotateAround(slot.transform.position, Vector3.forward, 1f);
        }
        else {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(100f,100f),0.1f);
            transform.localPosition = new Vector3(0,0,0);
            offSet = false;
        }
    }
}
