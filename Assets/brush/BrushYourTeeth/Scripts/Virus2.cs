using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus2 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;

    private int Virus2_HP = 3;  //���̷��� HP


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
        Virus2_HP -= 1;
        Debug.Log("���̷���2 Ŭ������");



        if (Virus2_HP <= 0)
        {
            Destroy(gameObject);
            NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();

        }
    }
}
