/*
  * - Name : Drag.cs
  * - Writer : 이윤교
  * - Content : 드래그 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  *  OnMouseDrag() : 게임오브젝트를 드래그로 이동시키는 함수
  *
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour{
  AudioSource auSource;
  void Start(){
    auSource = GetComponent<AudioSource>();
  }

  void OnMouseDrag(){
    Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
    this.transform.position = v2worldObjPos;
  }
  void OnMouseDown(){
    auSource.Play();
  }

}