using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    GameObject electron;

    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.Find("electron");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("scene restarted");
    }
    public void loadCheckpoint()
    {
        electron.transform.position=electron.GetComponent<electron>().loadPoint;
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
