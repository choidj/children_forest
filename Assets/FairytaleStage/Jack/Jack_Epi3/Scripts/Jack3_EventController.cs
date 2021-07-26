/*
 * - Name : Jack3_EventController.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드3 - 이벤트 관리 스크립트
 * 게임진행 이벤트를 총괄적으로 관리하기 위한 스크립트
 * 
 * - Update Log -
 * 2021-07-13 : 제작 완료
 * 2021-07-16 : 화살표 기능 추가 및 인코딩형식 변경
 * 2021-07-21 : 주석 변경
 * 2021-07-23 : 음성기능 추가 및 주석 작성
 * 
 * - Variable 
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
 * mb_PlaySound                     씬이 시작되었을때 음성이 한번만 나오게 하기위한 Flag
 * 
 * - Function
 * v_ChangeFlagFalse()              Flag 변경 함수 -> False로 설정
 * v_ChangeFlagTrue()               Flag 변경 함수 -> True로 설정
 * v_NextMainScript()               메인 스크립트 함수 -> 다음 메인 스크립트를 출력
 * v_NoneMainScript()               메인 스크립트 함수 -> 메인 스크립트 내용을 지워 아무것도 출력안되게 설정
 * v_NextEventScript()              이벤트 스크립트 함수 -> 다음 이벤트 스크립트를 출력
 * v_NoneEventScript()              이벤트 스크립트 함수 -> 이벤트 스크립트 내용을 지워 아무것도 출력안되게 설정
 * v_NextJackScript()               잭 스크립트 함수 -> 다음 Jack 스크립트를 출력
 * v_NoneJackScript()               잭 스크립트 함수 -> Jack 스크립트 내용을 지워 아무것도 출력안되게 설정
 * v_NextGFScript()                 할아버지 스크립트 함수 -> 다음 할아버지 스크립트를 출력
 * v_NoneGFScript()                 할아버지 스크립트 함수 -> 할아버지 스크립트 내용을 지워 아무것도 출력안되게 설정
 * v_GenGFSpeechBubble()            말풍선 생성 함수 -> 할아버지 말풍선을 생성
 * v_GenJackSpeechBubble()          말풍선 생성 함수 -> Jack의 말풍선을 생성
 * v_RemoveGFSpeechBubble()         말풍선 삭제 함수 -> 할아버지 말풍선 삭제
 * v_RemoveJackSpeechBubble()       말풍선 삭제 함수 -> Jack의 말풍선 삭제
 * v_TurnOnMouseDrag()              드래그 활성화 -> 소, 콩 오브젝트 드래그 활성화
 * v_DragBean()                     드래그 활성화 -> 콩만 드래그 활성화
 * v_TurnOFFMouseDrag()             드래그 비활성화 -> 소, 콩 오브젝트 드래그 기능 잠금
 * v_BeanToJack()                   flag true 처리 함수 -> 콩이 Jack에게 전달됬다고 Flag값 True로 변경
 * v_CowToGF()                      flag true 처리 함수 -> 소가 할아버지에게 전달됬다고 Flag값 True로 변경
 * v_GenArrowToBean()               화살표 관련 함수 -> 콩을 가르키는 화살표 생성
 * v_GenArrowToCow()                화살표 관련 함수 -> 소를 가르키는 화살표 생성
 * v_GenArrowToGF()                 화살표 관련 함수 -> 할아버지를 가르키는 화살표 생성
 * v_GenArrowToJack()               화살표 관련 함수 -> Jack을 가르키는 화살표 생성
 * v_RemoveArrowToGF()              화살표 관련 함수 -> 할아버지를 가르키는 화살표 삭제
 * v_RemoveArrowToJack()            화살표 관련 함수 -> Jack을 가르키는 화살표 삭제
 * v_RemoveArrowToBean()            화살표 관련 함수 -> 콩을 가르키는 화살표 삭제
 * v_RemoveArrowToCow()             화살표 관련 함수 -> 소를 가르키는 화살표 삭제
 * v_DragCow()                      드래그 관련 함수 -> 소가 드래그 상태임을 나타내는 Flag값 True
 * v_NotDragCow()                   드래그 관련 함수 -> 소가 드래그 상태임을 나타내는 Flag값 False
 * v_DragBeanFlagTrue()             드래그 관련 함수 -> 콩이 드래그 상태임을 나타내는 Flag값 True
 * v_DragBeanFalgFalse()            드래그 관련 함수 -> 콩이 드래그 상태임을 나타내는 Flag값 False
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
    VoiceManager mvm_playVoice;                                                                                // 씬이 시작되었을때 음성이 한번만 나오게 하기위한 Flag

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
    private bool mb_PlaySound;                                                                      // 처음 씬이 실행될때 음성이 한번만 나오기 위한 Flag
    
    #endregion

    void Start(){
        // 변수를 오브젝트 연결하는 부분
        this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");
        this.mg_Cow = GameObject.Find("Jack3_Cow");
        this.mg_Bean = GameObject.Find("Jack3_Bean");
        this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

        // Flag값 False로 초기화
        mb_BeanToJack = false;
        mb_CowToGF = false;
        mb_DragCowFlag = false;
        mb_DragBeanFlag = false;
        mb_PlaySound = false;
        v_ChangeFlagFalse();

        //첫 화면 설정
        mn_EventSequence = 0;                                                                       // 이벤트 0부터 시작
        v_NextMainScript();                                                                         // 메인 스크립트 출력
        v_TurnOFFMouseDrag();                                                                       // 스크립트 중 드래그되는 상황 방지
    }

    void Update(){
        if (Input.GetMouseButtonDown(0) && !(mvm_playVoice.isPlaying()) && mvm_playVoice.mb_checkSceneReady)               // 음성이 끝나고 화면을 클릭시 다음으로 넘어감
        {                         
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

            if(this.mg_ArrowToCow == null && mn_EventSequence >= 8 && mb_CowToGF == false )
            {
                v_GenArrowToCow();
            }
            if (this.mg_ArrowToBean == null && mn_EventSequence >= 8 && mb_BeanToJack == false)
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

            if (this.mg_ArrowToCow == null && mn_EventSequence >= 8 && mb_CowToGF == false)
            {
                v_GenArrowToCow();
            }
            if (this.mg_ArrowToBean == null && mn_EventSequence >= 8 && mb_BeanToJack == false)
            {
                v_GenArrowToBean();
            }
        }

        //전체적인 이벤트
        if (mn_EventSequence == 0 && mb_PlaySound == false && mvm_playVoice.mb_checkSceneReady)                // 처음 씬이 실행되면 기본 스크립트 실행
        {
            mb_PlaySound = true;
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        if (mn_EventSequence == 1 && this.mb_EventFlag == true){                                    // 화면을 1번 터치하면 진행
            v_ChangeFlagFalse();                                                                    // 이벤트를 한번만 실행하기위한 flag

            v_NoneMainScript();                                                                     // 이전에 했던스크립트 정리

            v_GenGFSpeechBubble();                                                                  // 스크립트, 말풍선 등 출력
            v_NextGFScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 2 && mb_EventFlag == true){                                    // 화면을 2번 터치하면 진행
            v_ChangeFlagFalse();

            v_RemoveGFSpeechBubble();

            v_NextJackScript();
            v_GenJackSpeechBubble();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 3 && mb_EventFlag == true){                                    // 화면을 3번 터치하여 진행
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_GenGFSpeechBubble();
            v_NextGFScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 4 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_NextGFScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 5 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveGFSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 6 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_NextJackScript();
            v_GenJackSpeechBubble();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 7 && mb_EventFlag == true){
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 8 && mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();
            v_NextEventScript();

            v_TurnOnMouseDrag();

            v_GenArrowToBean();
            v_GenArrowToCow();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
    }

    #region 함수 선언부

    /// <summary>
    /// Flag 변경 함수 - 스토리 관련 이벤트가 한번만 작동되게 하기위한 Flag
    /// </summary>
    private void v_ChangeFlagFalse(){                                                                   
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue(){
        this.mb_EventFlag = true;
    }

    /// <summary>
    /// 스크립트 관련 함수
    /// </summary>
    private void v_NextMainScript(){                                                                        // 다음 메인 스크립트를 출력
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript(){                                                                        // 메인 스크립트 내용을 지워 아무것도 출력안되게 설정
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NoneScript();
    }
    private void v_NextEventScript(){                                                                       // 다음 이벤트 스크립트 출력
        this.mg_ScriptManager.GetComponent<Jack3_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript(){                                                                       // 이벤트 스크립트 내용을 지워 아무것도 출력안되게 설정
        this.mg_ScriptManager.GetComponent<Jack3_MissionScript>().v_NoneScript();
    }
    private void v_NextJackScript(){                                                                        // 다음 Jack 스크립트 출력
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript(){                                                                        // Jack 스크립트 내용을 지워 아무것도 출력안되게 설정
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
    }
    private void v_NextGFScript(){                                                                          // 다음 할아버지 스크립트 출력
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NextScript();
    }
    private void v_NoneGFScript(){                                                                          // 할아버지 스크립트 내용을 지워 아무것도 출력안되게 설정
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
    }

    /// <summary>
    /// 말풍선 관련 함수
    /// </summary>
    private void v_GenGFSpeechBubble(){                                                                     // 할아버지 말풍선을 생성
        mg_GenGFSpeechBubble = Instantiate(mg_GFSpeech) as GameObject;
        mg_GenGFSpeechBubble.transform.position = new Vector3(4, 0.5f, 0);
    }
    private void v_GenJackSpeechBubble(){                                                                   // 잭의 말풍선을 생성
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-0.5f, -1, 0);
    }
    private void v_RemoveGFSpeechBubble(){                                                                  // 할아버지 말풍선 삭제
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
        Destroy(this.mg_GenGFSpeechBubble);
    }
    private void v_RemoveJackSpeechBubble(){                                                                // Jack 말풍선 삭제
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

    /// <summary>
    /// 드래그 기능 관련 함수
    /// </summary>
    private void v_TurnOnMouseDrag()                                                                        // 드래그 활성화
    {
        this.mg_Cow.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
    }
    public void v_DragBean()                                                                                // 콩 드래그 가능하게 설정
    {
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagTrue();
    }
    private void v_TurnOFFMouseDrag()                                                                       // 드래그 기능 잠금
    {
        this.mg_Cow.GetComponent<Jack3_MouseDrag>().v_ChangeFlagFalse();
        this.mg_Bean.GetComponent<Jack3_MouseDrag>().v_ChangeFlagFalse();
    }

    /// <summary>
    /// 오브젝트가 잘 전달 되었는지 확인하기위한 Flag값 변경
    /// </summary>
    public void v_BeanToJack()                                                                              // 콩이 Jack에게 전달됬다고 Flag값 True로 변경
    {
        mb_BeanToJack = true;
    }
    public void v_CowToGF()                                                                                 // 소가 할아버지에게 전달되었다고 Flag값 True로 변경
    {
        mb_CowToGF = true;
    }

    /// <summary>
    /// 화살표 관련 함수
    /// </summary>
    public void v_GenArrowToBean()                                                                          // 콩을 가르키는 화살표 생성
    {
        if (mg_ArrowToBean == null)
        {
            mg_ArrowToBean = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToBean.transform.position = new Vector3(3.5f, -2.5f, 0);
        }
    }
    public void v_GenArrowToCow()                                                                           // 소를 가르키는 화살표 생성
    {
        if (mg_ArrowToCow == null)
        {
            mg_ArrowToCow = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToCow.transform.position = new Vector3(-3.5f, -1, 0);
            mg_ArrowToCow.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void v_GenArrowToGF()                                                                            // 할아버지를 가르키는 화살표 생성
    {
        if (mg_ArrowToGF == null)
        {
            mg_ArrowToGF = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToGF.transform.position = new Vector3(5.5f, 0, 0);
        }
    }
    public void v_GenArrowToJack()                                                                          // Jack을 가르키는 화살표 생성
    {
        if (mg_ArrowToJack == null)
        {
            mg_ArrowToJack = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToJack.transform.position = new Vector3(-1.5f, -2, 0);
            mg_ArrowToJack.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void v_RemoveArrowToGF()                                                                         // 할아버지를 가르키는 화살표 삭제
    {
        if(mg_ArrowToGF != null)
        {
            Destroy(mg_ArrowToGF);
        }
    }
    public void v_RemoveArrowToJack()                                                                       // Jack을 가르키는 화살표 삭제
    {
        if (mg_ArrowToJack != null)
        {
            Destroy(mg_ArrowToJack);
        }
    }
    public void v_RemoveArrowToBean()                                                                       // 콩을 가르키는 화살표 삭제
    {
        if(this.mg_ArrowToBean != null)
        {
            Destroy(this.mg_ArrowToBean);
        }
    }
    public void v_RemoveArrowToCow()                                                                        // 소를 가르키는 화살표 삭제
    {
        if (this.mg_ArrowToCow)
        {
            Destroy(this.mg_ArrowToCow);
        }
    }

    /// <summary>
    /// 드래그 상태인지 확인하기 위한 Flag
    /// </summary>
    public void v_DragCow()                                                                                 // 소가 드래그 상태임을 나타내는 Flag값 True
    {
        mb_DragCowFlag = true;
    }
    public void v_NotDragCow()                                                                              // 소가 드래그 상태임을 나타내는 Flag값 False
    {
        mb_DragCowFlag = false;
    }
    public void v_DragBeanFlagTrue()                                                                        // 콩이 드래그 상태임을 나타내는 Flag값 True
    {
        mb_DragBeanFlag = true;
    }
    public void v_DragBeanFalgFalse()                                                                       // 콩이 드래그 상태임을 나타내는 Flag값 False
    {
        mb_DragBeanFlag = false;
    }

    #endregion
}
