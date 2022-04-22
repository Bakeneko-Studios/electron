using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCount : MonoBehaviour
{
    public int coins=69;
    //TextMeshProUGUI coinDisplay;
    public GameObject userData;
    public scoring scoring;

    public GameObject collectRelease;

    void Start()
    {
        //coinDisplay = GameObject.Find("coinCount").GetComponent<TextMeshProUGUI>();
        userData = GameObject.FindGameObjectWithTag("user data");
        scoring = GameObject.FindGameObjectWithTag("game manager").GetComponent<scoring>();
    }

    void Update()
    {

    }

    void updateCoins()
    {
        //coinDisplay.text="Coins: " + coins.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="collectible")
        {
            coins+=33554432;
            scoring.collectedCoins+=1;
            Instantiate(collectRelease, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            updateCoins();
        }
    }
}
