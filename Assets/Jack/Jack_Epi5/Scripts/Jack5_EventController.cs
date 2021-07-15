/*
 * - Name : Jack5_EventController.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�4 - �̺�Ʈ ���� ��ũ��Ʈ
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
 * �� ��ǳ�� ���� ������Ʈ
 * mg_GenJackSpeechBubble
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
 * 
 * ��ǳ�� ���� �Լ�
 * v_GenJackSpeechBubble()
 * 
 * ��ǳ�� ���� �Լ�
 * v_RemoveJackSpeechBubble()
 * 
 * �巡�� Ȱ��ȭ
 * v_TurnOnMouseDrag()
 * 
 * �巡�� ��Ȱ��ȭ
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
    //���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
    GameObject mg_ScriptManager;

    //�� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //�̺�Ʈ ������ ���� ����
    private bool mb_EventFlag;  //�̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
    private int mn_EventSequence;   //�̺�Ʈ ������ �����ϴ� ����

    //���콺 �巡�� ���� ������Ʈ
    GameObject mg_Jack;

    //���콺 Ŭ�� ����
    private bool StopClickFlag;

    //�̺�Ʈ ����Ȯ���� ���� flag




    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ ����
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mg_Jack = GameObject.Find("Jack");

        //�̺�Ʈ flag
        StopClickFlag = false;

        //�̺�Ʈ ����
        v_ChangeFlagFalse();
        mn_EventSequence = 0;


        //�̺�Ʈ ����
        v_NextMainScript();

        //�巡�� ���� �Լ�
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
        this.mg_ScriptManager.GetComponent<Jack5_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MainScript>().v_NoneScript();
    }

    //�̺�Ʈ ��ũ��Ʈ �Լ�
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_MissionScript>().v_NoneScript();
    }
    
    //�� ��ũ��Ʈ �Լ�
    private void v_NextJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NoneScript();
    }

    //��ǳ�� ���� �Լ�
    private void v_GenJackSpeechBubble()
    {
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-3, -1, 0);
    }

    //��ǳ�� ���� �Լ�
    private void v_RemoveJackSpeechBubble()
    {
        this.mg_ScriptManager.GetComponent<Jack5_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

    //�巡�� Ȱ��ȭ
    private void v_TurnOnMouseDrag()
    {
        this.mg_Jack.GetComponent<Jack5_MouseDrag>().v_ChangeFlagTrue();
    }

    //�巡�� ��Ȱ��ȭ
    private void v_TurnOFFMouseDrag()
    {
        this.mg_Jack.GetComponent<Jack5_MouseDrag>().v_ChangeFlagFalse();
    }
}
