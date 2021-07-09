using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/*
 * Name : BrushYourTeeth_ControlUI.cs
 * Content : 남은 바이러스 수 표시하는 오브젝트("NumberOfVirusLeft") 컨트롤하는 스크립트
 * 
 * 
 * 변수
 * mg_NumberOfVirusLeft : 캔버스 하위 오브젝트, 남은 바이러스 수 업데이트를 위한 오브젝트
 * mn_LeftVirus : 남은 바이러스 수 저장 변수
 * 
 * 
 * 함수()
 * 
 * v_MinusVirus() : 남은 바이러스 수 감소하는 함수
 * 
 * 
 * 
 */






public class Control_UI : MonoBehaviour
{
    GameObject mg_NumberOfVirusLeft;

    private int mn_LeftVirus = 10;  // 이를 조정하여 없앨 바이러스 값 변경시, 각 바이러스 생성개수를 따로 설정하였기에 그부분도 수정해야됨


    void Start()
    {
        this.mg_NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

    }

    
    // Update is called once per frame
    void Update()
    {
        this.mg_NumberOfVirusLeft.GetComponent<Text>().text = "남은 바이러스 수 : " + this.mn_LeftVirus;


        if (this.mn_LeftVirus == 0)
        {
            SceneManager.LoadScene("end_scene");
        }

    }


    public void v_MinusVirus()
    {
        this.mn_LeftVirus -= 1;     // 바이러스 수 감소
        Debug.Log("남은 바이러스 수 1 감소");
        Debug.Log(this.mn_LeftVirus);
    }

}
