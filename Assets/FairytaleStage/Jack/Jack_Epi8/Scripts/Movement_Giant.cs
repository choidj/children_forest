/*
  * - Name : Movement_Giant.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드8 - 거인 이동 스크립트
  * 
  *            -작성 기록-
  *            2021-07-14 : 제작 완료
  *
  * MoveTowards() : 등속 이동, 매개변수로 {현재위치, 목표위치, 속도}를 입력  
  *            
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Giant : MonoBehaviour{
  public GameObject mg_targetPosition; // walkPos 오브젝트로 지정해줘서 그 위치로 거인 이동시킴
  public ScriptControl sc;
  VoiceManager vm;
  bool mb_checkPlayOnce = true; //한번만 실행하게 설정
  void Start(){
    sc = ScriptControl.GetInstance();
    this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
  
  void Update(){
    if(vm.mb_checkSceneReady) {
      transform.position = Vector3.MoveTowards(gameObject.transform.position, mg_targetPosition.transform.position, 0.1f); //거인 이동 
      if(mb_checkPlayOnce) {
      vm.playVoice(0);
      mb_checkPlayOnce = false;
      } 
    }
    
  }
}