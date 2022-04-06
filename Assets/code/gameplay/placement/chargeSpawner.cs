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
    public Color selected;
    public GameObject gameplayManager;
    public GameObject electricField;
    Color unselected;
    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
        {
            GameObject theCharge = Instantiate(draggingCharge);
            theCharge.transform.SetParent(canvas.transform);
            theCharge.GetComponent<DragNDrop>().setSpawner(this.gameObject);
            dragging = true;
        }
    }

    public void spawnCharge(Vector3 position)
    {
        if(numOfCharges>0)
        {
            GameObject spawnedCharge = Instantiate(spawningCharge);
            spawnedCharge.transform.position = position;
            gameplayManager.GetComponent<gameplayManager>().placedCharges.Push(spawnedCharge);
            gameplayManager.GetComponent<gameplayManager>().savedPositions.Push(gameplayManager.GetComponent<gameplayManager>().electron.transform.position);

            electricField.GetComponent<electricFieldLines>().updateCharges();
            if (!gameplayManager.GetComponent<gameplayManager>().infiniteCharges) {
                numOfCharges--;
                updateText();
            }
            gameplayManager.GetComponent<scoring>().chargesUsed+=1;
            dragging = false;
        }
    }
  

    public void select()
    {
        this.GetComponent<Image>().color = selected;
    }

    public void unselect()
    {

        this.GetComponent<Image>().color = unselected;
    }

    public void invalidSpawn()
    {
        dragging = false;
    }

    public void updateText()
    {
        text.text = numOfCharges.ToString();
    }

    void Start()
    {
        unselected = this.GetComponent<Image>().color;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameplayManager.GetComponent<gameplayManager>().infiniteCharges)
            text.text = "∞";
    }
}
