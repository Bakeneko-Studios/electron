using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;

public class timer : MonoBehaviour
{
    public Stopwatch levelTime = new Stopwatch();
    public int milliseconds=0;
    public int seconds=0;
    public int minutes=0;
    public TextMeshProUGUI timerDisplay;
    public bool timerActive=false;
    public bool showTimer;

    void Start()
    {
        timerActive=false;
        if(showTimer==true)
        {
            timerDisplay.gameObject.SetActive(true);
        }
        if(showTimer==false)
        {
            timerDisplay.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(timerActive==false && levelTime.IsRunning==true)
        {
            levelTime.Stop();
        }
        if(timerActive==true && levelTime.IsRunning==false)
        {
            levelTime.Start();
        }
        if(timerActive==true)
        {
            minutes=levelTime.Elapsed.Minutes;
            seconds=levelTime.Elapsed.Seconds;
            milliseconds=levelTime.Elapsed.Milliseconds;
            timerDisplay.text=minutes.ToString() + " : " + seconds.ToString() + " : " + milliseconds.ToString();
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
