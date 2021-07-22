/*
 * - Name : Mart_Kart.cs
 * - Writer : 김명현
 * 
 * - Content
 * 카트 오브젝트에 관한 스크립트
 * 충돌 시 정답 확인 및 정답일 경우 O 를 띄우고 오브젝트 삭제
 * 만약 오답일 경우 오브젝트를 원위치 시키고 X 이미지를 띄움
 * 
 * -Update Log-
 * 2021-07-07 : 제작 완료
 * 2021-07-08 : OX를 나타내는 기능 추가
 * 2021-07-09 : 변수명 수정
 *                  
 * - Variable 
 * mg_GameDirector : GameDirector오브젝트 연결을 위한 변수
 * mg_ShowOX : ShowOX 오브젝트 연결을 위한 변수
 * mg_MartRandomItem : Mart_RandomItem 오브젝트 연결을 위한 변수
 * mn_answer : 정답을 저장해두는 변수
 * mn_LeftTime : 남은 횟수를 저장해두는 변수
 * 
 * -Function()
 * OnTriggerEnter2D(Collider2D cCollidObj) : 오브젝트가 충돌됬을때 작동되는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Kart : MonoBehaviour{
    GameObject mg_GameDirector;
    GameObject mg_ShowOX;
    GameObject mg_MartRandomItem;

    int mn_answer;
    int mn_LeftTime;

    void Start(){                                   
        this.mg_GameDirector = GameObject.Find("GameDirector");                                         // 게임오브젝트들 연결
        this.mg_ShowOX = GameObject.Find("ShowOX");
        this.mg_MartRandomItem = GameObject.Find("Mart_RandomItem");
    }

    void Update(){
        mn_answer = mg_MartRandomItem.GetComponent<Mart_RandomItem>().n_ReturnAnswer();                       // 실시간으로 정답을 전달받는다
    }

    /// <summary>
    /// 카트 오브젝트와 다른 오브젝트가 충돌한 경우 작동하는 함수.
    /// mn_answer 변수를 통해 정답인지 확인하고 처리한다.
    /// </summary>
    /// <param name="cCollidObj">충돌한 오브젝트</param>
    void OnTriggerEnter2D(Collider2D cCollidObj){
        if (cCollidObj.tag == "Mart_Item1" && mn_answer == 0){                                          // 정답인 경우
            Debug.Log("Mart_Item1 삭제");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(0);                 // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();            // 남은 횟수 확인 및 값 저장
            Destroy(cCollidObj.gameObject);                                                             // 정답 오브젝트 삭제
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();                          // 정답이 되었다고 flag값 변경
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();                                         // O 이미지를 보여준다.
        }
        if(cCollidObj.tag == "Mart_Item1" && mn_answer != 0){                                           // 오답인 경우
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();                                         // X이미지를 보여준다.
        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer == 1){                                          // 정답
            Debug.Log("Mart_Item2 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(1);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer != 1){                                          // 오답
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer == 2){                                          // 정답
            Debug.Log("Mart_Item3 삭제");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(2);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer != 2){                                          // 오답
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer == 3){
            Debug.Log("Mart_Item4 삭제");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(3);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer != 3){
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer == 4){
            Debug.Log("Mart_Item5 삭제");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(4);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer != 4){
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer == 5){
            Debug.Log("Mart_Item6 삭제");
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(5);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer != 5){
            Debug.Log("오답");
            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
    }
}
