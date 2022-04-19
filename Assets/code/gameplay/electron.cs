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
    public bool firstCheckpoint = false;
    public Rigidbody2D rib;
    public Vector3 velocity;
    public float speedMultiplier;
    TextMeshProUGUI negativeText;
    TextMeshProUGUI positiveText;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("game manager");
        loadPoint=this.transform.position;

        rib=GetComponent<Rigidbody2D>();

        negativeText = GameObject.Find("chargeSlots/negative/Text (TMP)").GetComponent<TextMeshProUGUI>();
        positiveText = GameObject.Find("chargeSlots/positive/Text (TMP)").GetComponent<TextMeshProUGUI>();

        saveAmount();
    }

    void Update()
    {
        velocity = rib.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        this.GetComponent<AudioSource>().Play();
        if (collision.collider.name == "Finish")
        {
            gameManager.GetComponent<gameplayManager>().win();
        }
        if(collision.collider.CompareTag("bouncy boi"))
        {
            var speed = velocity.magnitude;
            var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            rib.velocity = direction*Mathf.Max(speed*speedMultiplier,0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="checkpoint" && other.gameObject.transform.position!=loadPoint)
        {
            gameManager.GetComponent<gameplayManager>().resetSaves();
            loadPoint = other.gameObject.transform.position;
            firstCheckpoint = true;
            
            saveAmount();
        }
    }

    void saveAmount()
    {
        if(!gameManager.GetComponent<gameplayManager>().infiniteCharges)
        {
            negativeAmount = int.Parse(negativeText.text);
            positiveAmount = int.Parse(positiveText.text);
        }
    }
}
