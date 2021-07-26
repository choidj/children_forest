/*
 * - Name : Jack4_EventController.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드4 - 이벤트 관리 스크립트
 * 게임진행 이벤트를 총괄적으로 관리하기 위한 스크립트
 * 
 * - Update Log -
 * 2021-07-14 : 제작 완료
 * 2021-07-16 : 화살표 기능 추가 및 인코딩형식 변경
 * 2021-07-23 : 음성기능 추가 및 주석 작성
 * 
 * - Variable 
 * mg_ScriptManager                 오브젝트 연결을 위한 변수 -> 게임 디렉터 오브젝트에 접근하기 위한 변수
 * mg_Mother                        오브젝트 연결을 위한 변수 -> 어머니 오브젝트에 접근하기 위한 변수
 * mvm_playVoice                               오브젝트 연결을 위한 변수 -> VoiceManager 오브젝트에 접근하기 위한 변수
 * mg_Bean                          오브젝트 연결을 위한 변수 -> 콩 오브젝트 연결하기 위한 변수
 * mg_GenMotherSpeechBubble         말풍선 관련 변수 -> 어머니 말풍선 프리팹과 연결을 위한 변수 
 * mg_MotherSpeech                  말풍선 관련 변수 -> 어머니 말풍선 프리팹과 연결을 위한 변수
 * mg_GenJackSpeechBubble           말풍선 관련 변수 -> Jack 말풍선 프리팹과 연결을 위한 변수
 * mg_JackSpeech                    말풍선 관련 변수 -> Jack 말풍선 프리팹과 연결을 위한 변수
 * mb_DontLoopEvent1                이벤트 관리를 위한 변수 -> 같은 이벤트 반복을 피하기 위한 Flag
 * mb_DontLoopEvent2                이벤트 관리를 위한 변수 -> 같은 이벤트 반복을 피하기 위한 Flag
 * mb_EventFlag                     이벤트 관리를 위한 변수 -> 같은 이벤트 반복을 피하기 위한 Flag
 * mn_EventSequence                 이벤트 관리를 위한 변수 -> 이벤트 순서를 관리하는 변수
 * mb_IsDragBean                    이벤트 관리를 위한 변수 -> 콩 오브젝트가 드래그중인지 확인하기위한 Flag
 * mb_StopClickFlag                 이벤트 관리를 위한 변수 -> 클릭으로 다음 이벤트로 넘어가는 것을 방지하기위한 Flag
 * mb_BeanToMother                  이벤트 관리를 위한 변수 -> 콩이 어머니에게 전달되었는지 확인하기위한 Flag
 * mb_BeanToWindow                  이벤트 관리를 위한 변수 -> 콩이 창문에게 전달되었는지 확인하기위한 Flag
 * mb_PlaySound                     이벤트 관리를 위한 변수 -> 처음 씬이 실행될때 음성이 한번만 나오기 위한 Flag
 * mg_ArrowToBean                   화살표 관련 변수 -> Jack의 콩을 가르키는 변수
 * mg_ArrowToMother                 화살표 관련 변수 -> 어머니를 가르키는 변수
 * mg_ArrowToBean2                  화살표 관련 변수 -> 어머니의 콩을 가르키는 변수
 * mg_ArrowToWindow                 화살표 관련 변수 -> 창문을 가르키는 화살표 변수
 * mg_ArrowPrefab                   화살표 관련 변수 -> 화살표 프리팹 연결을 위한 변수
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
 * v_NextMotherScript()             어머니 스크립트 함수 -> 다음 어머니 스크립트를 출력
 * v_NoneMotherScript()             어머니 스크립트 함수 -> 어머니 스크립트 내용을 지워 아무것도 출력안되게 설정
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jack4_EventController : MonoBehaviour
{
    #region 변수 선언부

    // 오브젝트 연결을 위한 변수 선언
    GameObject mg_ScriptManager;                                                                    // 게임 디렉터 오브젝트에 접근하기 위한 변수
    GameObject mg_Mother;                                                                           // 어머니 오브젝트에 접근하기 위한 변수
    VoiceManager mvm_playVoice;                                                                     // VoiceManager 오브젝트에 접근하기 위한 변수
    GameObject mg_Bean;                                                                             // 콩 오브젝트에 접근하기 위한 변수
    private SoundManager msm_soundManager;                                                          // SoundManager 오브젝트에 접근하기 위한 변수

    // 말풍선 관련 변수
    GameObject mg_GenMotherSpeechBubble;                                                            // 어머니 말풍선 오브젝트 조작을 위한 변수
    public GameObject mg_MotherSpeech;                                                              // 어머니 말풍선 프리팹과 연결을 위한 변수
    GameObject mg_GenJackSpeechBubble;                                                              // Jack 말풍선 오브젝트 조작을 위한 변수
    public GameObject mg_JackSpeech;                                                                // Jack 말풍선 프리팹과 연결을 위한 변수

    // 이벤트 관리를 위한 변수
    private bool mb_DontLoopEvent1;                                                                 // 같은 이벤트 반복을 피하기 위한 Flag
    private bool mb_DontLoopEvent2;                                                                 // 같은 이벤트 반복을 피하기 위한 Flag
    private bool mb_EventFlag;                                                                      // 같은 이벤트 반복을 피하기 위한 Flag
    private int mn_EventSequence;                                                                   // 이벤트 순서를 관리하는 변수
    private bool mb_IsDragBean;                                                                     // 콩 오브젝트가 드래그중인지 확인하기위한 Flag
    private bool mb_StopClickFlag;                                                                  // 클릭으로 다음 이벤트로 넘어가는 것을 방지하기위한 Flag
    private bool mb_BeanToMother;                                                                   // 콩이 어머니에게 전달되었는지 확인하기위한 Flag
    private bool mb_BeanToWindow;                                                                   // 콩이 창문에게 전달되었는지 확인하기위한 Flag
    private bool mb_PlaySound;                                                                      // 처음 씬이 실행될때 음성이 한번만 나오기 위한 Flag
    
    // 화살표 관련 변수
    GameObject mg_ArrowToBean;                                                                      // Jack의 콩을 가르키는 화살표 변수
    GameObject mg_ArrowToMother;                                                                    // 어머니를 가르키는 화살표 변수
    GameObject mg_ArrowToBean2;                                                                     // 어머니의 콩을 가르키는 화살표 변수
    GameObject mg_ArrowToWindow;                                                                    // 창문을 가르키는 화살표 변수
    public GameObject mg_ArrowPrefab;                                                               // 화살표 프리팹 연결을 위한 변수

    #endregion

    void Start()
    {
        //오브젝트 연결
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mg_Bean = GameObject.Find("Bean");
        this.mg_Mother = GameObject.Find("Mother");
        this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //이벤트 flag False로 초기화
        mb_DontLoopEvent1 = false;
        mb_DontLoopEvent2 = false;
        mb_BeanToMother = false;
        mb_StopClickFlag = false;
        mb_BeanToWindow = false;
        mb_PlaySound = false;
        mb_IsDragBean = false;

        // 다음 이벤트 시작
        mn_EventSequence = 0;
        v_ChangeFlagFalse();
        v_NextMotherScript();
        v_GenMotherSpeechBubble();
        v_TurnOFFMouseDrag();                                                                           // 대사진행중 마우스 드래그기능 잠금
    }

    void Update()
    {
        // 오브젝트가 전달되었는지 확인하여 화살표 표시
        if (mb_IsDragBean == true && mb_BeanToMother == false)
        {
            v_RemoveArrowToBean();
            v_GenArrowToMom();
        }
        else if (mb_IsDragBean == false && mn_EventSequence == 2 && mb_BeanToMother == false)
        {
            v_GenArrowToBean();

            v_RemoveArrowToMom();
        }
        else if (mb_IsDragBean == true && mb_BeanToMother == true && mn_EventSequence >= 6)
        {
            v_RemoveArrowToBean2();
            v_GenArrowToWindow();
        }
        else if(mb_IsDragBean == false && mb_BeanToMother == true && mn_EventSequence >=6)
        {
            v_GenArrowToBean2();
            v_RemoveArrowToWindow();
        }

        if (Input.GetMouseButtonDown(0) && !(mvm_playVoice.isPlaying()) && mvm_playVoice.mb_checkSceneReady)                                           // 화면을 클릭하면 다음이벤트가 진행되도록 설정
        {
            if(mb_StopClickFlag == false)
            {
                mn_EventSequence += 1;
            }
            v_ChangeFlagTrue();
        }

        // 메인 이벤트 진행
        if (mn_EventSequence == 0 && mb_PlaySound == false && mvm_playVoice.mb_checkSceneReady)                    // 처음 씬이 실행되면 기본 스크립트 실행
        {
            mb_PlaySound = true;
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 1 && this.mb_EventFlag == true)                                    // 화면이 한번 클릭되면 다음 이벤트 진행
        {
            v_ChangeFlagFalse();

            v_RemoveMotherSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_DontLoopEvent1 == false)      // 화면이 한번 클릭되면 다음 이벤트 진행
        {
            v_ChangeFlagFalse();

            v_NextEventScript();

            v_TurnOnMouseDrag();

            mb_DontLoopEvent1 = true;
            mb_StopClickFlag = true;
            mvm_playVoice.playVoice(mn_EventSequence);
            v_GenArrowToBean();
        }
        else if (mn_EventSequence == 2 && mb_BeanToMother == true && !(mvm_playVoice.isPlaying()) && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneEventScript();

            v_GenJackSpeechBubble();
            v_NextJackScript();
            mvm_playVoice.playVoice(3);
            mb_StopClickFlag = false;
            v_TurnOFFMouseDrag();

            v_RemoveArrowToBean();
            v_RemoveArrowToMom();

        }
        else if (mn_EventSequence == 3 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveJackSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(4);
        }
        else if (mn_EventSequence == 4 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_GenMotherSpeechBubble();
            v_NextMotherScript();
            mvm_playVoice.playVoice(5);

            this.mg_Mother.GetComponent<Jack4_Mother>().ChangeMotherAngry();
        }
        else if (mn_EventSequence == 5 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveMotherSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(6);
        }
        else if (mn_EventSequence == 6 && this.mb_EventFlag == true && mb_DontLoopEvent2 == false)
        {
            v_ChangeFlagFalse();

            v_NextEventScript();

            v_TurnOnMouseDrag();
            mb_StopClickFlag = false;
            mb_DontLoopEvent2 = true;
            mvm_playVoice.playVoice(7);

            v_GenArrowToBean2();
        }

        if(mb_BeanToWindow == true)                                                                     // 콩이 창문에게 전달되면 다음 씬으로 이동
        {
            if(mb_PlaySound == true)
            {
                mb_PlaySound = false;
                msm_soundManager.playSound(1);
            }
            Invoke("NextScene", 1f);
            //SceneManager.LoadScene("Jack_Epi5");
        }
    }

    #region 함수 선언부

    /// <summary>
    /// Flag 변경 함수
    /// </summary>
    private void v_ChangeFlagFalse()                                                                    // Flag값 True
    {
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue()                                                                     // Flag값 False
    {
        this.mb_EventFlag = true;
    }

    /// <summary>
    /// 스크립트 관련 함수
    /// </summary>
    private void v_NextMainScript()                                                                     // 다음 메인 스크립트를 출력
    {
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()                                                                     // 메인 스크립트 내용을 지워 아무것도 출력안되게 설정
    {
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NoneScript();
    }
    private void v_NextEventScript()                                                                    // 다음 이벤트 스크립트를 출력
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()                                                                    // 이벤트 스크립트 내용을 지워 아무것도 출력안되게 설정
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NoneScript();
    }
    private void v_NextJackScript()                                                                     // 다음 Jack 스크립트를 출력
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript()                                                                     // Jack 스크립트 내용을 지워 아무것도 출력안되게 설정
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
    }
    private void v_NextMotherScript()                                                                   // 다음 어머니 스크립트를 출력
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NextScript();
    }
    private void v_NoneMotherScript()                                                                   // 어머니 스크립트 내용을 지워 아무것도 출력안되게 설정
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
    }

    /// <summary>
    /// 말풍선 관련 함수
    /// </summary>
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

    public void v_GenArrowToBean()
    {
        if (mg_ArrowToBean == null)
        {
            mg_ArrowToBean = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToBean.transform.position = new Vector3(-2, -3.5f, 0);
            mg_ArrowToBean.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void v_GenArrowToMom()
    {
        if (mg_ArrowToMother == null)
        {
            mg_ArrowToMother = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToMother.transform.position = new Vector3(3, 0.5f, 0);
            mg_ArrowToMother.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void v_GenArrowToBean2()
    {
        if (mg_ArrowToBean2 == null)
        {
            mg_ArrowToBean2 = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToBean2.transform.position = new Vector3(3.5f, -2.7f, 0);
            mg_ArrowToBean2.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void v_GenArrowToWindow()
    {
        if (mg_ArrowToWindow == null)
        {
            mg_ArrowToWindow = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_ArrowToWindow.transform.position = new Vector3(4.8f, 4, 0);
            mg_ArrowToWindow.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void v_RemoveArrowToBean()
    {
        if (mg_ArrowToBean != null)
        {
            Destroy(mg_ArrowToBean);
        }
    }
    public void v_RemoveArrowToMom()
    {
        if (mg_ArrowToMother != null)
        {
            Destroy(mg_ArrowToMother);
        }
    }
    public void v_RemoveArrowToBean2()
    {
        if (mg_ArrowToBean2 != null)
        {
            Destroy(mg_ArrowToBean2);
        }
    }
    public void v_RemoveArrowToWindow()
    {
        if (mg_ArrowToWindow != null)
        {
            Destroy(mg_ArrowToWindow);
        }
    }

    public void DragFalgTrue()
    {
        mb_IsDragBean = true;
    }

    public void DragFalgFalse()
    {
        mb_IsDragBean = false;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Jack_Epi5");
    }
    #endregion
}
