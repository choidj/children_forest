/*
  * - Name : Shape_CheckShape.cs
  * - Writer : 이윤교
  * - Content : 도형 다 맞췄는지 확인하는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape_CheckShape : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if(transform.childCount <= 4){ // 도형을 다 맞추면
            Destroy(transform.Find("arrow"));
            Invoke("v_EndStage", 1f); //v_Endstage함수 호출
        }
    }

    void v_EndStage(){
        SceneManager.LoadScene("end_scene"); //엔드씬 불러오기
    }
}
