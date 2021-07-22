/*
 * - Name : HarpDrag.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드12 - 하프 드래그 스크립트
 *          -기록-
 *          2021-07-20 : 작성
 * - HarpDrag Member variable 
 * null
 * - HarpDrag Member function 
 * OnMouseDrag() : 게임오브젝트를 마우스 드래그로 이동시키는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 하프 게임 오브젝트를 드래그시에 나타나는 행동을 처리하는 클래스이다.
public class HarpDrag : MonoBehaviour
{
    // 드래그시에 마우스를 따라오도록 하였다.
    private void OnMouseDrag()
    {
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}
