using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeManager : MonoBehaviour
{
    public GameObject scrollBar;
    float scrollPos = 0;
    float[] pos;

    private float smoothTime = 0.01f;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i=0; i < pos.Length;i++) {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0)) {
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else if  (Input.GetKeyDown(KeyCode.RightArrow) && scrollBar.GetComponent<Scrollbar>().value <= 0.9) 
        {
            float curScrollPos = scrollBar.GetComponent<Scrollbar>().value;
            scrollBar.GetComponent<Scrollbar>().value = Mathf.SmoothDamp(curScrollPos, curScrollPos + distance, ref velocity, smoothTime);
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else if  (Input.GetKeyDown(KeyCode.LeftArrow) && scrollBar.GetComponent<Scrollbar>().value >= 0.1) 
        {
            float curScrollPos = scrollBar.GetComponent<Scrollbar>().value;
            scrollBar.GetComponent<Scrollbar>().value = Mathf.SmoothDamp(curScrollPos, curScrollPos - distance, ref velocity, smoothTime);
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else {
            for (int i=0; i < pos.Length; i++) {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2)) {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value,pos[i],0.1f);
                }
            }
        }
    }
}
