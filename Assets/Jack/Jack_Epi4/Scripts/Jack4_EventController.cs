/*
 * - Name : Jack4_EventController.cs
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
 * ��Ӵ� ��ǳ�� ���� ������Ʈ
 * mg_GenMotherSpeechBubble
 * mg_MotherSpeech
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
 * v_GenMotherSpeechBubble()
 * v_GenJackSpeechBubble()
 * 
 * ��ǳ�� ���� �Լ�
 * v_RemoveMotherSpeechBubble()
 * v_RemoveJackSpeechBubble()
 * 
 * �巡�� Ȱ��ȭ
 * v_TurnOnMouseDrag()
 * 
 * �巡�� ��Ȱ��ȭ
 * v_TurnOFFMouseDrag()
 * 
 * flag true ó�� �Լ�
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
    //���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
    GameObject mg_ScriptManager;

    //��Ӵ� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenMotherSpeechBubble;
    public GameObject mg_MotherSpeech;

    //�� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //�̺�Ʈ ������ ���� ����
    private bool mb_DontLoopEvent1;
    private bool mb_DontLoopEvent2;
    private bool mb_EventFlag;  //�̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
    private int mn_EventSequence;   //�̺�Ʈ ������ �����ϴ� ����

    //���콺 �巡�� ���� ������Ʈ
    GameObject mg_Bean;

    //���콺 Ŭ�� ����
    private bool StopClickFlag;

    //�̺�Ʈ ����Ȯ���� ���� flag
    private bool mb_BeanToMother;
    private bool mb_BeanToWindow;





    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ ����
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        this.mg_Bean = GameObject.Find("Bean");

        //�̺�Ʈ flag
        mb_DontLoopEvent1 = false;
        mb_DontLoopEvent2 = false;
        mb_BeanToMother = false;
        StopClickFlag = false;
        mb_BeanToWindow = false;

        //�̺�Ʈ ����
        v_ChangeFlagFalse();
        mn_EventSequence = 0;

        //������Ʈ ���콺 �巡�� ��� �Ұ�
        v_TurnOFFMouseDrag();


        //�̺�Ʈ ����
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
            Debug.Log("���Ǽҵ� Ŭ����");
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
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MainScript>().v_NoneScript();
    }

    //�̺�Ʈ ��ũ��Ʈ �Լ�
    private void v_NextEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NextScript();
    }
    private void v_NoneEventScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MissionScript>().v_NoneScript();
    }

    //�� ��ũ��Ʈ �Լ�
    private void v_NextJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_JackScript>().v_NoneScript();
    }

    //��Ӵ� ��ũ��Ʈ �Լ�
    private void v_NextMotherScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NextScript();
    }
    private void v_NoneMotherScript()
    {
        this.mg_ScriptManager.GetComponent<Jack4_MotherScript>().v_NoneScript();
    }

    //��ǳ�� ���� �Լ�
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

    //��ǳ�� ���� �Լ�
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

    //�巡�� Ȱ��ȭ
    private void v_TurnOnMouseDrag()
    {
        this.mg_Bean.GetComponent<Jack4_MouseDrag>().v_ChangeFlagTrue();
    }

    //�巡�� ��Ȱ��ȭ
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
