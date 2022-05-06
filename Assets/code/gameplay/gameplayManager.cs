using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool victory = false;

    public GameObject positiveSlot;
    public GameObject negativeSlot;
    public GameObject[] hideOnEsc;
    public UserData data;
    public scoring scoring;

    int nextSceneLoad;

    public AudioSource moosicPlayer;
    public AudioClip pauseSound;

    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
        scoring = GetComponent<scoring>();
        moosicPlayer = GameObject.FindGameObjectWithTag("moosic").GetComponent<AudioSource>();
        moosicPlayer.Play();
        if(SceneManager.GetActiveScene().name!="level21")
            {
                moosicPlayer.Pause();
            }

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex;
        electron.GetComponent<electron>().saveAmount();
    }

    public void win()
    {
        victory = true;
        victoryPanel.SetActive(true);
        electron.GetComponent<repulsion>().stopPhysics();
        GetComponent<timer>().enabled=false;
        for (int i = 0; i < hideOnEsc.Length; i++)
        {
            hideOnEsc[i].SetActive(false);
        }
        GameObject.Find("chargeSlots").SetActive(false);

        if(SceneManager.GetActiveScene().name!="level21")
            {
                moosicPlayer.Pause();
            }
        scoring.results();


        if (nextSceneLoad > GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel + 1) 
        {
            GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel = nextSceneLoad - 1;
        }

        SavingSystem.SaveUser(GameObject.Find("UserData").GetComponent<UserData>());

        electron.SetActive(false);
    }

    public void resetSaves()
    {
        placedCharges = new Stack<GameObject>();
        savedPositions = new Stack<Vector3>();
    }

    void Update()
    {
        if(electron.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Space) && victory == false && !escape) 
            {
                start = !start;
                pause();
            }
            if (Input.GetKeyDown(KeyCode.Escape) && !victory) 
            {
                escape = !escape;
                esc();
            }
            if(Input.GetKeyDown("g")) 
            {
                infiniteCharges = true;
            }

        }
        
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                GetComponent<buttonFunctions>().undo();
            }
        }
    }
    public void pauseButton()
    {
        start = !start;
        pause();
    }

    public void pause()
    {
        if (start == true)
        {
            electron.GetComponent<repulsion>().startPhysics();
            GetComponent<timer>().unpauseTimer();
            if(SceneManager.GetActiveScene().name!="level21")
            {
                moosicPlayer.UnPause();
            }
            pausePanel.SetActive(false);
            electron.GetComponent<AudioSource>().PlayOneShot(pauseSound);
        }

        else
        {
            electron.GetComponent<repulsion>().stopPhysics();
            GetComponent<timer>().pauseTimer();
            if(SceneManager.GetActiveScene().name!="level21")
            {
                moosicPlayer.Pause();
            }
            pausePanel.SetActive(true);
            electron.GetComponent<AudioSource>().PlayOneShot(pauseSound);
        }
    }

    public void escapeButton()
    {
        if (!victory)
        {
            escape = !escape;
            esc();
        }
    }

    public void esc()
    {
        if (escape)
        {
            start=false;
            pause();
            escPanel.gameObject.SetActive(true);
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(false);
            }
        }

        else
        {
            escPanel.gameObject.SetActive(false);
            for (int i = 0; i < hideOnEsc.Length; i++)
            {
                hideOnEsc[i].SetActive(true);
            }
        }
    }
}
