/*
 * - Name : Jack3_EventController.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드3 - 이벤트 관리 스크립트
 * 게임진행 이벤트를 총괄적으로 관리하기 위한 스크립트
 * 
 * -Update Log-
 * 2021-07-13 : 제작 완료
 * 2021-07-16 : 화살표 기능 추가 및 인코딩형식 변경
 * 2021-07-21 : 주석 변경
 * 
 * -Variable 
 * mg_ScriptManager                 게임 디렉터 오브젝트에 접근하기 위한 변수
 * mg_ArrowToBean                   콩을 가르키는 화살표
 * mg_ArrowToCow                    소를 가르키는 화살표
 * mg_ArrowToGF                     할아버지를 가르키는 화살표
 * mg_ArrowToJack                   잭을 가르키는 화살표
 * mg_ArrowPrefab                   화살표 프리팹 연결을 위한 변수
 * mg_GenGFSpeechBubble             할아버지 말풍선 오브젝트 조작을 위한 변수
 * mg_GFSpeech                      할아버지 말풍선 프리팹과 연결을 위한 변수
 * mg_GenJackSpeechBubble           잭 말풍선 관련 오브젝트
 * mg_JackSpeech                    잭 말풍선 관련 오브젝트
 * mb_EventFlag                     이벤트를 한번만 작동하기 위한 flag
 * mn_EventSequence                 이벤트 순서를 관리하는 변수
 * mg_Cow                           마우스 드래그 관련 오브젝트
 * mg_Bean                          마우스 드래그 관련 오브젝트
 * mb_BeanToJack                    이벤트 성공확인을 위한 flag
 * mb_CowToGF                       이벤트 성공확인을 위한 flag
 * 
 * -Function
 * v_ChangeFlagFalse()              Flag 변경 함수
 * v_ChangeFlagTrue()               Flag 변경 함수
 * v_NextMainScript()               메인 스크립트 함수
 * v_NoneMainScript()               메인 스크립트 함수
 * v_NextEventScript()              이벤트 스크립트 함수
 * v_NoneEventScript()              이벤트 스크립트 함수
 * v_NextJackScript()               잭 스크립트 함수
 * v_NoneJackScript()               잭 스크립트 함수
 * v_NextGFScript()                 할아버지 스크립트 함수
 * v_NoneGFScript()                 할아버지 스크립트 함수
 * v_GenGFSpeechBubble()            말풍선 생성 함수
 * v_GenJackSpeechBubble()          말풍선 생성 함수
 * v_RemoveGFSpeechBubble()         말풍선 삭제 함수
 * v_RemoveJackSpeechBubble()       말풍선 삭제 함수
 * v_TurnOnMouseDrag()              드래그 활성화
 * v_TurnOFFMouseDrag()             드래그 비활성화
 * v_BeanToJack()                   flag true 처리 함수
 * v_CowToGF()                      flag true 처리 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jack3_EventController : MonoBehaviour
{
    #region 변수 선언부

    //오브젝트 연결을 위한 변수 선언
    GameObject mg_ScriptManager;                                                                    // 게임 디렉터 오브젝트에 접근하기 위한 변수
    GameObject mg_Cow;                                                                              // 소 오브젝트 연결을 위한 변수
    GameObject mg_Bean;                                                                             // 콩 오브젝트 연결을 위한 변수  

    // 화살표 관련 변수
    GameObject mg_ArrowToBean;                                                                      // 콩을 가르키는 화살표
    GameObject mg_ArrowToCow;                                                                       // 소를 가르키는 화살표
    GameObject mg_ArrowToGF;                                                                        // 할아버지를 가르키는 화살표
    GameObject mg_ArrowToJack;                                                                      // 잭을 가르키는 화살표
    public GameObject mg_ArrowPrefab;                                                               // 화살표 프리팹 연결을 위한 변수

    //말풍선 관련 변수 선언
    GameObject mg_GenGFSpeechBubble;                                                                // 할아버지 말풍선 오브젝트 조작을 위한 변수
    public GameObject mg_GFSpeech;                                                                  // 할아버지 말풍선 프리팹과 연결을 위한 변수
    GameObject mg_GenJackSpeechBubble;                                                              // 잭 말풍선 오브젝트 조작을 위한 변수
    public GameObject mg_JackSpeech;                                                                // 잭 말풍선 프리팹과 연결을 위한 변수

    // 이벤트 관련 Flag 선언
    private bool mb_EventFlag;                                                                      // 이벤트를 한번만 작동하기 위한 flag
    private int mn_EventSequence;                                                                   // 이벤트 순서를 관리하는 변수
    private bool mb_DragCowFlag;                                                                    // 소가 드래그 중인지 확인하기 위한 Flag
    private bool mb_DragBeanFlag;                                                                   // 콩이 드래그 중인지 확인하기 위한 Flag
    bool mb_BeanToJack;                                                                             // 콩이 Jack에게 전달이 됬는지 확인하기 위한 Flag
    private bool mb_CowToGF;                                                                        // 소가 할아버지에게 전달이 됬는지 확인하기 위한 Flag
    
    #endregion

    void Start(){
        // 변수를 오브젝트 연결하는 부분
        this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");
        this.mg_Cow = GameObject.Find("Jack3_Cow");
        this.mg_Bean = GameObject.Find("Jack3_Bean");

        // Flag값 False로 초기화
        mb_BeanToJack = false;
        mb_CowToGF = false;
        mb_DragCowFlag = false;
        mb_DragBeanFlag = false;
        v_ChangeFlagFalse();

        //첫 화면 설정
        mn_EventSequence = 0;                                                                       // 이벤트 0부터 시작
        v_NextMainScript();                                                                         // 메인 스크립트 출력
        v_TurnOFFMouseDrag();                                                                       // 스크립트 중 드래그되는 상황 방지
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){                                                           // 화면을 클릭시 다음으로 넘어감
            mn_EventSequence += 1;
            v_ChangeFlagTrue();
        }

        // 미션 수행 정도에 따른 이벤트 처리
        if (mb_CowToGF == true && mb_BeanToJack == true)                                            // 미션을 모두 해결하면 다음 씬으로 연결
        {
            SceneManager.LoadScene("Jack_Epi4");
        }
        else if(mb_CowToGF == true && mb_BeanToJack == false)                                       // 소가 할아버지에게 전달이 된 경우
        {
            this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
            v_NotDragCow();                                                                         // 소 드래그상태 해제
        }
        else if(mb_BeanToJack == true)                                                              // 콩이 Jack에게 전달 된 경우
        {
            v_DragBeanFalgFalse();                                                                  // 콩 드래그상태 해제
        }

        //드래그 상태에 따른 화살표 이펙트 효과 처리 부분
        if(mb_DragCowFlag == true && mn_EventSequence >= 8 && mb_DragBeanFlag == false)             // 소를 드래그 중인 경우
        {
            v_RemoveArrowToCow();
            if (mg_ArrowToGF == null)
            {
                v_GenArrowToGF();
            }
            if(mg_ArrowToBean != null)
            {
                v_RemoveArrowToBean();
            }
        }
        else if(mb_DragCowFlag == false && mn_EventSequence >= 8 && mb_DragBeanFlag == false)       // 아무것도 드래그 상태가 아닌경우
        {
            v_RemoveArrowToGF();

            if(this.mg_ArrowToCow == null && mn_EventSequence >= 9 && mb_CowToGF == false )
            {
                v_GenArrowToCow();
            }
            if (this.mg_ArrowToBean == null && mn_EventSequence >= 9 && mb_BeanToJack == false)
            {
                v_GenArrowToBean();
            }
        }
        if(mb_DragBeanFlag == true && mn_EventSequence >= 8 && mb_DragCowFlag == false)             // 콩을 드래그 중인 경우
        {
            v_RemoveArrowToBean();
            if(mg_ArrowToJack == null)
            {
                v_GenArrowToJack();
            }
            if(mg_ArrowToCow != null)
            {
                v_RemoveArrowToCow();
            }
        }
        else if(mb_DragBeanFlag == false && mn_EventSequence >= 8 && mb_DragCowFlag == false)       // 콩 드래그 해제한 경우
        {
            v_RemoveArrowToJack();

            if (this.mg_ArrowToCow == null && mn_EventSequence >= 9 && mb_CowToGF == false)
            {
                v_GenArrowToCow();
            }
            if (this.mg_ArrowToBean == null && mn_EventSequence >= 9 && mb_BeanToJack == false)
            {
                v_GenArrowToBean();
            }
        }

        //전체적인 이벤트
        if (mn_EventSequence == 1 && this.mb_EventFlag == true){                                    // 화면을 1번 터치하면 진행
            v_ChangeFlagFalse();                                                                    // 이벤트를 한번만 실행하기위한 flag

            v_NoneMainScript();                                                                     // 이전에 했던스크립트 정리

            v_GenGFSpeechBubble();
            v_NextGFScript();
        }
        else if (mn_EventSequence == 2 && mb_EventFlag == true){                                    // 화면을 2번 터치하면 진행
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

            v_GenArrowToBean();
            v_GenArrowToCow();   
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

    private void v_TurnOFFMouseDrag()                                                               // 드래그 비활성화
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

    public void v_GenArrowToBean()
    {
        mg_ArrowToBean = Instantiate(mg_ArrowPrefab) as GameObject;
        mg_ArrowToBean.transform.position = new Vector3(3.5f, -2.5f, 0);
        //mg_ArrowToBean.transform.position = new Vector3(6.1f, -3, 0);
    }

    public void v_GenArrowToCow()
    {
        mg_ArrowToCow = Instantiate(mg_ArrowPrefab) as GameObject;
        mg_ArrowToCow.transform.position = new Vector3(-3.5f, -1, 0);
        mg_ArrowToCow.GetComponent<SpriteRenderer>().flipX = true;   
    }

    public void v_GenArrowToGF()
    {
        mg_ArrowToGF = Instantiate(mg_ArrowPrefab) as GameObject;
        mg_ArrowToGF.transform.position = new Vector3(5.5f, 0, 0);
    }

    public void v_GenArrowToJack()
    {
        mg_ArrowToJack = Instantiate(mg_ArrowPrefab) as GameObject;
        mg_ArrowToJack.transform.position = new Vector3(-1.5f, -2, 0);
        mg_ArrowToJack.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void v_RemoveArrowToGF()
    {
        if(mg_ArrowToGF != null)
        {
            Destroy(mg_ArrowToGF);
        }
    }
    public void v_RemoveArrowToJack()
    {
        if (mg_ArrowToJack != null)
        {
            Destroy(mg_ArrowToJack);
        }
    }
    public void v_RemoveArrowToBean()
    {
        Destroy(this.mg_ArrowToBean);
    }

    public void v_RemoveArrowToCow()
    {
        Destroy(this.mg_ArrowToCow);
    }

    public void v_MoveBeanToGF()
    {
        mg_ArrowToBean.transform.position = new Vector3(5.5f, 0, 0);
    }

    public void v_MoveGFToBean()
    {
        mg_ArrowToBean.transform.position = new Vector3(6.1f, -3, 0);


    }

    public void v_DragCow()
    {
        mb_DragCowFlag = true;
    }

    public void v_NotDragCow()
    {
        mb_DragCowFlag = false;
    }

    public void v_DragBeanFlagTrue()
    {
        mb_DragBeanFlag = true;
    }

    public void v_DragBeanFalgFalse()
    {
        mb_DragBeanFlag = false;
    }
}
