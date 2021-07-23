/*
  * - Name : Puzzle_CheckPuzzle.cs
  * - Writer : 이윤교
  * - Content : 퍼즐을 다 맞췄는지 확인하고 다음 씬 불러오는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  * 
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_CheckPuzzle : MonoBehaviour {
    VoiceManager vm;
    bool mb_checkVoice = true;
    void Start(){
        vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update(){
        if(transform.childCount <= 9){ // 퍼즐을 다 맞추면
            if(mb_checkVoice){
                vm.playVoice(0);
                mb_checkVoice = false;
            }
            Destroy(transform.Find("arrow"));
            Invoke("v_EndStage", 2f); //v_Endstage함수 호출
        }
    }

    void v_EndStage() {
        SceneManager.LoadScene("end_scene"); //end씬 불러오기
    }
}
