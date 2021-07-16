using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Name : BrushYourTeeth_Virus1.cs
 * Content : 바이러스1 설정 스크립트
 * 
 * 
 * 변수
 * mg_NumberOfVirusLeft : 캔버스 하위 오브젝트, 남은 바이러스 수 업데이트를 위한 오브젝트
 * man_OnClick : 클릭했을때 애니메이션 저장 변수
 * man_Virus1_Die : 죽었을때 애니메이션 저장 변수
 * mn_Virus1_HP : 바이러스 HP 설정 변수
 * mb_CheckFlag : 바이러스가 처음 죽을때인지 확인을 위한 flag
 *   ㄴ 바이러스가 죽는 애니메이션 중 클릭시 남은바이러스수가 계속 감소되는 버그를 발견하여 이를 해결하기위해 flag를 만들어 처음 죽을때만 감소하도록 설정
 * 
 * 
 * 
 * 
 * 함수()
 * OnMouseDown() : 바이러스 클릭시 작동되는 함수
 * 
 * 
 * 
 * 
 */






public class BrushYourTeeth_Virus1 : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;    //바이러스 퇴치시 남은 바이러스수 감소변수 값 조정을 위하여 불러옴


    public Animator man_OnClick;
    public Animator man_Virus1_Die;

    private int mn_Virus1_HP = 2;
    private bool mb_CheckFlag;


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

        mb_CheckFlag = false;   //처음 생성될때 flag 값을 false로 지정
    }

    void Update()
    {
        

    }

    
    private void OnMouseDown()
    {
        if (mn_Virus1_HP == 0)  //바이러스의 HP가 다 닳아 죽는 경우
        {
            if(mb_CheckFlag == false)   //바이러스가 죽는 애니메이션 중 클릭시 남은바이러스수가 계속 감소되는 버그를 발견하여 이를 해결하기위해 flag를 만들어 처음 죽을때만 감소하도록 설정
            {
                mb_CheckFlag = true;
                mg_NumberOfVirusLeft.GetComponent<BrushYourTeeth_ControlUI>().v_MinusVirus();
            }
            man_Virus1_Die.SetTrigger("Virus1_Die");
            Destroy(gameObject, 1f);

        }
        else  //바이러스가 공격받아 HP가 닳아야 되는 경우
        {
            man_OnClick.SetTrigger("OnClick");

            mn_Virus1_HP -= 1;
            Debug.Log("바이러스1 클릭성공");
        }
    }
    
}
