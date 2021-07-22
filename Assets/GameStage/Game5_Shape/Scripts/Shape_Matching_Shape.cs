/*
  * - Name : Shape_Matching_Shape.cs
  * - Writer : 이윤교
  * - Content : 도형 맞추기 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *            2021-07-22 : 주석처리 완료
  *
  *
  * Input.GetMouseButtonUp() : 유저가 주어진 마우스 버튼에서 손을 뗏을 때 true를 반환. 버튼이 0이면 좌클릭, 1이면 우클릭, 2이면 중앙을 클릭한 것.
  * OnTriggerEnter2D(Collider2D cCollideObject) : 유니티의 collider 컴포넌트를 주었을 때 호출되는 함수로, 이름과 같이 collider들이 부딪혔을 때 호출되어 함수안에 어떤 작업을 할지를 적어주는 함수
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape_Matching_Shape : MonoBehaviour{
    AudioSource auSource;
    Vector2 mv2_initPos;
    public bool mb_classifyWhetherAns = false; //matching되기 전

    public Sprite sNextSprite; //빈자리에 퍼즐을 맞춘 후 정답일 때 넣을 퍼즐 조각

    void Start() {
        mv2_initPos = this.transform.position; //초기 위치 저장
    }
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_initPos, 2f * Time.deltaTime); //도형을 맞추지 못했을 경우 초기 위치로 제자리.
    }
    void OnTriggerStay2D(Collider2D cCollideObject){
        if(Input.GetMouseButtonUp(0)) { //도형맞추려고 시도(드래그 후 맞춤판정 후 )
            if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){ //정답이면
                if (mb_classifyWhetherAns){
                    gameObject.GetComponent<SpriteRenderer>().sprite = sNextSprite;
                }
                else
                    Destroy(this.gameObject);
            }

        }
    }
}



