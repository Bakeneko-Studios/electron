using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinsPreview : MonoBehaviour
{
    GameObject target;
    GameObject slot;
    Camera cam;
    public GameObject[] allSkins; //all skins child applied on the electron 
    public int skinIndex;
    // Start is called before the first frame update
    void Start()
    {
        target = this.gameObject;
        slot = transform.parent.gameObject;
        cam = GameObject.Find("SkinsMenu").GetComponent<skinsMenu>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        target.transform.position = cam.ScreenToWorldPoint(slot.transform.position);
    }
}
