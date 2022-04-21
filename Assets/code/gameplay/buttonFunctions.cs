using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    GameObject electron;
    GameObject positiveSlot;
    GameObject negativeSlot;
    gameplayManager gm;
    public GameObject load;

    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        gm = GetComponent<gameplayManager>();
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GetComponent<timer>().pauseTimer();
        Debug.Log("scene restarted");
    }

public void undo()
    {
        if(!gm.escape)
        {
            if(gm.placedCharges.Count!=0 && gm.savedPositions.Count!=0)
            {

                Destroy(gm.placedCharges.Pop());
                if (gm.infiniteCharges!=true)
                {
                    if(gm.placedCharges.Peek().GetComponent<chargepos>().chargeColomb>0)
                    {
                        positiveSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        positiveSlot.GetComponent<chargeSpawner>().updateText();
                    }
                    if(gm.placedCharges.Peek().GetComponent<chargepos>().chargeColomb<0)
                    {
                        negativeSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        negativeSlot.GetComponent<chargeSpawner>().updateText();
                    }
                }
                electron.GetComponent<Rigidbody2D>().angularVelocity = 0;
                electron.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                electron.transform.position=gm.savedPositions.Pop();
                electron.SetActive(true);
                Debug.Log("undid placement");
            }
        }
    }
    
    public void loadCheckpoint()
    {
        if (electron.GetComponent<electron>().firstCheckpoint)
        {
            electron.SetActive(true);
            electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
            electron.transform.position = electron.GetComponent<electron>().loadPoint;
            gm.start = false;
            gm.escape = false;
            
            negativeSlot.GetComponent<chargeSpawner>().numOfCharges = electron.GetComponent<electron>().negativeAmount;
            positiveSlot.GetComponent<chargeSpawner>().numOfCharges = electron.GetComponent<electron>().positiveAmount;

            negativeSlot.GetComponent<chargeSpawner>().updateText();
            positiveSlot.GetComponent<chargeSpawner>().updateText();

            GetComponent<scoring>().chargesUsed-=GetComponent<scoring>().chargesUsedSinceLoad;

            while(gm.savedPositions.Count!=0)
            {
                Destroy(gm.placedCharges.Pop());
                gm.savedPositions.Pop();
            }
            Debug.Log("checkpoint loaded");
        }
        else
        {
            restart();
        }
        load.SetActive(false);
    }

    public void resume()
    {
        gm.escape = !gm.escape;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("level select");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (!gm.infiniteCharges)
        {
            if ((!electron.activeInHierarchy || negativeSlot.GetComponent<chargeSpawner>().numOfCharges + positiveSlot.GetComponent<chargeSpawner>().numOfCharges == 0) && !gm.victory)
            {
                load.SetActive(true);
            }
        }
        else
        {
            if (!electron.activeInHierarchy && !gm.victory)
            {
                load.SetActive(true);
            }
        }
    }
}
