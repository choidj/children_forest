/*
 * - Name : Jack4_MotherScript.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�3 - ��Ӵ� ��ũ��Ʈ(���) ���� ��ũ��Ʈ
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
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-14 : ���� �Ϸ�
 *            
 *            
 *            
 *            
 * 
 * -Variable 
 * mg_MotherScript : ��ũ��Ʈ�� �����ִ� ������Ʈ
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

public class Jack4_MotherScript : MonoBehaviour
{
    GameObject mg_MotherScript;   //������ ��ũ��Ʈ ������Ʈ ����

    //ms_ScriptText �� ������ �Է����ּ���.
    private string ms_ScriptText = "��, ���� �ٳ�Դ�?@�����? ���Ҹ� �ܿ� �� �Ѿ˰� �ٲپ��ٴ� �Ŵ�?";
    private string[] msa_SplitText;
    private int mn_Sequence;



    // Start is called before the first frame update
    void Start()
    {
        this.mg_MotherScript = GameObject.Find("MotherScript");   //��ũ��Ʈ ������Ʈ ����

        //���ڿ��� �����ڸ� �������� ������ ����� ���������� Ȯ���Ѵ�.
        msa_SplitText = ms_ScriptText.Split('@');   //�����ڸ� �����ҷ��� �� �κ��� ����
        for (int n_i = 0; n_i < msa_SplitText.Length; n_i++)
        {
            Debug.Log("��Ӵ� ��ũ��Ʈ[" + n_i + "] : " + msa_SplitText[n_i]);
        }
        mn_Sequence = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ũ��Ʈ������ �������� ��������
    public void v_NoneScript()
    {
        this.mg_MotherScript.GetComponent<Text>().text = "";
    }

    //���� ��ũ��Ʈ�� �����ش�.
    public void v_NextScript()
    {
        mn_Sequence += 1;
        if (mn_Sequence < msa_SplitText.Length)
        {
            this.mg_MotherScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
        }
        else if (mn_Sequence >= msa_SplitText.Length)
        {
            Debug.Log("��Ӵ� ��ũ��Ʈ ������� : " + mn_Sequence);
            Debug.Log("��Ӵ� ��ũ��Ʈ �ִ� �� : " + msa_SplitText.Length);
            Debug.Log("��Ӵ� ��ũ��Ʈ ũ�� �ʰ�");
        }
    }
}
