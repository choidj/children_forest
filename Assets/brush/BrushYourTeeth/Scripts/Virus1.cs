using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;

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
        Virus1_HP -= 1;
        Debug.Log("���̷���1 Ŭ������");



        if (Virus1_HP <= 0)
        {
            Destroy(gameObject);
            NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();

        }
    }
    
}
