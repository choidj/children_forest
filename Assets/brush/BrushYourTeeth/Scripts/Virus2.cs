using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus2 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;

    private int Virus2_HP = 3;  //바이러스 HP


    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()  //바이러스 클릭 시
    {
        Virus2_HP -= 1;
        Debug.Log("바이러스2 클릭성공");



        if (Virus2_HP <= 0)
        {
            Destroy(gameObject);
            NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();

        }
    }
}
