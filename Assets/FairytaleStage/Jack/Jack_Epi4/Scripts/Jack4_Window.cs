/*
 * - Name : Jack4_Mother.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드4 - 창문 오브젝트 스크립트
 *            콩과 창문객체 충돌처리를 위한 스크립트
 * 
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-14 : 제작 완료
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

public class Jack4_Window : MonoBehaviour
{
    GameObject mg_EventManager;
    GameObject mg_Bean;

    bool CheckFlag;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("GameDirector");
        this.mg_Bean = GameObject.Find("Bean");

    }

    // Update is called once per frame
    void Update()
    {
        CheckFlag = this.mg_EventManager.GetComponent<Jack4_EventController>().b_CheckBeanToMother();
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Debug.Log("충돌 감지");
        if (cCollidObj.tag == "Bean" && CheckFlag == true)
        {
            Destroy(cCollidObj.gameObject);
            this.mg_EventManager.GetComponent<Jack4_EventController>().v_BeanToWindow();
        }
    }
}
