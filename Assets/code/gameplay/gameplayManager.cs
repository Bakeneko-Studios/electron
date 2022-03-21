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


    // Start is called before the first frame update
    void Start()
    {
        electron = GameObject.FindGameObjectWithTag("Player");
        positiveSlot = GameObject.FindGameObjectWithTag("positive slot");
        negativeSlot = GameObject.FindGameObjectWithTag("negative slot");
    }

    public void win()
    {
        victoryPanel.SetActive(true);
        electron.GetComponent<repulsion>().stopPhysics();
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
            undo();
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

    void undo()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.Z))
        {
            if(placedCharges.Count!=0 && savedPositions.Count!=0)
            {
                if(infiniteCharges!=true)
                {
                    if(placedCharges.Peek().GetComponent<chargepos>().chargeColomb>0)
                    {
                        positiveSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        positiveSlot.GetComponent<chargeSpawner>().updateText();
                    }
                    if(placedCharges.Peek().GetComponent<chargepos>().chargeColomb<0)
                    {
                        negativeSlot.GetComponent<chargeSpawner>().numOfCharges++;
                        negativeSlot.GetComponent<chargeSpawner>().updateText();
                    }
                }
                Destroy(placedCharges.Pop());
                electron.SetActive(true);
                electron.GetComponent<Rigidbody2D>().velocity.Set(0,0);
                electron.transform.position = savedPositions.Pop();
                Debug.Log("undid placement");
            }
        }
    }
}
