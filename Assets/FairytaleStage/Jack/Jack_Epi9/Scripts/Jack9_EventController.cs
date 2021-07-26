/*
 * - Name : Jack9_EventController.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드9 - 이벤트 관리 스크립트
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
 * mg_GenGiantSpeechBubble
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
 * v_GenJackSpeechBubble()
 * 
 * 말풍선 삭제 함수
 * v_RemoveJackSpeechBubble()
 * 
 * 
 * flag true 처리 함수
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Jack9_EventController : MonoBehaviour
{
    //게임 디렉터 오브젝트에 접근하기 위한 오브젝트
    GameObject mg_ScriptManager;
    GameObject mg_GenScript;
    GameObject mg_Sack;
    VoiceManager mvm_playVoice;

    //잭 말풍선 관련 오브젝트
    GameObject mg_GenGiantSpeechBubble;

    //이벤트 관리를 위한 변수
    private bool mb_DontLoopEvent1;
    private bool mb_DontLoopEvent2;
    private bool mb_EventFlag;  //이벤트를 한번만 작동하기 위한 flag
    private int mn_EventSequence;   //이벤트 순서를 관리하는 변수

    public GameObject mg_GiantSpeech;
    private bool mb_PlaySound;

    //마우스 클릭 제한
    private bool StopClickFlag;

    //이벤트를위한 flag
    private bool IsSackDestroy;

    //화살표 오브젝트
    GameObject mg_Arrow1;
    GameObject mg_Arrow2;
    public GameObject mg_ArrowPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //오브젝트 연결
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        this.mg_Sack = GameObject.Find("Sack");
        //이벤트 flag
        mb_DontLoopEvent1 = false;
        mb_DontLoopEvent2 = false;
        StopClickFlag = false;
        IsSackDestroy = false;

        //이벤트 관련
        v_ChangeFlagFalse();
        mn_EventSequence = 0;


        //이벤트 시작
        v_NextMainScript();

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0) && mvm_playVoice.mb_checkSceneReady)
        {
            if (StopClickFlag == false && !(mvm_playVoice.isPlaying()))
            {
                mn_EventSequence += 1;
            }
            v_ChangeFlagTrue();
        }

        if (mn_EventSequence == 0 && mb_PlaySound == false && mvm_playVoice.mb_checkSceneReady)                    // 처음 씬이 실행되면 기본 스크립트 실행
        {
            mb_PlaySound = true;
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 1 && this.mb_EventFlag == true && !(mvm_playVoice.isPlaying()) && mb_PlaySound == true)
        {
            v_ChangeFlagFalse();
            mb_PlaySound = false;
            v_NoneMainScript();

            v_GenGiantSpeechBubble();
            v_NextGiantScript();
            mvm_playVoice.playVoice(mn_EventSequence);
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true && mb_PlaySound == false)
        {
            v_ChangeFlagFalse();
            mb_PlaySound = true;
            v_RemoveGiantSpeechBubble();

            v_NextMainScript();
            mvm_playVoice.playVoice(mn_EventSequence);
            mb_DontLoopEvent1 = true;
        }
        else if (mn_EventSequence == 3 && this.mb_EventFlag == true && mb_DontLoopEvent1 == true)
        {
            v_ChangeFlagFalse();

            v_NextEventScript();
            mg_Sack.GetComponent<Jack9_Sack>().ChangSackFlagTrue();
            StopClickFlag = true;

            mb_DontLoopEvent1 = false;
            mb_DontLoopEvent2 = true;
            mvm_playVoice.playVoice(mn_EventSequence);
            v_GenArrowToSack1();
            v_GenArrowToSack2();
        }
        else if (mn_EventSequence == 3 && IsSackDestroy == true && mb_DontLoopEvent2 == true)
        {
            v_ChangeFlagFalse();
            StopClickFlag = false;
            mb_DontLoopEvent2 = false;

            v_NextMainScript();

            this.mg_ScriptManager.GetComponent<Jack9_Gentreasure>().v_GenTreasure();
            mvm_playVoice.playVoice(mn_EventSequence+1);
            v_RemoveArrowToSack1();
            v_RemoveArrowToSack2();
        }
        else if (mn_EventSequence == 4 && IsSackDestroy == true)
        {
            v_ChangeFlagFalse();


            SceneManager.LoadScene("Jack_Epi10");

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
        this.mg_ScriptManager.GetComponent<Jack9_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MainScript>().v_NoneScript();
    }

    //이벤트 스크립트 함수
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MissionScript>().v_NoneScript();
    }
    
    //거인 스크립트 함수
    private void v_NextGiantScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NextScript();
    }
    private void v_NoneGiantScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NoneScript();
    }
    
    //말풍선 생성 함수
    private void v_GenGiantSpeechBubble()
    {
        mg_GenGiantSpeechBubble = Instantiate(mg_GiantSpeech) as GameObject;
        mg_GenGiantSpeechBubble.transform.position = new Vector3(0, 3.3f, 0);
    }

    //말풍선 삭제 함수
    private void v_RemoveGiantSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NoneScript();
        Destroy(this.mg_GenGiantSpeechBubble);
    }
    
    public void v_IsSackDestroy()
    {
        IsSackDestroy = true;
    }

    public void v_GenArrowToSack1()
    {
        if (mg_Arrow1 == null)
        {
            mg_Arrow1 = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_Arrow1.transform.position = new Vector3(-0.87f, -0.57f, 0);
        }
    }
    public void v_GenArrowToSack2()
    {
        if (mg_Arrow2 == null)
        {
            mg_Arrow2 = Instantiate(mg_ArrowPrefab) as GameObject;
            mg_Arrow2.transform.position = new Vector3(5, -0.57f, 0);
            mg_Arrow2.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void v_RemoveArrowToSack1()
    {
        if (mg_Arrow1 != null)
        {
            Destroy(mg_Arrow1);
        }
    }
    public void v_RemoveArrowToSack2()
    {
        if (mg_Arrow2 != null)
        {
            Destroy(mg_Arrow2);
        }
    }
}
