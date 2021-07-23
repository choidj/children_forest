﻿/*
 * - Name : Jack3_Jack.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드3 - Jack 오브젝트 스크립트
 * Jack과 콩의 객체 충돌처리를 위한 스크립트
 * 
 *  * - Update Log -
 * 2021-07-13 : 제작 완료
 * 2021-07-23 : 주석 변경
 *          
 * - Variable
 * mg_EventManager                          감독 오브젝트 연결을 위한 변수
 * 
 * - Function
 * OnTriggerEnter2D(Collider2D cCollidObj)  충돌감지 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack3_Jack : MonoBehaviour
{
    GameObject mg_EventManager;

    void Start()
    {
        this.mg_EventManager = GameObject.Find("Jack3_GameDirector");                                       // 오브젝트 연결
    }

    /// <summary>
    /// 오브젝트 충돌시 작동 함수
    /// </summary>
    /// <param name="cCollidObj">충돌한 객체</param>
    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        //Debug.Log("충돌 감지");
        if (cCollidObj.tag == "Jack3_Bean")                                                                 // Jack과 콩객체가 충돌한 경우
        {
            Destroy(cCollidObj.gameObject);                                                                 // 충돌한 객체 삭제
            this.mg_EventManager.GetComponent<Jack3_EventController>().v_BeanToJack();                      // 콩이 Jack에게 전달되었다고 입력
            this.mg_EventManager.GetComponent<Jack3_EventController>().v_RemoveArrowToBean();               // 콩을 가르키는 화살표 삭제
        }
    }
}
