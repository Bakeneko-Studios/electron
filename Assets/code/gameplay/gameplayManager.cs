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

    GameObject positiveSlot;
    GameObject negativeSlot;
    public GameObject[] hideOnEsc;
    public UserData data;
    public scoring scoring;

    int nextSceneLoad;

    public AudioSource moosicPlayer;

    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
        scoring = GetComponent<scoring>();
        moosicPlayer = GameObject.FindGameObjectWithTag("moosic").GetComponent<AudioSource>();
        moosicPlayer.Play();
        if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.Pause();
            }

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex;
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
        
        if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.UnPause();
            }
        scoring.results();

        if(SceneManager.GetActiveScene().buildIndex == 20) 
        {
            Debug.Log("finished");
        }
        else
        {
            if (nextSceneLoad > GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel + 2) 
            {
                GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().unlockedLevel = nextSceneLoad - 2;
            }
        }

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
            esc();
            god();
            if(!escape)
            {
                pause();
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
    }

    void pause() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && victory == false) 
        {
            start = !start;
        }

        if (start == true)
        {
            electron.GetComponent<repulsion>().startPhysics();
            GetComponent<timer>().unpauseTimer();
            if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.UnPause();
            }
            pausePanel.SetActive(false);
        }

        else
        {
            electron.GetComponent<repulsion>().stopPhysics();
            GetComponent<timer>().pauseTimer();
            if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.Pause();
            }
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

    public void escapeButton()
    {
        if (!victory)
            escape = !escape;
    }

    void esc() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !victory) 
        {
            escape = !escape;
        }

        if (escape)
        {
            start=false;
            escPanel.gameObject.SetActive(true);
            electron.GetComponent<repulsion>().stopPhysics();
            GetComponent<timer>().pauseTimer();
            if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.Pause();
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
            if(moosicPlayer.clip.name!="never gonna give you up.mp3")
            {
                moosicPlayer.UnPause();
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
