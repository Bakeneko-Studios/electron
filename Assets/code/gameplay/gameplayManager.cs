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
    bool victory = false;

    GameObject positiveSlot;
    GameObject negativeSlot;
    public GameObject[] hideOnEsc;
    public AudioSource lofi;
    public UserData data;
    public scoring scoring;

    public int nextSceneLoad;
    int unlockedLevel;

    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
        scoring = GetComponent<scoring>();
        if(lofi!=null)
        {
            lofi.Play();
        }

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        //unlockedLevel = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel;
    }

    public void win()
    {
        victory = true;
        victoryPanel.SetActive(true);
        electron.GetComponent<repulsion>().stopPhysics();
        GetComponent<timer>().enabled=false;
        if(lofi!=null)
        {
            lofi.Pause();
        }
        for (int i = 0; i < hideOnEsc.Length; i++)
        {
            hideOnEsc[i].SetActive(false);
        }

        scoring.results();

        if(SceneManager.GetActiveScene().buildIndex == 11) 
        {
            Debug.Log("World 1 finished");
        } else {
            if (nextSceneLoad > unlockedLevel) 
            {
                GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel = nextSceneLoad - 2;
            }
        }
    }

    public void resetSaves()
    {
        placedCharges = new Stack<GameObject>();
        savedPositions = new Stack<Vector3>();
    }

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
        if(Input.GetButtonDown("Jump") && victory == false) 
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
        if (Input.GetKeyDown(KeyCode.Escape) && victory == false) 
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

    void Awake()
    {
        //data = GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>();
        if(data!=null)
        {
        if(GameObject.Find("Coins")!=null)
        {
            //if(data.coin0==true)
            //{
            //    GameObject.Find("Coin (0)").SetActive(false);
            //}
            //if(data.coin1==true)
            //{
            //    GameObject.Find("Coin (1)").SetActive(false);
            //}
            //if(data.coin2==true)
            //{
            //    GameObject.Find("Coin (2)").SetActive(false);
            //}
            //if(data.coin3==true)
            //{
            //    GameObject.Find("Coin (3)").SetActive(false);
            //}
            //if(data.coin4==true)
            //{
            //    GameObject.Find("Coin (4)").SetActive(false);
            //}
        }
        }
    }
}
