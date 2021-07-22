/*
 * - Name : BrushYourTeeth_ControlUI.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 남은 바이러스 수 표시하는 오브젝트("NumberOfVirusLeft") 컨트롤하는 스크립트
 * 
 * -수정 기록-
 * 2021-07-07 : 제작 완료
 * 2021-07-16 : 파일 인코딩 수정
 *                  
 * - Variable 
 * mg_NumberOfVirusLeft : 캔버스 하위 오브젝트, 남은 바이러스 수 업데이트를 위한 오브젝트
 * mn_LeftVirus : 남은 바이러스 수 저장 변수
 * 
 * -Function()
 * v_MinusVirus() : 남은 바이러스 수 감소하는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrushYourTeeth_ControlUI : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;                                       // 오브젝트연결을 위해 선언

    private int mn_LeftVirus = 10;                                          // 없앨 세균 수 설정, 세균 수 수정시 각 세균 생성수도 변경해줘야됨


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");   // 오브젝트 연결
    }

    void Update()
    {
        this.mg_NumberOfVirusLeft.GetComponent<Text>().text = "남은 바이러스 수 : " + this.mn_LeftVirus;   // 남은 바이러스수 실시간 업데이트

        if (this.mn_LeftVirus == 0)                                         // 남은 세균수가 0마리가 되면 게임종료
        {
            SceneManager.LoadScene("end_scene");
        }

    }

    /// <summary>
    /// 남은세균수를 감소시켜주는 함수
    /// </summary>
    public void v_MinusVirus()
    {
        this.mn_LeftVirus -= 1;                                              // 바이러스 수 감소
        Debug.Log("남은 바이러스 수 1 감소");
        Debug.Log(this.mn_LeftVirus);
    }

}
