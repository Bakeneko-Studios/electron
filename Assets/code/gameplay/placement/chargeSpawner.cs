using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class chargeSpawner : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    public GameObject draggingCharge; // the dragging prefab
    public GameObject spawningCharge; // the actual spawned prefab
    public GameObject canvas;
    bool dragging = false;
    public int numOfCharges = 0;
    public TextMeshProUGUI text;
    public GameObject cam;
    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
        {
            GameObject theCharge = Instantiate(draggingCharge);
            theCharge.transform.SetParent(canvas.transform);
            theCharge.GetComponent<DragNDrop>().setSpawner(this.gameObject, cam);
            dragging = true;
        }
    }

    public void spawnCharge(Vector3 position)
    {
        GameObject spawnedCharge = Instantiate(spawningCharge);
        spawnedCharge.transform.position = position;
        numOfCharges--;
        updateText();
        dragging = false;
        
        // destory self if no more charges left
        if (numOfCharges == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void invalidSpawn()
    {
        dragging = false;
    }

    void updateText()
    {
        text.text = numOfCharges.ToString();
    }

    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
