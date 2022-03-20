using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject electron;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("player");
        manager = GameObject.FindGameObjectWithTag("game manager");
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
        manager.GetComponent<gameplayManager>().start = false;
        manager.GetComponent<gameplayManager>().escape = false;
        Debug.Log("checkpoint loaded");
    }

    public void undo()
    {
        if(manager.GetComponent<gameplayManager>().placedCharges.Count!=0 && manager.GetComponent<gameplayManager>().savedPositions.Count!=0)
        {
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

    void Update()
    {
        
    }
}
