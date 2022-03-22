using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject electron;
    public GameObject positiveSlot;
    public GameObject negativeSlot;

    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");

        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("scene restarted");
    }

public void undo()
    {
        if(!GetComponent<gameplayManager>().escape)
        {
            if(GetComponent<gameplayManager>().placedCharges.Count!=0 && GetComponent<gameplayManager>().savedPositions.Count!=0)
            {
                if(GetComponent<gameplayManager>().infiniteCharges!=true)
                {
                    if(GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb>0)
                    {
                        positiveSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        positiveSlot.GetComponent<chargeSpawner>().updateText();
                    }
                    if(GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb<0)
                    {
                        negativeSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        negativeSlot.GetComponent<chargeSpawner>().updateText();
                    }
                }
                Destroy(GetComponent<gameplayManager>().placedCharges.Pop());
                electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
                electron.transform.position=GetComponent<gameplayManager>().savedPositions.Pop();
                Debug.Log("undid placement");
            }
        }
    }
    
    public void loadCheckpoint()
    {
        electron.SetActive(true);
        electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
        electron.transform.position = electron.GetComponent<electron>().loadPoint;
        GetComponent<gameplayManager>().start = false;
        GetComponent<gameplayManager>().escape = false;

        while(GetComponent<gameplayManager>().placedCharges.Count!=0)
        {
            if(GetComponent<gameplayManager>().infiniteCharges!=true)
                {
                    if(GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb>0)
                    {
                        positiveSlot.GetComponent<chargeSpawner>().numOfCharges++;
                    }
                    if(GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb<0)
                    {
                        negativeSlot.GetComponent<chargeSpawner>().numOfCharges++;
                    }
                }
            positiveSlot.GetComponent<chargeSpawner>().updateText();
            negativeSlot.GetComponent<chargeSpawner>().updateText();
            Destroy(GetComponent<gameplayManager>().placedCharges.Pop());
        }
        while(GetComponent<gameplayManager>().savedPositions.Count!=0)
        {
            GetComponent<gameplayManager>().savedPositions.Pop();
        }
        Debug.Log("checkpoint loaded");
    }

    public void resume()
    {
        GetComponent<gameplayManager>().escape = !GetComponent<gameplayManager>().escape;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        
    }
}
