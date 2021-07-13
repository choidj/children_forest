/*
 * - Name : Jack3_EventController.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�3 - �̺�Ʈ ���� ��ũ��Ʈ
 *            �������� �̺�Ʈ�� �Ѱ������� �����ϱ� ���� ��ũ��Ʈ
 * 
 *            
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-13 : ���� �Ϸ�
 *            
 *            
 *            
 * 
 * -Variable 
 * 
 * ���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
 * mg_ScriptManager
 * 
 * �Ҿƹ��� ��ǳ�� ���� ������Ʈ
 * mg_GenGFSpeechBubble
 * mg_GFSpeech
 * 
 * �� ��ǳ�� ���� ������Ʈ
 * mg_GenJackSpeechBubble
 * mg_JackSpeech
 * 
 * �̺�Ʈ ���� ����
 * mb_EventFlag : �̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
 * mn_EventSequence : �̺�Ʈ ������ �����ϴ� ����
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
 * �� ��ũ��Ʈ �Լ�
 * v_NextJackScript()
 * v_NoneJackScript()
 * 
 * �Ҿƹ��� ��ũ��Ʈ �Լ�
 * v_NextGFScript()
 * v_NoneGFScript()
 * 
 * ��ǳ�� ���� �Լ�
 * v_GenGFSpeechBubble()
 * v_GenJackSpeechBubble()
 * 
 * ��ǳ�� ���� �Լ�
 * v_RemoveGFSpeechBubble()
 * v_RemoveJackSpeechBubble()
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jack3_EventController : MonoBehaviour
{
    //���� ���� ������Ʈ�� �����ϱ� ���� ������Ʈ
    GameObject mg_ScriptManager;

    //�Ҿƹ��� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenGFSpeechBubble;
    public GameObject mg_GFSpeech;

    //�� ��ǳ�� ���� ������Ʈ
    GameObject mg_GenJackSpeechBubble;
    public GameObject mg_JackSpeech;

    //�̺�Ʈ ������ ���� ����
    private bool mb_EventFlag;  //�̺�Ʈ�� �ѹ��� �۵��ϱ� ���� flag
    private int mn_EventSequence;   //�̺�Ʈ ������ �����ϴ� ����


    void Start(){
        this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");

        v_ChangeFlagFalse();
        mn_EventSequence = 0;

        v_NextMainScript();
    }


    void Update(){
        if (Input.GetMouseButtonDown(0)){
            mn_EventSequence += 1;
            v_ChangeFlagTrue();
        }

        if(mn_EventSequence == 1 && this.mb_EventFlag == true){
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
    }

    //Flag ���� �Լ�
    private void v_ChangeFlagFalse(){
        this.mb_EventFlag = false;
    }
    private void v_ChangeFlagTrue(){
        this.mb_EventFlag = true;
    }

    //���� ��ũ��Ʈ �Լ�
    private void v_NextMainScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NextScript();
    }
    private void v_NoneMainScript(){
        this.mg_ScriptManager.GetComponent<Jack3_MainScript>().v_NoneScript();
    }

    //�� ��ũ��Ʈ �Լ�
    private void v_NextJackScript(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NextScript();
    }
    private void v_NoneJackScript(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
    }

    //�Ҿƹ��� ��ũ��Ʈ �Լ�
    private void v_NextGFScript(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NextScript();
    }
    private void v_NoneGFScript(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
    }

    //��ǳ�� ���� �Լ�
    private void v_GenGFSpeechBubble(){
        mg_GenGFSpeechBubble = Instantiate(mg_GFSpeech) as GameObject;
        mg_GenGFSpeechBubble.transform.position = new Vector3(5.1f, -0.5f, 0);
    }
    private void v_GenJackSpeechBubble(){
        mg_GenJackSpeechBubble = Instantiate(mg_JackSpeech) as GameObject;
        mg_GenJackSpeechBubble.transform.position = new Vector3(-1.3f, -0.5f, 0);
    }

    //��ǳ�� ���� �Լ�
    private void v_RemoveGFSpeechBubble(){
        this.mg_ScriptManager.GetComponent<Jack3_GFScript>().v_NoneScript();
        Destroy(this.mg_GenGFSpeechBubble);
    }
    private void v_RemoveJackSpeechBubble(){
        this.mg_ScriptManager.GetComponent<Jack3_JackScript>().v_NoneScript();
        Destroy(this.mg_GenJackSpeechBubble);
    }

}
