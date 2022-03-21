using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCount : MonoBehaviour
{
    public int coins=0;
    TextMeshProUGUI coinDisplay;
    // Start is called before the first frame update
    void Start()
    {
        coinDisplay = GameObject.Find("coinCount").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.text="Coins: " + coins.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="collectible")
        {
            coins+=1;
            Destroy(other.gameObject);
        }
    }
}
