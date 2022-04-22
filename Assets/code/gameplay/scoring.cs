using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int chargesUsedSinceLoad = 0;
    public int chargeLimit;
    public UserData UD;
    int levelIndex;
    public Animator anim;
    public GameObject[] starDisplays;

    void Start()
    {
        timer = GetComponent<timer>();
        GameObject []coinCount=GameObject.FindGameObjectsWithTag("collectible");
        maxCoins=coinCount.Length;

        UD = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>();
        levelIndex = int.Parse((SceneManager.GetActiveScene().name).Remove(0,5))-1;
    }

    public void results()
    {
        if(stars==0 && score==0)
        {
            calculateStars();
            calculateScore();
            showResults();
            saveToData();
        }
    }

    void calculateStars()
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

    void calculateScore()
    {
        score+=stars*20000;
        score+=collectedCoins*10000;
        score-=deaths*5000;
        timeBonus=Mathf.Max(0, (int)((timeLimitSeconds-(float)timer.levelTime.Elapsed.TotalSeconds)*100));
        score+=timeBonus;
    }

    void showResults()
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

    void saveToData()
    {
        if(stars>UD.levels[levelIndex][0])
        {
            UD.levels[levelIndex][0] = stars;
        }
        if(score>UD.levels[levelIndex][1])
        {
            UD.levels[levelIndex][1] = score;
        }
    }

    IEnumerator showStars()
    {
        while(displayedStars<stars)
        {
            displayedStars+=1;
            yield return new WaitForSeconds(0.2f);
            starDisplays[displayedStars-1].SetActive(true);
            anim.SetInteger("starsDisplayed", displayedStars);
            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator showScore()
    {
        while(displayedScore<score)
        {
            yield return new WaitForSeconds(0.03f);
            displayedScore+=score/100;
            scoreCount.text = "Score: " + displayedScore.ToString();
        }
    }

    IEnumerator showBreakdown()
    {
        yield return new WaitForSeconds(0.2f);
        scoreBreakdown.text = "Star bonus (" + stars.ToString() + "): +" + (stars*20000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = "Coin bonus (" + collectedCoins.ToString() + "/" + maxCoins.ToString() + "): +" + (collectedCoins*10000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = "Death penalty (" + deaths.ToString() + "): -" + (deaths*5000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = "Time bonus: +" + timeBonus.ToString();
        yield return new WaitForSeconds(1.7f);
        scoreBreakdown.text = "High score: "+ UD.levels[levelIndex][1];
    }
}
