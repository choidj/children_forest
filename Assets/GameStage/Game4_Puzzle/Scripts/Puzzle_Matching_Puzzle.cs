/*
  * - Name : Puzzle_Matching_Puzzle.cs
  * - Writer : 이윤교
  * - Content : 퍼즐을 맞추는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *            2021-07-21 : 수정 완료
  *            2021-07-22 : 주석처리 완료
  *
  * Input.GetMouseButtonUp() : 유저가 주어진 마우스 버튼에서 손을 뗏을 때 true를 반환. 버튼이 0이면 좌클릭, 1이면 우클릭, 2이면 중앙을 클릭한 것.
  * OnTriggerEnter2D(Collider2D cCollideObject) : 유니티의 collider 컴포넌트를 주었을 때 호출되는 함수로, 이름과 같이 collider들이 부딪혔을 때 호출되어 함수안에 어떤 작업을 할지를 적어주는 함수
  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour{
    public bool mb_classifyWhetherAns = false; //matching되기 전 
    //AudioSource auSource;
    public Sprite sNextSprite;
    Vector2 mv2_initPos;
    private void Start(){
        if(!mb_classifyWhetherAns){
            transform.position = new Vector3(Random.Range(19, 26), Random.Range(3, 11), 0);//자리 랜덤 선정
            mv2_initPos = transform.position; //자리 랜덤 선정 따로 저장 (퍼즐을 맞추지 못할 경우 제자리로 돌아가기 위함)
        }
    }
    void Update() {
        if(!mb_classifyWhetherAns){ // matching 퍼즐일 경우
            transform.position = Vector3.MoveTowards(this.transform.position, mv2_initPos, 2f * Time.deltaTime); //처음 지정된 랜덤자리로 다시 되돌아감.
        }
    }

    void OnTriggerStay2D(Collider2D cCollideObject){
        if(Input.GetMouseButtonUp(0)){ //손을 뗐을 때
            if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){//매칭퍼즐과 매칭퍼즐과모양이같은퍼즐의 이름 맨 뒤(숫자)가 같은 경우
                if (mb_classifyWhetherAns){ // answer부분변경
                    //흐렷던 퍼즐조각을 선명하게 변경
                    Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
                    tempColor.a = 1f;
                    gameObject.GetComponent<SpriteRenderer>().color = tempColor;    
                }
                else // matching부분변경
                    Destroy(this.gameObject);
                
            }
        }
    }
}

