/*
  * - Name : Shape_Matching_Shape.cs
  * - Writer : 이윤교
  * - Content : 게임 성공 시 나타나는 씬, select스테이지 씬과 연결해줌
  * 
  *            -작성 기록-
  *            2021-07-22 : 제작 완료 및 주석처리 완료
  *            2021-07-22 : 주석처리 완료
  *            
  *
  *
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_controlStage : MonoBehaviour
{
    void Start() {
        Invoke("v_changeSelectStage", 4f);
    }

    void v_changeSelectStage() {
        SceneManager.LoadScene("select_stage_scene");
    }
}
