using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;

public class timer : MonoBehaviour
{
    public Stopwatch levelTime = new Stopwatch();
    public string seconds="00";
    public string minutes="0";
    public TextMeshProUGUI timerDisplay;
    public bool timerActive=false;
    public bool showTimer;

    void Awake()
    {
        showTimer =  UserData.showtimer;
    }

    void Start()
    {
        timerActive=false;
        timerDisplay.gameObject.SetActive(showTimer);
    }

    void Update()
    {
        if(!timerActive && levelTime.IsRunning)
        {
            levelTime.Stop();
        }
        if(timerActive && !levelTime.IsRunning)
        {
            levelTime.Start();
        }
        if(timerActive)
        {
            minutes=levelTime.Elapsed.Minutes.ToString();
            if(levelTime.Elapsed.Seconds<10)
            {
                seconds="0"+levelTime.Elapsed.Seconds.ToString();
            }
            else
            {
                seconds=levelTime.Elapsed.Seconds.ToString();
            }
            timerDisplay.text=minutes.ToString() + " : " + seconds.ToString();
        }
    }

    public void pauseTimer()
    {
        timerActive=false;
    }
    public void unpauseTimer()
    {
        timerActive=true;
    }
    public void resetTimer()
    {
        levelTime.Stop();
        levelTime.Reset();
    }
}
