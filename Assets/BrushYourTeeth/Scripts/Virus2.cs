using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Name : BrushYourTeeth_Virus2.cs
 * Content : ���̷���2 ���� ��ũ��Ʈ
 * 
 * 
 * ����
 * mg_NumberOfVirusLeft : ĵ���� ���� ������Ʈ, ���� ���̷��� �� ������Ʈ�� ���� ������Ʈ
 * man_OnClick : Ŭ�������� �ִϸ��̼� ���� ����
 * man_Virus2_Die : �׾����� �ִϸ��̼� ���� ����
 * mn_Virus2_HP : ���̷��� HP ���� ����
 * mb_CheckFlag : ���̷����� ó�� ���������� Ȯ���� ���� flag
 *   �� ���̷����� �״� �ִϸ��̼� �� Ŭ���� �������̷������� ��� ���ҵǴ� ���׸� �߰��Ͽ� �̸� �ذ��ϱ����� flag�� ����� ó�� �������� �����ϵ��� ����
 * 
 * 
 * 
 * 
 * �Լ�()
 * OnMouseDown() : ���̷��� Ŭ���� �۵��Ǵ� �Լ�
 * 
 * 
 * 
 * 
 */








public class Virus2 : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;

    public Animator man_OnClick;
    public Animator man_Virus2_Die;

    private int mn_Virus2_HP = 3;

    private bool mb_CheckFlag;


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
        mb_CheckFlag = false;
    }

    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (mn_Virus2_HP == 0)
        {
            if (mb_CheckFlag == false)
            {
                mb_CheckFlag = true;
                mg_NumberOfVirusLeft.GetComponent<Control_UI>().v_MinusVirus();
            }
            man_Virus2_Die.SetTrigger("Virus2_Die");
            Destroy(gameObject, 1f);
        }
        else
        {
            man_OnClick.SetTrigger("OnClick");

            mn_Virus2_HP -= 1;
            Debug.Log("���̷���1 Ŭ������");
        }
    }
}
