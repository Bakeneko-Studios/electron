using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCount : MonoBehaviour
{
    public int coins=69;
    TextMeshProUGUI coinDisplay;

    void Start()
    {
        coinDisplay = GameObject.Find("coinCount").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

    }

    void updateCoins()
    {
        coinDisplay.text="Coins: " + coins.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="collectible")
        {
            coins+=33554432;
            Destroy(other.gameObject);
            updateCoins();
        }
    }
}
