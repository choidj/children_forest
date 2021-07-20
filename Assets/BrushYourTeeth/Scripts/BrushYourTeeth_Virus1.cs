/*
 * - Name : BrushYourTeeth_Virus1.cs
 * - Writer : 김명현
 * 
 * - Content : 
 * 세균1 설정 스크립트
 * 몇번을 터치하여 죽게할 것인지 설정
 * 터치시 죽을떄 애니메이션 설정
 *            
 *            
 * -수정 기록-
 * 2021-07-07 : 제작 완료
 * 2021-07-16 : 파일 인코딩 수정
 *                  
 * 
 * - Variable 
 * mg_NumberOfVirusLeft : ControlUI.cs에 연결을 위한 오브젝트
 * man_OnClick : 클릭했을때 애니메이션 저장 변수
 * man_Virus1_Die : 죽었을때 애니메이션 저장 변수
 * mn_Virus1_HP : 바이러스 HP 설정 변수
 * mb_CheckFlag : 죽는 애니메이션도중 터치시 카운트 올라가는것을 방지하기 위한 flag
 * 
 * 
 * -Function()
 * OnMouseDown() : 바이러스 클릭시 작동되는 함수
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushYourTeeth_Virus1 : MonoBehaviour
{
    //ControlUI.cs에 연결을 위한 오브젝트
    GameObject mg_NumberOfVirusLeft;

    //애니메이션
    public Animator man_OnClick;
    public Animator man_Virus1_Die;

    //세균 몇번 터치하면 없어질건지 설정하는 부분
    private int mn_Virus1_HP = 2;

    //죽는 애니메이션도중 터치시 카운트 올라가는것을 방지하기 위한 flag
    private bool mb_CheckFlag;

    VoiceManager vm;


    void Start()
    {
        //오브젝트 연결
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();

        //false로 초기화
        mb_CheckFlag = false;
    }

    void Update()
    {
        

    }

    
    private void OnMouseDown()
    {
        //세균의 HP가 0이되어 죽는경우 설정
        if (mn_Virus1_HP == 0)
        {
            //flag를 두어 세균이 죽으면 한번만 작동하도록 설정
            if(mb_CheckFlag == false)
            {
                mb_CheckFlag = true;
                //남은 세균 수 감소
                mg_NumberOfVirusLeft.GetComponent<BrushYourTeeth_ControlUI>().v_MinusVirus();
            }
            //죽는 애니메이션 후 오브젝트 제거
            man_Virus1_Die.SetTrigger("Virus1_Die");
            vm.playVoice(0);
            Destroy(gameObject, 1f);

        }
        //세균을 터치하여 HP감소
        else
        {
            //클릭시 애니메이션 작동
            man_OnClick.SetTrigger("OnClick");

            mn_Virus1_HP -= 1;
            Debug.Log("바이러스1 클릭성공");
        }
    }
    
}
