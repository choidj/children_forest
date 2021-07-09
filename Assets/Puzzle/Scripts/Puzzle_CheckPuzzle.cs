using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_CheckPuzzle : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if(transform.childCount <= 9){ // 퍼즐을 다 맞추면
            Destroy(transform.Find("arrow"));
            Invoke("v_EndStage", 1f); //v_Endstage함수 호출
        }
    }

    void v_EndStage()
    {
        SceneManager.LoadScene("end_scene"); //end씬 불러오기
    }
}
