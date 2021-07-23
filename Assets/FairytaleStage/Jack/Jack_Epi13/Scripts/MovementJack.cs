/*
 * - Name : Movement_Jack.cs
 * - Writer : 이윤교
 * - Content : 잭과콩나무 에피소드13 - 잭 이동 스크립트
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

public class MovementJack : MonoBehaviour{
    public Vector3 v3_target; //원하는 위치 지정
    public ScriptControl sc;
    VoiceManager vm;
    bool mb_checkPlayOnce = true;
    bool mb_checkPlayVoice = false;
    void Start(){
        sc = ScriptControl.GetInstance();
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update(){
        if(vm.mb_checkSceneReady) {
            transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.2f);
            if(mb_checkPlayOnce) {
                vm.playVoice(0);
                mb_checkPlayOnce = false;
            }
            if(!vm.isPlaying() && mb_checkPlayVoice == false){
                sc.setNextScript();
                vm.playVoice(1);
                mb_checkPlayVoice = true;
            }

            
        }
    }
}
