/*
 * - Name : Drag_Jack.cs
 * - Writer : 이윤교
 * - Content : 잭과콩나무 에피소드8 - 잭 드래그 스크립트
 * 
 *            -작성 기록-
 *            2021-07-14 : 제작 완료
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 드래그로 이동시키는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drag_Jack : MonoBehaviour{   
    public GameObject Jack;
    public ScriptControl sc;
    VoiceManager vm;
    void Start(){
        sc = ScriptControl.GetInstance();
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        OnMouseDrag();
        if(cCollideObject.tag == "Closet"){ //충돌 오브젝트의 태그가 옷장이면 -> Jack이 옷장 뒤에 숨으면
            sc.setNextScript();
            vm.playVoice(1);
        }
        if(!vm.isPlaying()) {
            Invoke("gotoEpi9Scene", 5f); //5초 후 endScene 함수 수행
        }
    }
    void OnMouseDrag(){
                Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
                Jack.transform.position = v2worldObjPos;
    }

    void gotoEpi9Scene() {
        SceneManager.LoadScene("Jack_Epi9"); //end_scene 씬 로드
    }
}
