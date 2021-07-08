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


    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()  //???????? ???? ??
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
            Debug.Log("????????2 ????????");
        }
    }
}
