/*
 * - Name : Jack5_EndPoint.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드5 - 콩나무 끝지점 오브젝트 스크립트
 *            콩과 어머니객체 충돌처리를 위한 스크립트
 * 
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-15 : 제작 완료
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
using UnityEngine.SceneManagement;


public class Jack5_EndPoint : MonoBehaviour
{
    GameObject mg_EventManager;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Destroy(cCollidObj.gameObject);
        SceneManager.LoadScene("Jack_Epi6");
    }
}
