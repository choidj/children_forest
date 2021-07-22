/*
  * - Name : MoveMom.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드14 - 엄마 이동 스크립트
  * 
  *            -작성 기록-
  *            2021-07-15 : 제작 완료
  *
  * MoveTowards() : 등속 이동, 매개변수로 {현재위치, 목표위치, 속도}를 입력  
  * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMom : MonoBehaviour
{
    GameObject mg_Ax, mg_Jack, mg_Mom; //게임 오브젝트 도끼 잭 엄마 선언
    Vector3 v3_MomPos; //엄마위치저장

    float mf_timer; //현재위치
    float mf_waitingTime; //원하는 시간
    bool mb_checkPlayOnce = true;
    VoiceManager vm;
    void Start() {
        mf_timer = 0.0f;
        mf_waitingTime = 2f; //2초뒤
        
        mg_Ax = GameObject.Find("Ax"); //Ax 게임 오브젝트를 mg_Ax 변수에 저장
        mg_Jack = GameObject.Find("Jack");//Jack 게임 오브젝트를 mg_Jack 변수에 저장
        mg_Mom = GameObject.Find("Mom");//Mom 게임 오브젝트를 mg_Mom 변수에 저장
        v3_MomPos = new Vector3(-3,-1.14f,0); //v3_MomPos에 엄마위치저장

        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update()
    {
        /*2초뒤 엄마 등장*/
        if(vm.mb_checkSceneReady) {
            mf_timer += Time.deltaTime;
            if (mf_timer > mf_waitingTime){
                mg_Mom.transform.position = Vector3.MoveTowards(mg_Mom.transform.position, v3_MomPos, 2f * Time.deltaTime);
            }
            if(mb_checkPlayOnce) {
                vm.playVoice(0);
                mb_checkPlayOnce = false;
            }
        }
        
 
        
    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.tag == "Mom"){ //엄마가 등장하게 되면 도끼 생성
            Color tempColor = mg_Ax.GetComponent<SpriteRenderer>().color;
            tempColor.a = 1f;
            mg_Ax.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}
