using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckShape : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if(transform.childCount <= 4){
            Destroy(transform.Find("arrow"));
            Invoke("endStage", 1f);
        }
    }

    void endStage(){
        SceneManager.LoadScene("end_scene");
    }
}
