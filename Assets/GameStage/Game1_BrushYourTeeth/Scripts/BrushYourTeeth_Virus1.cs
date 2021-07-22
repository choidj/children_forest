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
 * 2021-07-20 : TTS 기능 추가
 *                  
 * 
 * - Variable 
 * mg_NumberOfVirusLeft : ControlUI.cs에 연결을 위한 오브젝트
 * man_OnClick : 클릭했을때 애니메이션 저장 변수
 * man_Virus1_Die : 죽었을때 애니메이션 저장 변수
 * mn_Virus1_HP : 바이러스 HP 설정 변수
 * mb_CheckFlag : 죽는 애니메이션도중 터치시 카운트 올라가는것을 방지하기 위한 flag
 * vm : 음성 TTS를 처리하는 오브젝트 연결
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
    GameObject mg_NumberOfVirusLeft;                                                        // ControlUI.cs에 연결을 위한 오브젝트

    public Animator man_OnClick;                                                            // 애니메이션
    public Animator man_Virus1_Die;                                                         // 애니메이션

    private int mn_Virus1_HP = 2;                                                           // 세균 몇번 터치하면 없어질건지 설정하는 부분

    private bool mb_CheckFlag;                                                              //죽는 애니메이션도중 터치시 카운트 올라가는것을 방지하기 위한 fla

    VoiceManager vm;                                                                        // 음성(TTS) 오브젝트 연결을 위한 변수


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");                   // 오브젝트 연결
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();             // 오브젝트 연결

        mb_CheckFlag = false;                                                               // false로 초기화
    }

    void Update()
    {
        

    }

    
    private void OnMouseDown()
    {
        if (mn_Virus1_HP == 0)                                                              // 세균의 HP가 0이되어 죽는경우 설정
        {
            if(mb_CheckFlag == false)                                                       // flag를 두어 세균이 죽으면 한번만 작동하도록 설정
            {
                mb_CheckFlag = true;              
                mg_NumberOfVirusLeft.GetComponent<BrushYourTeeth_ControlUI>().v_MinusVirus();   // 남은 세균 수 감소
            }
            man_Virus1_Die.SetTrigger("Virus1_Die");                                        // 죽는 애니메이션 후
            vm.playVoice(0);                                                                // 죽을때 음성
            Destroy(gameObject, 1f);                                                        // 오브젝트 제거

        }
        else                                                                                // 세균을 터치하여 HP감소
        {
            man_OnClick.SetTrigger("OnClick");                                              // 클릭시 애니메이션 작동

            mn_Virus1_HP -= 1;
            Debug.Log("바이러스1 클릭성공");

            vm.playVoice(2);
        }
    }
    
}
