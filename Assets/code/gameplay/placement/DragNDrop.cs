using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour
{
    bool isDraggable;
    bool isDragging;
    Collider2D objectCollider;
    public Color invalidLocation;
    public Color validLocation;
    public GameObject theCharge;
    //GameObject lastTouching = null;
    bool validPosition = true;
    GameObject spawner;
    GameObject cam;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
        isDraggable = true;
        isDragging = true;
    }

    public void setSpawner(GameObject theSpawner, GameObject theCam)
    {
        spawner = theSpawner;
        cam = theCam;
    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theCharge.GetComponent<Image>().color = invalidLocation;
        //lastTouching = collision.gameObject;
        validPosition = false;
        count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        if (count == 0)
        {
            theCharge.GetComponent<Image>().color = validLocation;
            validPosition = true;
        }
    }

    void DragAndDrop()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                isDraggable = true;
            }
            else
            {
                isDraggable = false;
            }

            if (isDraggable)
            {
                isDragging = true;
            }
        }
        if (isDragging)
        {
            this.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            isDraggable = false;
            isDragging = false;
            if (validPosition)
                spawner.GetComponent<chargeSpawner>().spawnCharge(this.gameObject.transform.position);
            else
                spawner.GetComponent<chargeSpawner>().invalidSpawn();

            Destroy(this.gameObject);
        }
    }
}
