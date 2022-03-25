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
    public bool escape;

    GameObject positiveSlot;
    GameObject negativeSlot;
    public GameObject[] hideOnEsc;
    public AudioSource lofi;


    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
        if(lofi!=null)
        {
            lofi.Play();
        }
    }

    public void win()
    {
        victoryPanel.SetActive(true);
        electron.GetComponent<repulsion>().stopPhysics();
        GetComponent<timer>().enabled=false;
        for (int i = 0; i < hideOnEsc.Length; i++)
        {
            hideOnEsc[i].SetActive(false);
        }
    }

    public void resetSaves()
    {
        placedCharges = new Stack<GameObject>();
        savedPositions = new Stack<Vector3>();
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

        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                GetComponent<buttonFunctions>().undo();
            }
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
            GetComponent<timer>().unpauseTimer();
            pausePanel.SetActive(false);
        }

        else
        {
            electron.GetComponent<repulsion>().stopPhysics();
            GetComponent<timer>().pauseTimer();
            pausePanel.SetActive(true);
        }
    }

    void god() 
    {
        if(Input.GetKeyDown("g")) 
        {
            GetComponent<gameplayManager>().infiniteCharges = true;
        }
    }

    void esc() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GetComponent<gameplayManager>().escape = !GetComponent<gameplayManager>().escape;
        }

        if (escape)
        {
            escPanel.gameObject.SetActive(true);
            electron.GetComponent<repulsion>().stopPhysics();
            GetComponent<timer>().pauseTimer();
            if(lofi!=null)
            {
                lofi.Pause();
            }
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(false);
            }
        }

        else
        {
            escPanel.gameObject.SetActive(false);
            electron.GetComponent<repulsion>().startPhysics();
            GetComponent<timer>().unpauseTimer();
            if(lofi!=null)
            {
                lofi.UnPause();
            }
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(true);
            }
        }
    }
}
