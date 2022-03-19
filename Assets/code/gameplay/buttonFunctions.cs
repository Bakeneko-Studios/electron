using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject electron;
    public Transform loadPoint;
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadCheckpoint()
    {
        electron.transform.position = loadPoint.position;
    }

    public void resume()
    {
        GetComponent<gameplayManager>().escape = !GetComponent<gameplayManager>().escape;
    }

    public void mainMenu()
    {
        //SceneManager.LoadScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
