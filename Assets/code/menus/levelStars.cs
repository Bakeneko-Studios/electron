using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelStars : MonoBehaviour
{
    public UserData UD;
    public int level;
    public int stars;
    void Awake()
    {
        UD = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>();
        stars = UD.levels[level-1,0];
        GetComponent<Image>().fillAmount = (float)stars/5;
    }
}
