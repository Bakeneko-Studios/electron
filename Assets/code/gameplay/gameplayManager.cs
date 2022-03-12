using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplayManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject electron;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
