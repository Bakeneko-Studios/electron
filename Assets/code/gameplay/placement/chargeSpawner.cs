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
    public gameplayManager gm;
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
        if(numOfCharges>0 || gm.infiniteCharges)
        {
            GameObject spawnedCharge = Instantiate(spawningCharge);
            spawnedCharge.transform.position = position;
            gm.placedCharges.Push(spawnedCharge);
            gm.savedPositions.Push(gm.electron.transform.position);

            electricField.GetComponent<electricFieldLines>().updateCharges();
            if (!gm.infiniteCharges) {
                numOfCharges--;
                updateText();
            }
            gm.GetComponent<scoring>().chargesUsed+=1;
            gm.GetComponent<scoring>().chargesUsedSinceLoad+=1;
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
        gm = GameObject.FindGameObjectWithTag("game manager").GetComponent<gameplayManager>();
        unselected = this.GetComponent<Image>().color;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.infiniteCharges)
            text.text = "∞";
    }
}
