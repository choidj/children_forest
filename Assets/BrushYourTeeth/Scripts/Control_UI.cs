using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/*
 * Name : BrushYourTeeth_ControlUI.cs
 * Content : ���� ���̷��� �� ǥ���ϴ� ������Ʈ("NumberOfVirusLeft") ��Ʈ���ϴ� ��ũ��Ʈ
 * 
 * 
 * ����
 * mg_NumberOfVirusLeft : ĵ���� ���� ������Ʈ, ���� ���̷��� �� ������Ʈ�� ���� ������Ʈ
 * mn_LeftVirus : ���� ���̷��� �� ���� ����
 * 
 * 
 * �Լ�()
 * 
 * v_MinusVirus() : ���� ���̷��� �� �����ϴ� �Լ�
 * 
 * 
 * 
 */






public class Control_UI : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;

    private int mn_LeftVirus = 10;  // �̸� �����Ͽ� ���� ���̷��� �� �����, �� ���̷��� ���������� ���� �����Ͽ��⿡ �׺κе� �����ؾߵ�


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

    }

    
    // Update is called once per frame
    void Update()
    {
        this.mg_NumberOfVirusLeft.GetComponent<Text>().text = "���� ���̷��� �� : " + this.mn_LeftVirus;


        if (this.mn_LeftVirus == 0)
        {
            SceneManager.LoadScene("end_scene");
        }

    }


    public void v_MinusVirus()
    {
        this.mn_LeftVirus -= 1;     // ���̷��� �� ����
        Debug.Log("���� ���̷��� �� 1 ����");
        Debug.Log(this.mn_LeftVirus);
    }

}
