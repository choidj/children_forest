/*
 * - Name : Jack4_EventController.cs
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
 * 어머니 말풍선 관련 오브젝트
 * mg_GenMotherSpeechBubble
 * mg_MotherSpeech
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
 * mb_BeanToMother
 * mb_CowToGF
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
 * 어머니 스크립트 함수
 * v_NextMotherScript()
 * v_NoneMotherScript()
 * 
 * 말풍선 생성 함수
 * v_GenMotherSpeechBubble()
 * v_GenJackSpeechBubble()
 * 
 * 말풍선 삭제 함수
 * v_RemoveMotherSpeechBubble()
 * v_RemoveJackSpeechBubble()
 * 
 * 드래그 활성화
 * v_TurnOnMouseDrag()
 * 
 * 드래그 비활성화
 * v_TurnOFFMouseDrag()
 * 
 * flag true 처리 함수
 * v_BeanToJack()
 * v_CowToGF()
 * 
 * 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack4_EventController : MonoBehaviour
{
    //게임 디렉터 오브젝트에 접근하기 위한 오브젝트
    GameObject mg_ScriptManager;

    //어머니 말풍선 관련 오브젝트
    GameObject mg_GenMotherSpeechBubble;
    public GameObject mg_MotherSpeech;

    //잭 말풍선 관련 오브젝트
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //이벤트 관리를 위한 변수
    private bool mb_DontLoopEvent1;
    private bool mb_DontLoopEvent2;
    private bool mb_EventFlag;  //이벤트를 한번만 작동하기 위한 flag
    private int mn_EventSequence;   //이벤트 순서를 관리하는 변수

    //마우스 드래그 관련 오브젝트
    GameObject mg_Bean;

    //마우스 클릭 제한
    private bool StopClickFlag;

    //이벤트 성공확인을 위한 flag
    private bool mb_BeanToMother;
    private bool mb_BeanToWindow;





    // Start is called before the first frame update
    void Start()
    {
        //오브젝트 연결
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mg_Bean = GameObject.Find("Bean");

        //이벤트 flag
        mb_DontLoopEvent1 = false;
        mb_DontLoopEvent2 = false;
        mb_BeanToMother = false;
        StopClickFlag = false;
        mb_BeanToWindow = false;

        //이벤트 관련
        v_ChangeFlagFalse();
        mn_EventSequence = 0;

        //오브젝트 마우스 드래그 기능 불가
        v_TurnOFFMouseDrag();


        //이벤트 시작
        v_NextMotherScript();
        v_GenMotherSpeechBubble();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(StopClickFlag == false)
            {
                mn_EventSequence += 1;
            }
            v_ChangeFlagTrue();
        }

        if (mn_EventSequence == 1 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveMotherSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_DontLoopEvent1 == false)
        {
            v_ChangeFlagFalse();

            v_NextEventScript();

            v_TurnOnMouseDrag();

            mb_DontLoopEvent1 = true;
            StopClickFlag = true;
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_BeanToMother == true)
        {
            v_ChangeFlagFalse();

            v_NoneEventScript();

            v_GenJackSpeechBubble();
            v_NextJackScript();

            StopClickFlag = false;
            v_TurnOFFMouseDrag();
        }
        else if (mn_EventSequence == 3 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 4 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_GenMotherSpeechBubble();
            v_NextMotherScript();
        }
        else if (mn_EventSequence == 5 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveMotherSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 6 && this.mb_EventFlag == true && mb_DontLoopEvent2 == false)
        {
            v_ChangeFlagFalse();

            v_NextEventScript();

            v_TurnOnMouseDrag();
            StopClickFlag = false;
            mb_DontLoopEvent2 = true;
        }
        if(mb_BeanToWindow == true)
        {
            Debug.Log("에피소드 클리어");
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
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NoneScript();
    }

    //이벤트 스크립트 함수
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NoneScript();
    }

    //잭 스크립트 함수
    private void v_NextJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
    }

    //어머니 스크립트 함수
    private void v_NextMotherScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NextScript();
    }
    private void v_NoneMotherScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
    }

    //말풍선 생성 함수
    private void v_GenMotherSpeechBubble()
    {
        mg_GenMotherSpeechBubble = Instantiate(mg_MotherSpeech) as GameObject;
        mg_GenMotherSpeechBubble.transform.position = new Vector3(1, 1, 0);
    }
    private void v_GenJackSpeechBubble()
    {
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-2, -1, 0);
    }

    //말풍선 삭제 함수
    private void v_RemoveMotherSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
        Destroy(this.mg_GenMotherSpeechBubble);
    }
    private void v_RemoveJackSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

    //드래그 활성화
    private void v_TurnOnMouseDrag()
    {
        this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_ChangeFlagTrue();
    }

    //드래그 비활성화
    private void v_TurnOFFMouseDrag()
    {
        this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_ChangeFlagFalse();
    }

    public void v_BeanToMother()
    {
        this.mb_BeanToMother = true;
    }

    public bool b_CheckBeanToMother()
    {
        return mb_BeanToMother;
    }

    public void v_BeanToWindow()
    {
        this.mb_BeanToWindow = true;
    }
}
