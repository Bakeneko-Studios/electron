using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinsPreview : MonoBehaviour
{
    public GameObject slot;
    public int skinIndex;
    public GameObject[] skinsList;
    void Awake()
    {
        skinIndex = slot.GetComponent<ItemSlot>().skinIndex;
        transform.Find(skinsList[skinIndex].name).gameObject.SetActive(true);                
    }

    private bool offSet;
    public float velocity;
    void FixedUpdate()
    {
        if (skinIndex == slot.transform.parent.gameObject.GetComponent<swipeManager>().selectedPanel)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(40f,40f),0.1f);
            GetComponent<Rigidbody2D>().simulated = true;
            if (!offSet) {
                transform.localPosition = new Vector3(50f,0,0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,velocity);
                offSet = true;
            }

            float r = Vector3.Distance(transform.position,slot.transform.position);
            GetComponent<Rigidbody2D>().AddForce((slot.transform.position - transform.position).normalized * (velocity * velocity / r));
        }
        else {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(100f,100f),0.1f);
            transform.localPosition = new Vector3(0,0,0);
            GetComponent<Rigidbody2D>().simulated = false;
            offSet = false;
        }
    }
}
