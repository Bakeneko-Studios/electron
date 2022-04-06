using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoring : MonoBehaviour
{
    public int stars = 0;
    public int score = 0;
    public TextMeshProUGUI starCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI scoreBreakdown;
    public int displayedStars = 0;
    public int displayedScore = 0;
    public int collectedCoins = 0;
    public int maxCoins = 0;
    public int deaths = 0;
    public timer timer;
    public int timeLimitSeconds;
    public int timeBonus;
    public int chargesUsed = 0;
    public int chargeLimit;
    void Start()
    {
        timer = GetComponent<timer>();
        GameObject []coinCount=GameObject.FindGameObjectsWithTag("collectible");
        maxCoins=coinCount.Length;
    }

    void Update()
    {
        
    }

    public void results()
    {
        if(stars==0 && score==0)
        {
            calculateStars();
            calculateScore();
            showResults();
        }
    }

    public void calculateStars()
    {
        stars+=1;
        if(collectedCoins==maxCoins)
        {
            stars+=1;
        }
        if(deaths==0)
        {
            stars+=1;
        }
        if((int)timer.levelTime.Elapsed.TotalSeconds<=timeLimitSeconds)
        {
            stars+=1;
        }
        if(chargesUsed<=chargeLimit)
        {
            stars+=1;
        }
    }

    public void calculateScore()
    {
        score+=stars*20000;
        score+=collectedCoins*10000;
        score-=deaths*5000;
        timeBonus=Mathf.Max(0, (int)((timeLimitSeconds-(float)timer.levelTime.Elapsed.TotalSeconds)*100));
        score+=timeBonus;
    }

    public void showResults()
    {
        Debug.Log("coins collected: " + collectedCoins.ToString() + "/" + maxCoins.ToString());
        Debug.Log("deaths: " + deaths.ToString());
        Debug.Log("time: " + timer.levelTime.Elapsed.TotalSeconds.ToString() + "/" + timeLimitSeconds.ToString());
        Debug.Log("charges used: " + chargesUsed.ToString() + "/" + chargeLimit.ToString());
        Debug.Log("time bonus: " + timeBonus.ToString());
        StartCoroutine(showStars());
        StartCoroutine(showScore());
        StartCoroutine(showBreakdown());
    }

    IEnumerator showStars()
    {
        while(displayedStars<stars)
        {
            yield return new WaitForSeconds(0.3f);
            displayedStars+=1;
            starCount.text = "Stars: " + displayedStars.ToString();
        }
    }

    IEnumerator showScore()
    {
        while(displayedScore<score)
        {
            yield return new WaitForSeconds(0.005f);
            displayedScore+=score/100;
            scoreCount.text = "Score: " + displayedScore.ToString();
        }
    }

    IEnumerator showBreakdown()
    {
        yield return new WaitForSeconds(0.8f);
        scoreBreakdown.text = "Star bonus: +" + (stars*20000).ToString();
        yield return new WaitForSeconds(0.8f);
        scoreBreakdown.text = "Coin bonus: +" + (collectedCoins*10000).ToString();
        yield return new WaitForSeconds(0.8f);
        scoreBreakdown.text = "Death penalty: -" + (deaths*5000).ToString();
        yield return new WaitForSeconds(0.8f);
        scoreBreakdown.text = "Time bonus: +" + timeBonus.ToString();
        yield return new WaitForSeconds(0.8f);
        scoreBreakdown.gameObject.SetActive(false);
    }
}
