/*
  * - Name : DragAx.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드14 - 도끼 움직이는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-15 : 제작 완료
  *
  * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트에 연결된 트리거 안에 다른 오브젝트가 들어갔을 때 호출됨 (2D 물리만)
  * OnMouseDrag() : 게임오브젝트를 드래그로 이동시키는 함수
  *            
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAx : MonoBehaviour{   
    public GameObject mg_Jack; //잭
    public GameObject mg_Ax; //도끼
    public GameObject mg_Click; //미션유도클릭
    public ScriptControl sc;
    VoiceManager vm;
    private bool mb_checkGetAxe = false; //잭의 도끼 습득 유무 -> 잭이 도끼를 습득 전
    SpriteRenderer rend;
    void Start() {
        mg_Click = GameObject.Find("Click"); //Click 게임 오브젝트를 찾아서 mg_Click 변수에 저장
        sc = ScriptControl.GetInstance();
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    public void OnMouseDrag(){
        Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
        Destroy(mg_Click); //도끼를 드래그 하면 미션유도클릭 없애기
        this.transform.position = v2worldObjPos;
    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.tag == "Jack" && !mb_checkGetAxe){ //잭이 도끼를 가지게 되면
            // Debug.Log(transfrom.gameObject.name);
            rend =  mg_Jack.GetComponent<SpriteRenderer>();
            rend.flipX = false; //잭이 콩나무 바라보기 -> 좌우대칭
            transform.position = mg_Jack.transform.position; //도끼위치를 잭위치로 배치
            vm.playVoice(1);
            sc.setNextScript(); //다음스크립트 나오게
            mb_checkGetAxe = true; //-> 잭이 도끼를 습득 후
        }
    }
}
