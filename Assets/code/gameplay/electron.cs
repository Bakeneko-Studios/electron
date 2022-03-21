using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class electron : MonoBehaviour
{
    public GameObject gameManager;
    public Vector3 loadPoint;
    public int negativeAmount;
    public int positiveAmount;

    TextMeshProUGUI negativeText;
    TextMeshProUGUI positiveText;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("game manager");
        loadPoint=this.transform.position;

        negativeText = GameObject.Find("chargeSlots/negative/Text (TMP)").GetComponent<TextMeshProUGUI>();
        positiveText = GameObject.Find("chargeSlots/positive/Text (TMP)").GetComponent<TextMeshProUGUI>();

        saveAmount();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Finish")
        {
            gameManager.GetComponent<gameplayManager>().win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="checkpoint" && other.gameObject.transform.position!=loadPoint)
        {
            gameManager.GetComponent<gameplayManager>().resetSaves();
            loadPoint = other.gameObject.transform.position;

            saveAmount();
        }
    }

    void saveAmount()
    {
        if(!gameManager.GetComponent<gameplayManager>().escape)
        {
            negativeAmount = int.Parse(negativeText.text);
            positiveAmount = int.Parse(positiveText.text);
        }

    }
}
