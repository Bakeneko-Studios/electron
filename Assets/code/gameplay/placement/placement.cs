using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class placement : MonoBehaviour, IPointerDownHandler
{
    int clickedIndex = -1;
    GameObject curCharge;
    public GameObject[] chargeSlots;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickedIndex != -1 /*&& chargeSlots[clickedIndex].GetComponent<chargeSpawner>().isSelected*/)
        {
            if (chargeSlots[clickedIndex] == null)
            {
                clickedIndex = -1;
                return;
            }
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // if did not click on object
            if (hit.collider.tag=="room")
            {
                chargeSlots[clickedIndex].GetComponent<chargeSpawner>().spawnCharge(new Vector3(mousePos.x, mousePos.y, 0));
                // chargeSlots[clickedIndex].GetComponent<chargeSpawner>().unselect();
            }
        }
    }

    public void spawn(int i)
    {
        if (clickedIndex == i)
        {
            //chargeSlots[clickedIndex].GetComponent<chargeSpawner>().unselect();
            clickedIndex = -1;
        }
        else
        {
            if (clickedIndex != -1 && chargeSlots[clickedIndex] != null)
            {
                //chargeSlots[clickedIndex].GetComponent<chargeSpawner>().unselect();
            }
            //chargeSlots[i].GetComponent<chargeSpawner>().select();
            clickedIndex = i;
        }
    }
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.layer == 5) //5 = UI layer
            {
                return true;
            }
        }

        return false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickedIndex != -1 /*&& chargeSlots[clickedIndex].GetComponent<chargeSpawner>().isSelected*/)
        {
            if (IsPointerOverUIObject())
                return;

            if (chargeSlots[clickedIndex] == null)
            {
                clickedIndex = -1;
                return;
            }
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // if did not click on object
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag=="room")
            {
                chargeSlots[clickedIndex].GetComponent<chargeSpawner>().spawnCharge(new Vector3(mousePos.x, mousePos.y, 0));
            }
        }
    }
}
