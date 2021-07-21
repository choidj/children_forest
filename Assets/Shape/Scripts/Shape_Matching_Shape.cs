/*
  * - Name : Shape_Matching_Shape.cs
  * - Writer : 이윤교
  * - Content : 도형 맞추기 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape_Matching_Shape : MonoBehaviour{
    AudioSource auSource;
    Vector2 mv2_initPos;
    public bool mb_classifyWhetherAns = false; //matching되기 전
    //public Sprite[] msa_changeAnsImg = new Sprite[4];
    public Sprite sNextSprite; //빈자리에 퍼즐을 맞춘 후 정답일 때 넣을 퍼즐 조각

    void Start() {
        mv2_initPos = this.transform.position;
    }
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_initPos, 2f * Time.deltaTime);
    }
    void OnTriggerStay2D(Collider2D cCollideObject){
        if(Input.GetMouseButtonUp(0)) {
            if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){
                if (mb_classifyWhetherAns){
                    gameObject.GetComponent<SpriteRenderer>().sprite = sNextSprite;
                }
                else
                    Destroy(this.gameObject);
            }

        }
    }
}



