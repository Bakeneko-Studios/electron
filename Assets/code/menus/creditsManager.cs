using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditsManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public GameObject scrollBar;
    private bool escape;

    void Awake() {
        musicPlayer.Play();
    }
    void FixedUpdate()
    {
        if (scrollBar.GetComponent<Scrollbar>().value > 0)
            scrollBar.GetComponent<Scrollbar>().value -= 0.0008f;
    }

    public void escapeButton()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
