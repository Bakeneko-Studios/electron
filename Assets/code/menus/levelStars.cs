using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelStars : MonoBehaviour
{
    public int level;
    public int stars;
    void Awake()
    {
        stars = UserData.levels[level-1,0];
        GetComponent<Image>().fillAmount = (float)stars/5;
    }
}
