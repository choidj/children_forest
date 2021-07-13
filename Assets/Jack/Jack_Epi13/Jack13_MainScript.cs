/*
 * - Name : Jack3_MainScript.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�3 - ���� ��ũ��Ʈ(�����̼�) ���� ��ũ��Ʈ
 * 
 *             -����-
 *            1. ms_ScriptText �� ������� �Է��Ѵ�.
 *            2. �����ڴ� @�� �صξ����� �����ڸ� �߰����ش�.
 *            3. �α׸� ���� ����� ���������� Ȯ���Ѵ�.
 *            4. v_NextScript()�� ���� ���� ��ũ��Ʈ�� ����Ҽ� �ִ�.
 *            5. v_NoneScript()�� ���� ��ũ��Ʈ������ �������� �����Ҽ� �ִ�.
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
 * mg_MainScript : ��ũ��Ʈ�� �����ִ� ���� ��ũ��Ʈ ������Ʈ
 * ms_ScriptText : ��ũ��Ʈ�� ������ �־��ִ� ��Ʈ��
 * msa_SplitText[] : �����ڸ� �������� ���⿡ ������ ����ȴ�.
 * n_i : for���� ����
 * mn_Sequence : ��ũ��Ʈ ���� ���� ����
 * 
 * 
 * -Function
 * v_NoneScript() : ��ũ��Ʈ�� �������� �������ش�.
 * v_NextScript() : ���� ��ũ��Ʈ�� �����ش�.
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack13_MainScript : MonoBehaviour{
    GameObject mg_MainScript;   //������ ��ũ��Ʈ ������Ʈ ����

    //ms_ScriptText �� ������ �Է����ּ���.
    private string ms_ScriptText = "���� �߰��� ������ ������ ���ƾ��.@������ �������� ���� �ڸ� ��¦ �ѾҾ��.@���� ���ž��� �ᳪ�� �ٱ⸦ Ÿ�� �Ʒ��� �Ʒ��� �绡�� ���������.";
    private string[] msa_SplitText;
    private int mn_Sequence;

    void Start(){
        this.mg_MainScript = GameObject.Find("Jack13_Script");   //��ũ��Ʈ ������Ʈ ����

        //���ڿ��� �����ڸ� �������� ������ ����� ���������� Ȯ���Ѵ�.
        msa_SplitText = ms_ScriptText.Split('@');   //�����ڸ� �����ҷ��� �� �κ��� ����
        for (int n_i = 0; n_i < msa_SplitText.Length; n_i++){
            Debug.Log("���� ��ũ��Ʈ[" + n_i + "] : " + msa_SplitText[n_i]);
        }
        mn_Sequence = -1;

        v_NextScript();
    }


    void Update(){

    }

    //��ũ��Ʈ������ �������� ��������
    public void v_NoneScript(){
        this.mg_MainScript.GetComponent<Text>().text = "";
    }

    //���� ��ũ��Ʈ�� �����ش�.
    public void v_NextScript(){
        mn_Sequence += 1;
        if (mn_Sequence < msa_SplitText.Length){
            this.mg_MainScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
        }
        else if(mn_Sequence >= msa_SplitText.Length){
            Debug.Log("���� ��ũ��Ʈ ������� : " + mn_Sequence);
            Debug.Log("���� ��ũ��Ʈ �ִ� �� : " + msa_SplitText.Length);
            Debug.Log("���� ��ũ��Ʈ ũ�� �ʰ�");
        }
    }
}
