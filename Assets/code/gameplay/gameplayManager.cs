using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplayManager : MonoBehaviour
{
    public GameObject electron;
    public GameObject victoryPanel;
    public GameObject pausePanel;
    public GameObject escPanel;
    public Stack<GameObject> placedCharges = new Stack<GameObject>();
    public Stack<Vector3> savedPositions = new Stack<Vector3>();

    public bool start;
    public bool infiniteCharges = false;

    public GameObject[] hideOnEsc;
    public bool escape;

    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("player");
    }

    public void win()
    {
        victoryPanel.SetActive(true);
    }

    public void startPhysics()
    {
        //GameObject[] efield = GameObject.FindGameObjectsWithTag("efield");
        //foreach (GameObject e in efield)
        //{
        //    e.GetComponent<repulsion>().startPhysics();
        //}
        electron.GetComponent<repulsion>().startPhysics();
    }

    public void stopPhysics()
    {
        electron.GetComponent<repulsion>().stopPhysics();
    }

    // Update is called once per frame
    void Update()
    {
        esc();

        if (!escape)
        {
            pause();
            god();
        }
    }

    void pause() 
    {
        if(Input.GetButtonDown("Jump")) 
        {
            start = !start;
        }

        if (start == true)
        {
            electron.GetComponent<repulsion>().startPhysics();
            pausePanel.SetActive(false);
        }

        else
        {
            electron.GetComponent<repulsion>().stopPhysics();
            pausePanel.SetActive(true);
        }
    }

    void god() 
    {
        if(Input.GetKeyDown("g")) 
        {
            infiniteCharges = true;
        }
    }

    void esc() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            escape = !escape;
        }

        if (escape)
        {
            escPanel.gameObject.SetActive(true);
            electron.GetComponent<repulsion>().stopPhysics();
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(false);
            }
        }

        else
        {
            escPanel.gameObject.SetActive(false);
            electron.GetComponent<repulsion>().startPhysics();
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(true);
            }
        }
    }
}
