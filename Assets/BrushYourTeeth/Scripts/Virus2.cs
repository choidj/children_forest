using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus2 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;

    public Animator OnClick;
    public Animator Virus2_Die;

    private int Virus2_HP = 3;  //바이러스 HP

    float Virus2DyingTime = 1.5f;
    float Virus2_delta;


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
        if (Virus2_HP <= 0)
        {
            Virus2_Die.SetTrigger("Virus2_Die");
            Destroy(gameObject, 1f);
            NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();

        }
        else
        {
            OnClick.SetTrigger("OnClick");

            Virus2_HP -= 1;
            Debug.Log("바이러스2 클릭성공");
        }
    }
}
