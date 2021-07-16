/*
 * - Name : Jack5_EventController.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드4 - 이벤트 관리 스크립트
 *            게임진행 이벤트를 총괄적으로 관리하기 위한 스크립트
 * 
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
 * -Variable 
 * 
 * 게임 디렉터 오브젝트에 접근하기 위한 오브젝트
 * mg_ScriptManager
 * 
 * 잭 말풍선 관련 오브젝트
 * mg_GenJackSpeechBubble
 * mg_JackSpeech
 * 
 * 이벤트 관리 변수
 * mb_EventFlag : 이벤트를 한번만 작동하기 위한 flag
 * mn_EventSequence : 이벤트 순서를 관리하는 변수
 * 
 * 마우스 드래그 관련 오브젝트
 * mg_Bean
 * 
 * 마우스 클릭 제한 flag
 * StopClickFlag
 * 
 * 이벤트 성공확인을 위한 flag
 * 
 * 
 * -Function
 * 
 * Flag 변경 함수
 * v_ChangeFlagFalse()
 * v_ChangeFlagTrue()
 * 
 * 메인 스크립트 함수
 * v_NextMainScript()
 * v_NoneMainScript()
 * 
 * 이벤트 스크립트 함수
 * v_NextEventScript()
 * v_NoneEventScript()
 * 
 * 잭 스크립트 함수
 * v_NextJackScript()
 * v_NoneJackScript()
 * 
 * 
 * 말풍선 생성 함수
 * v_GenJackSpeechBubble()
 * 
 * 말풍선 삭제 함수
 * v_RemoveJackSpeechBubble()
 * 
 * 드래그 활성화
 * v_TurnOnMouseDrag()
 * 
 * 드래그 비활성화
 * v_TurnOFFMouseDrag()
 * 
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jack5_EventController : MonoBehaviour
{
    //게임 디렉터 오브젝트에 접근하기 위한 오브젝트
    GameObject mg_ScriptManager;

    //잭 말풍선 관련 오브젝트
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //이벤트 관리를 위한 변수
    private bool mb_EventFlag;  //이벤트를 한번만 작동하기 위한 flag
    private int mn_EventSequence;   //이벤트 순서를 관리하는 변수

    //마우스 드래그 관련 오브젝트
    GameObject mg_Jack;

    //마우스 클릭 제한
    private bool StopClickFlag;

    //이벤트 성공확인을 위한 flag




    // Start is called before the first frame update
    void Start()
    {
        //오브젝트 연결
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mg_Jack = GameObject.Find("Jack");

        //이벤트 flag
        StopClickFlag = false;

        //이벤트 관련
        v_ChangeFlagFalse();
        mn_EventSequence = 0;


        //이벤트 시작
        v_NextMainScript();

        //드래그 금지 함수
        v_TurnOFFMouseDrag();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (StopClickFlag == false)
            {
                mn_EventSequence += 1;
            }
            v_ChangeFlagTrue();
        }

        if (mn_EventSequence == 1 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 3 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_GenJackSpeechBubble();
            v_NextJackScript();
        }
        else if (mn_EventSequence == 4 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NextJackScript();
        }
        else if (mn_EventSequence == 5 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 6 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_TurnOnMouseDrag();

            v_NextEventScript();
        }


    }


    //Flag 변경 함수
    private void v_ChangeFlagFalse()
    {
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue()
    {
        this.mb_EventFlag = true;
    }

    //메인 스크립트 함수
    private void v_NextMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MainScript>().v_NoneScript();
    }

    //이벤트 스크립트 함수
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MissionScript>().v_NoneScript();
    }
    
    //잭 스크립트 함수
    private void v_NextJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NoneScript();
    }

    //말풍선 생성 함수
    private void v_GenJackSpeechBubble()
    {
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-3, -1, 0);
    }

    //말풍선 삭제 함수
    private void v_RemoveJackSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

    //드래그 활성화
    private void v_TurnOnMouseDrag()
    {
        this.mg_Jack.GetComponent<Jack5_MouseDrag>().v_ChangeFlagTrue();
    }

    //드래그 비활성화
    private void v_TurnOFFMouseDrag()
    {
        this.mg_Jack.GetComponent<Jack5_MouseDrag>().v_ChangeFlagFalse();
    }
}
