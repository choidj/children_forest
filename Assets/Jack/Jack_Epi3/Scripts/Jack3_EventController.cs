/*
 * - Name : Jack3_EventController.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드3 - 이벤트 관리 스크립트
 *            게임진행 이벤트를 총괄적으로 관리하기 위한 스크립트
 * 
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
 * -Variable 
 * 
 * 게임 디렉터 오브젝트에 접근하기 위한 오브젝트
 * mg_ScriptManager
 * 
 * 할아버지 말풍선 관련 오브젝트
 * mg_GenGFSpeechBubble
 * mg_GFSpeech
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
 * mg_Cow
 * mg_Bean
 * 
 * 이벤트 성공확인을 위한 flag
 * mb_BeanToJack
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
 * 할아버지 스크립트 함수
 * v_NextGFScript()
 * v_NoneGFScript()
 * 
 * 말풍선 생성 함수
 * v_GenGFSpeechBubble()
 * v_GenJackSpeechBubble()
 * 
 * 말풍선 삭제 함수
 * v_RemoveGFSpeechBubble()
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


public class Jack3_EventController : MonoBehaviour
{
    //게임 디렉터 오브젝트에 접근하기 위한 오브젝트
    GameObject mg_ScriptManager;

    //할아버지 말풍선 관련 오브젝트
    GameObject mg_GenGFSpeechBubble;
    public GameObject mg_GFSpeech;

    //잭 말풍선 관련 오브젝트
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //이벤트 관리를 위한 변수
    private bool mb_EventFlag;  //이벤트를 한번만 작동하기 위한 flag
    private int mn_EventSequence;   //이벤트 순서를 관리하는 변수

    //마우스 드래그 관련 오브젝트
    GameObject mg_Cow;
    GameObject mg_Bean;


    //이벤트 성공확인을 위한 flag
    private bool mb_BeanToJack;
    private bool mb_CowToGF;



    void Start(){
        //오브젝트 연결
        this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");
        this.mg_Cow = GameObject.Find("Jack3_Cow");
        this.mg_Bean = GameObject.Find("Jack3_Bean");

        mb_BeanToJack = false;
        mb_CowToGF = false;

        v_ChangeFlagFalse();
        mn_EventSequence = 0;

        v_NextMainScript();

        v_TurnOFFMouseDrag();
    }


    void Update(){
        if (Input.GetMouseButtonDown(0)){
            mn_EventSequence += 1;
            v_ChangeFlagTrue();
        }

        if (mb_CowToGF == true && mb_BeanToJack == true)
        {
            Debug.Log("시나리오 완료");
        }

        if (mn_EventSequence == 1 && this.mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_GenGFSpeechBubble();
            v_NextGFScript();
        }
        else if (mn_EventSequence == 2 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveGFSpeechBubble();

            v_NextJackScript();
            v_GenJackSpeechBubble();
        }
        else if (mn_EventSequence == 3 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_GenGFSpeechBubble();
            v_NextGFScript();
        }
        else if (mn_EventSequence == 4 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_NextGFScript();
        }
        else if (mn_EventSequence == 5 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveGFSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 6 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_NextJackScript();
            v_GenJackSpeechBubble();
        }
        else if (mn_EventSequence == 7 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_NextMainScript();
        }
        else if (mn_EventSequence == 8 && mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();
            v_NextEventScript();

            v_TurnOnMouseDrag();

        }
    }

    //Flag 변경 함수
    private void v_ChangeFlagFalse(){
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue(){
        this.mb_EventFlag = true;
    }

    //메인 스크립트 함수
    private void v_NextMainScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NoneScript();
    }

    //이벤트 스크립트 함수
    private void v_NextEventScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MissionScript>().v_NoneScript();
    }

    //잭 스크립트 함수
    private void v_NextJackScript(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
    }

    //할아버지 스크립트 함수
    private void v_NextGFScript(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NextScript();
    }
    private void v_NoneGFScript(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
    }

    //말풍선 생성 함수
    private void v_GenGFSpeechBubble(){
        mg_GenGFSpeechBubble = Instantiate(mg_GFSpeech) as GameObject;
        mg_GenGFSpeechBubble.transform.position = new Vector3(4, 0.5f, 0);
    }
    private void v_GenJackSpeechBubble(){
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-0.5f, -1, 0);
    }

    //말풍선 삭제 함수
    private void v_RemoveGFSpeechBubble(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
        Destroy(this.mg_GenGFSpeechBubble);
    }
    private void v_RemoveJackSpeechBubble(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

    //드래그 활성화
    private void v_TurnOnMouseDrag()
    {
        this.mg_Cow.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
    }

    public void v_DragBean()
    {
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
    }

    //드래그 비활성화
    private void v_TurnOFFMouseDrag()
    {
        this.mg_Cow.GetComponent<Jack3_MouseDrag>().v_ChangeFlagFalse();
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagFalse();
    }

    public void v_BeanToJack()
    {
        mb_BeanToJack = true;
    }

    public void v_CowToGF()
    {
        mb_CowToGF = true;
    }
}
