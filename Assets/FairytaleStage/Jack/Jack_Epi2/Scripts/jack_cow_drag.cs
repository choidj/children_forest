/*
 * - Name : jack_cow_drag.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 잭,소 드래그 스크립트
 * -기록-
 * 2021-07-20 : 작성
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 마우스 드래그로 이동시키는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jack_cow_drag : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}
