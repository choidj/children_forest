using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus2 : MonoBehaviour
{
    GameObject NumberOfVirusLeft;

    public Animator OnClick;
    public Animator Virus2_Die;

    private int Virus2_HP = 3;  //???????? HP

    private bool CheckFlag;


    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
        CheckFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()  //???????? ???? ??
    {
        if (Virus2_HP == 0)
        {
            if (CheckFlag == false)
            {
                CheckFlag = true;
                NumberOfVirusLeft.GetComponent<Control_UI>().MinusVirus();
            }
            Virus2_Die.SetTrigger("Virus2_Die");
            Destroy(gameObject, 1f);

        }
        else
        {
            OnClick.SetTrigger("OnClick");

            Virus2_HP -= 1;
            Debug.Log("????????2 ????????");
        }
    }
}
