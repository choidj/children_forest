/*
 * - Name : Movement_Giant.cs
 * - Writer : 이윤교
 * - Content : 잭과콩나무 에피소드13 - 거인 이동 스크립트
 * 
 *            -작성 기록-
 *            2021-07-15 : 제작 완료
 *
 * MoveTowards() : 등속 이동, 매개변수로 {현재위치, 목표위치, 속도}를 입력           
 *            
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementGiant : MonoBehaviour
{
    float mf_timer; //현재 시간
    float mf_waitingTime; //원하는 시간 지정
    public Vector3 v3_target; //원하는 위치 지정
    public ScriptControl sc;
    VoiceManager vm;
    bool mb_checkPlayOnce = true;
    
    void Start(){
        sc = ScriptControl.GetInstance();
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update(){
         if(vm.mb_checkSceneReady) {
            /*deltaTime을 이용해서 시간 지연*/ 
            mf_timer += Time.deltaTime;
            if (mf_timer > mf_waitingTime){ //-> 원하는 시간(초) 이후 함수 실행
                transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.1f); //거인이동
            }
            if(mb_checkPlayOnce) {
            vm.playVoice(0);
            mb_checkPlayOnce = false;
            }
    }

        
    }
}
