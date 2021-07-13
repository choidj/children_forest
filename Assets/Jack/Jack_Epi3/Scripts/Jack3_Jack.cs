/*
 * - Name : Jack3_Jack.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드3 - 잭 오브젝트 스크립트
 *            잭과 콩의 객체 충돌처리를 위한 스크립트
 * 
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-13 : 제작 완료
 *            
 *            
 *            
 * 
 * - Variable
 * 
 * 감독 오브젝트 연결을 위한 오브젝트
 * mg_EventManager
 * 
 * 
 * - Function
 * 
 * 충돌감지 함수
 * OnTriggerEnter2D(Collider2D cCollidObj) 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack3_Jack : MonoBehaviour
{
    GameObject mg_EventManager;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("Jack3_GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Debug.Log("충돌 감지");
        if (cCollidObj.tag == "Jack3_Bean")
        {
            Destroy(cCollidObj.gameObject);
            this.mg_EventManager.GetComponent<Jack3_EventController>().v_BeanToJack();
        }
    }
}
