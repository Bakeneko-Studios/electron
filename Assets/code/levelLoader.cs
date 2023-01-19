using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transitionType;
    public float transitionTime=1f;

    //USE THIS
    //public GameObject levelLoader;
    //levelLoader.GetComponent<levelLoader>().callLevelLoader

    // Update is called once per frame
    public void callLevelLoader(int levelIndex)
    {
        StartCoroutine(loadLevel(levelIndex));
    }

    IEnumerator loadLevel(int levelIndex)
    {
    transitionType.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);
    }
}
