using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 9)
        {
            Destroy(transform.Find("arrow"));
            Invoke("endStage", 1f);
        }
    }

    void endStage()
    {
        SceneManager.LoadScene("end_scene");
    }
}
