using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class electron : MonoBehaviour
{
    public gameplayManager gm;
    public Vector3 loadPoint;
    public int negativeAmount;
    public int positiveAmount;
    public Rigidbody2D rib;
    public Vector3 velocity;
    public float speedMultiplier;
    TextMeshProUGUI negativeText;
    TextMeshProUGUI positiveText;

    //sounds
    public AudioSource soundPlayer;
    public AudioClip collisionFX;
    public AudioClip deathFX;
    public AudioClip teleportFX;
    public AudioClip fakewallFX;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("game manager").GetComponent<gameplayManager>();
        loadPoint=this.transform.position;

        rib=GetComponent<Rigidbody2D>();
        soundPlayer = GetComponent<AudioSource>();

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
        if(!gm.escape && gm.start)
        {
            if (collision.collider.name == "Finish")
            {
                gm.win();
            }
            else if(collision.collider.CompareTag("bouncy boi"))
            {
                var speed = velocity.magnitude;
                var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
                rib.velocity = direction*Mathf.Max(speed*speedMultiplier,0f);
            }
            else if(collision.gameObject.tag=="insulator")
            {
                return;
            }
            else if(collision.gameObject.tag=="fake wall")
            {
                soundPlayer.PlayOneShot(fakewallFX);
            }
            else if(collision.gameObject.tag=="portal")
            {
                soundPlayer.PlayOneShot(teleportFX);
            }
            else
            {
                soundPlayer.PlayOneShot(collisionFX);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="checkpoint" && other.gameObject.transform.position!=loadPoint)
        {
            gm.resetSaves();
            loadPoint = other.gameObject.transform.position;
            
            saveAmount();
        }
        if(other.gameObject.tag=="fake wall")
        {
            soundPlayer.PlayOneShot(fakewallFX);
        }
    }

    void saveAmount()
    {
        if(!gm.infiniteCharges)
        {
            negativeAmount = int.Parse(negativeText.text);
            positiveAmount = int.Parse(positiveText.text);
        }
    }
}
