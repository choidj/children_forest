/*
 * - Name : Jack9_EventController.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�9 - �̺�Ʈ ���� ��ũ��Ʈ
 *            �������� �̺�Ʈ�� �Ѱ������� �����ϱ� ���� ��ũ��Ʈ
 * 
 *            
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-14 : ���� �Ϸ�
 *            
 *            
 *            
 * 
 * -Variable 
 * 
 * ���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
 * mg_ScriptManager
 * 
 * ��Ӵ� ��ǳ�� ���� ������Ʈ
 * mg_GenMotherSpeechBubble
 * mg_MotherSpeech
 * 
 * �� ��ǳ�� ���� ������Ʈ
 * mg_GenGiantSpeechBubble
 * mg_JackSpeech
 * 
 * �̺�Ʈ ���� ����
 * mb_EventFlag : �̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
 * mn_EventSequence : �̺�Ʈ ������ �����ϴ� ����
 * 
 * ���콺 �巡�� ���� ������Ʈ
 * mg_Bean
 * 
 * ���콺 Ŭ�� ���� flag
 * StopClickFlag
 * 
 * �̺�Ʈ ����Ȯ���� ���� flag
 * mb_BeanToMother
 * mb_CowToGF
 * 
 * 
 * -Function
 * 
 * Flag ���� �Լ�
 * v_ChangeFlagFalse()
 * v_ChangeFlagTrue()
 * 
 * ���� ��ũ��Ʈ �Լ�
 * v_NextMainScript()
 * v_NoneMainScript()
 * 
 * �̺�Ʈ ��ũ��Ʈ �Լ�
 * v_NextEventScript()
 * v_NoneEventScript()
 * 
 * �� ��ũ��Ʈ �Լ�
 * v_NextJackScript()
 * v_NoneJackScript()
 * 
 * ��Ӵ� ��ũ��Ʈ �Լ�
 * v_NextMotherScript()
 * v_NoneMotherScript()
 * 
 * ��ǳ�� ���� �Լ�
 * v_GenJackSpeechBubble()
 * 
 * ��ǳ�� ���� �Լ�
 * v_RemoveJackSpeechBubble()
 * 
 * 
 * flag true ó�� �Լ�
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack9_EventController : MonoBehaviour
{
    //���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
    GameObject mg_ScriptManager;
    GameObject mg_GenScript;


    //�� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenGiantSpeechBubble;

    //�̺�Ʈ ������ ���� ����
    private bool mb_DontLoopEvent1;
    private bool mb_DontLoopEvent2;
    private bool mb_EventFlag;  //�̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
    private int mn_EventSequence;   //�̺�Ʈ ������ �����ϴ� ����

    public GameObject mg_GiantSpeech;

    //���콺 Ŭ�� ����
    private bool StopClickFlag;

    //�̺�Ʈ������ flag
    private bool IsSackDestroy;


    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ ����
        this.mg_ScriptManager = GameObject.Find("GameDirector");


        //�̺�Ʈ flag
        mb_DontLoopEvent1 = false;
        mb_DontLoopEvent2 = false;
        StopClickFlag = false;
        IsSackDestroy = false;

        //�̺�Ʈ ����
        v_ChangeFlagFalse();
        mn_EventSequence = 0;



        //�̺�Ʈ ����
        v_NextMainScript();

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

        if(mn_EventSequence == 1 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_NoneMainScript();

            v_GenGiantSpeechBubble();
            v_NextGiantScript();
        }
        else if (mn_EventSequence == 2 && this.mb_EventFlag == true)
        {
            v_ChangeFlagFalse();

            v_RemoveGiantSpeechBubble();

            v_NextMainScript();

            mb_DontLoopEvent1 = true;
        }
        else if (mn_EventSequence == 3 && this.mb_EventFlag == true && mb_DontLoopEvent1 == true)
        {
            v_ChangeFlagFalse();

            v_NextEventScript();

            StopClickFlag = true;

            mb_DontLoopEvent1 = false;
            mb_DontLoopEvent2 = true;
        }
        else if (mn_EventSequence == 3 && IsSackDestroy == true && mb_DontLoopEvent2 == true)
        {
            v_ChangeFlagFalse();
            StopClickFlag = false;
            mb_DontLoopEvent2 = false;

            v_NextMainScript();

            this.mg_ScriptManager.GetComponent<Jack9_Gentreasure>().v_GenTreasure();

        }
        else if (mn_EventSequence == 4 && IsSackDestroy == true)
        {
            v_ChangeFlagFalse();


            Debug.Log("�ó����� Ŭ����");

        }
    }


    //Flag ���� �Լ�
    private void v_ChangeFlagFalse()
    {
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue()
    {
        this.mb_EventFlag = true;
    }

    //���� ��ũ��Ʈ �Լ�
    private void v_NextMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MainScript>().v_NoneScript();
    }

    //�̺�Ʈ ��ũ��Ʈ �Լ�
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_MissionScript>().v_NoneScript();
    }
    
    //���� ��ũ��Ʈ �Լ�
    private void v_NextGiantScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NextScript();
    }
    private void v_NoneGiantScript()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NoneScript();
    }
    
    //��ǳ�� ���� �Լ�
    private void v_GenGiantSpeechBubble()
    {
        mg_GenGiantSpeechBubble = Instantiate(mg_GiantSpeech) as GameObject;
        mg_GenGiantSpeechBubble.transform.position = new Vector3(0, 3.3f, 0);
    }

    //��ǳ�� ���� �Լ�
    private void v_RemoveGiantSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack9_GiantScript>().v_NoneScript();
        Destroy(this.mg_GenGiantSpeechBubble);
    }

    public void v_IsSackDestroy()
    {
        IsSackDestroy = true;
    }


}
