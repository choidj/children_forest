using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape_CheckShape : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if(transform.childCount <= 4){
            Destroy(transform.Find("arrow"));
            Invoke("v_EndStage", 1f);
        }
    }

    void v_EndStage(){
        SceneManager.LoadScene("end_scene");
    }
}
