using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject electron;

    GameObject positiveSlot;
    GameObject negativeSlot;

    // Start is called before the first frame update
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

    public void loadCheckpoint()
    {
        electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
        electron.transform.position = electron.GetComponent<electron>().loadPoint;
        GetComponent<gameplayManager>().start = false;
        GetComponent<gameplayManager>().escape = false;

        negativeSlot.GetComponent<chargeSpawner>().numOfCharges = electron.GetComponent<electron>().negativeAmount;
        positiveSlot.GetComponent<chargeSpawner>().numOfCharges = electron.GetComponent<electron>().positiveAmount;

        negativeSlot.GetComponent<chargeSpawner>().updateText();
        positiveSlot.GetComponent<chargeSpawner>().updateText();

        while(GetComponent<gameplayManager>().placedCharges.Count!=0)
        {
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
