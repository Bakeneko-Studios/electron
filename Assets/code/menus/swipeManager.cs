using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeManager : MonoBehaviour
{
    public bool zoomTarget;
    public GameObject scrollBar;
    float scrollPos = 0;
    float[] pos;

    private float smoothTime = 0.01f;
    private float velocity;

    public int selectedPanel;

    float distance;

    public void movePanel(int dir)
    {
        
        if (scrollPos + (dir * distance) > (pos.Length - 1) * distance)
            scrollPos = 0;
        else if (scrollPos + (dir * distance) < -0.1)
            scrollPos = (pos.Length-1) * distance;
        else
            scrollPos += (dir * distance);
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i=0; i < pos.Length;i++) {
            pos[i] = distance * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
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

        if (zoomTarget)
        {
            for (int i=0; i < pos.Length; i++) 
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2)) {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f,1f),0.1f);
                    selectedPanel = i;
                    for (int a=0; a < pos.Length; a++) 
                    {
                        if (a != i) {
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.48f,0.48f),0.1f);
                        }
                    }
                }
            }
        }
    }
}
