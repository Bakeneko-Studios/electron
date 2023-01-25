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
    public float displayedScore = 0;
    public int collectedCoins = 0;
    public int maxCoins = 0;
    public int deaths = 0;
    public timer timer;
    public int timeLimitSeconds;
    public int timeBonus;
    public int chargesUsed = 0;
    public int chargesUsedSinceLoad = 0;
    public int chargeLimit;
    int levelIndex;
    public Animator anim;
    public GameObject[] starDisplays;

    string scorestr;
    string starstr;
    string coinstr;
    string deathsstr;
    string timestr;
    string highScorestr;
    //Aduio
    public AudioSource soundPlayer;
    public AudioClip starsBuildup;

    void Start()
    {
        timer = GetComponent<timer>();
        GameObject[] coinCount=GameObject.FindGameObjectsWithTag("collectible");
        maxCoins=coinCount.Length;

        findLanguage();
        try {levelIndex = int.Parse((SceneManager.GetActiveScene().name).Remove(0,5))-1;}
        catch{};
    }

    public void results()
    {
        if(stars==0 && score==0)
        {
            calculate();
            showResults();
        }
    }

    void calculate()
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
        
        score+=stars*20000;
        score+=collectedCoins*10000;
        score-=deaths*5000;
        timeBonus=Mathf.Max(0, (int)((timeLimitSeconds-(float)timer.levelTime.Elapsed.TotalSeconds)*1000));
        score+=timeBonus;

        if(stars>UserData.levels[levelIndex,0])
        {
            UserData.levels[levelIndex,0] = stars;
        }
        if(score>UserData.levels[levelIndex,1])
        {
            UserData.levels[levelIndex,1] = score;
        }
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

    IEnumerator showStars()
    {
        while(displayedStars<stars)
        {
            displayedStars+=1;
            yield return new WaitForSeconds(0.2f);
            starDisplays[displayedStars-1].SetActive(true);
            soundPlayer.PlayOneShot(starsBuildup);
            anim.SetInteger("starsDisplayed", displayedStars);
            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator showScore()
    {
        while(displayedScore<score)
        {
            yield return new WaitForSeconds(0.03f);
            displayedScore+=((float)score)/100;
            scoreCount.text = scorestr + ((int)displayedScore).ToString();
        }
    }

    IEnumerator showBreakdown()
    {
        yield return new WaitForSeconds(0.2f);
        scoreBreakdown.text = starstr + stars.ToString() + "): +" + (stars*20000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = coinstr + collectedCoins.ToString() + "/" + maxCoins.ToString() + "): +" + (collectedCoins*10000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = deathsstr + deaths.ToString() + "): -" + (deaths*5000).ToString();
        yield return new WaitForSeconds(0.7f);
        scoreBreakdown.text = timestr + timeBonus.ToString();
        yield return new WaitForSeconds(1.7f);
        scoreBreakdown.text = highScorestr + UserData.levels[levelIndex,1];
    }

    void findLanguage() 
    {
        if (UserData.language == 2) {
            scorestr = "成绩: ";
            starstr = "星加成 (";
            coinstr = "硬币加成 (";
            deathsstr = "死亡扣分 (";
            timestr = "时间加成: +";
            highScorestr = "最高分: ";
        }
        else {
            scorestr = "Score: ";
            starstr = "Star bonus (";
            coinstr = "Coin bonus (";
            deathsstr = "Death penalty (";
            timestr = "Time bonus: +";
            highScorestr = "High score: ";
        }


    }
}
