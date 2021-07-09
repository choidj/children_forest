using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Name : BrushYourTeeth_Virus1.cs
 * Content : ���̷���1 ���� ��ũ��Ʈ
 * 
 * 
 * ����
 * mg_NumberOfVirusLeft : ĵ���� ���� ������Ʈ, ���� ���̷��� �� ������Ʈ�� ���� ������Ʈ
 * man_OnClick : Ŭ�������� �ִϸ��̼� ���� ����
 * man_Virus1_Die : �׾����� �ִϸ��̼� ���� ����
 * mn_Virus1_HP : ���̷��� HP ���� ����
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






public class Virus1 : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;    //���̷��� ��ġ�� ���� ���̷����� ���Һ��� �� ������ ���Ͽ� �ҷ���


    public Animator man_OnClick;
    public Animator man_Virus1_Die;

    private int mn_Virus1_HP = 2;
    private bool mb_CheckFlag;


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

        mb_CheckFlag = false;   //ó�� �����ɶ� flag ���� false�� ����
    }

    void Update()
    {
        

    }

    
    private void OnMouseDown()
    {
        if (mn_Virus1_HP == 0)  //���̷����� HP�� �� ��� �״� ���
        {
            if(mb_CheckFlag == false)   //���̷����� �״� �ִϸ��̼� �� Ŭ���� �������̷������� ��� ���ҵǴ� ���׸� �߰��Ͽ� �̸� �ذ��ϱ����� flag�� ����� ó�� �������� �����ϵ��� ����
            {
                mb_CheckFlag = true;
                mg_NumberOfVirusLeft.GetComponent<Control_UI>().v_MinusVirus();
            }
            man_Virus1_Die.SetTrigger("Virus1_Die");
            Destroy(gameObject, 1f);

        }
        else  //���̷����� ���ݹ޾� HP�� ��ƾ� �Ǵ� ���
        {
            man_OnClick.SetTrigger("OnClick");

            mn_Virus1_HP -= 1;
            Debug.Log("���̷���1 Ŭ������");
        }
    }
    
}
