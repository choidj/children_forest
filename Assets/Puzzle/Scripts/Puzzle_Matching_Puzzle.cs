/*
  * - Name : Puzzle_Matching_Puzzle.cs
  * - Writer : 이윤교
  * - Content : 퍼즐을 맞추는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  * 
  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour{
    public bool mb_classifyWhetherAns = false; //matching되기 전 
    AudioSource auSource;
    public Sprite sNextSprite;
    private void Start(){
        if(!mb_classifyWhetherAns){
            transform.position = new Vector3(Random.Range(19, 26), Random.Range(3, 11), 0);//자리 랜덤 선정
        }
    }

    void OnTriggerStay2D(Collider2D cCollideObject){
        if(Input.GetMouseButtonUp(0)){
            if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){//매칭퍼즐과 매칭퍼즐과모양이같은퍼즐의 이름 맨 뒤(숫자)가 같은 경우
                if (mb_classifyWhetherAns){
                    //흐렷던 퍼즐조각을 선명하게 변경
                    Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
                    tempColor.a = 1f;
                    gameObject.GetComponent<SpriteRenderer>().color = tempColor;
                    //gameObject.GetComponent<SpriteRenderer>().sprite = sNextSprite;
                    
                }
                else
                    Destroy(this.gameObject);
                
            }
        }
    }
}

