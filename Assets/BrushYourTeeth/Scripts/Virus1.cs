using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;
    public Animator OnClick;
    public Animator Virus1_Die;

    private int Virus1_HP = 2;  //���̷��� HP


    // Start is called before the first frame update
    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
    private void OnMouseDown()  //���̷��� Ŭ�� ��
    {
        if (Virus1_HP <= 0)
        {
            Virus1_Die.SetTrigger("Virus1_Die");
            Destroy(gameObject, 1f);
            NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();

        }
        else
        {
            OnClick.SetTrigger("OnClick");

            Virus1_HP -= 1;
            Debug.Log("���̷���1 Ŭ������");
        }
    }
    
}
