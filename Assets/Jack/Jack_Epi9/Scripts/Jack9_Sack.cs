/*
 * - Name : Jack9_Sack.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드9 - 자루 이벤트관련 스크립트
 *              자루를 여러번 클릭할 경우 자루가 터지게 작동
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
 * mn_SackTouchCount : 터뜨리기위해 필요한 터치 횟수
 * 
 * -Function
 * OnMouseDown() : 클릭시 작동 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Jack9_Sack : MonoBehaviour
{
    int mn_SackTouchCount;
    GameObject EventController;


    // Start is called before the first frame update
    void Start()
    {
        this.EventController = GameObject.Find("GameDirector");

        mn_SackTouchCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(mn_SackTouchCount <= 0)
        {
            Destroy(gameObject);
            this.EventController.GetComponent<Jack9_EventController>().v_IsSackDestroy();
        }
    }

    private void OnMouseDown()
    {
        mn_SackTouchCount -= 1;
    }


}
