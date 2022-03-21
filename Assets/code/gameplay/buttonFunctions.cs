using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject electron;
    public GameObject manager;
    public GameObject positiveSlot;
    public GameObject negativeSlot;

    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("game manager");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("scene restarted");
    }
    public void loadCheckpoint()
    {
        electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
        electron.transform.position=electron.GetComponent<electron>().loadPoint;
        GetComponent<gameplayManager>().start = false;
        GetComponent<gameplayManager>().escape = false;
        while(manager.GetComponent<gameplayManager>().placedCharges.Count!=0)
        {
            Destroy(manager.GetComponent<gameplayManager>().placedCharges.Pop());
        }
        while(manager.GetComponent<gameplayManager>().savedPositions.Count!=0)
        {
            manager.GetComponent<gameplayManager>().savedPositions.Pop();
        }
        Debug.Log("checkpoint loaded");
    }

    public void undo()
    {
        if(manager.GetComponent<gameplayManager>().placedCharges.Count!=0 && manager.GetComponent<gameplayManager>().savedPositions.Count!=0)
        {
            if(manager.GetComponent<gameplayManager>().infiniteCharges!=true)
            {
                if(manager.GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb>0)
                {
                    positiveSlot.GetComponent<chargeSpawner>().numOfCharges++;
                    positiveSlot.GetComponent<chargeSpawner>().updateText();
                }
                if(manager.GetComponent<gameplayManager>().placedCharges.Peek().GetComponent<chargepos>().chargeColomb<0)
                {
                    negativeSlot.GetComponent<chargeSpawner>().numOfCharges++;
                    negativeSlot.GetComponent<chargeSpawner>().updateText();
                }
            }
            Destroy(manager.GetComponent<gameplayManager>().placedCharges.Pop());
            electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
            electron.transform.position=manager.GetComponent<gameplayManager>().savedPositions.Pop();
            Debug.Log("undid placement");
        }
    }

    public void resume()
    {
        GetComponent<gameplayManager>().escape = !GetComponent<gameplayManager>().escape;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
