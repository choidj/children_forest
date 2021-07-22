/*
 * - Name : Movement_Giant.cs
 * - Writer : 이윤교
 * - Content : 잭과콩나무 에피소드13 - 잭 원하는 위치로 드래그 스크립트
 * 
 *            -작성 기록-
 *            2021-07-15 : 제작 완료
 *
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 드래그로 이동시키는 함수
 * 
 *            
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DragJack : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if(cCollideObject.tag == "Jack"){   //충돌 오브젝트의 태그가 잭이면 -> Jack을 드래그가능하게 함
            OnMouseDrag();
        }
        else if(cCollideObject.tag == "Door"){ //충돌 오브젝트의 태그가 문이면
            SceneManager.LoadScene("Jack_Epi14");//다음 씬 Epi14으로 이동
        }
    }

    void OnMouseDrag(){
                Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
                this.transform.position = v2worldObjPos;
    }
}