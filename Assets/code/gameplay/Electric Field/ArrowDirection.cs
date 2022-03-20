using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
