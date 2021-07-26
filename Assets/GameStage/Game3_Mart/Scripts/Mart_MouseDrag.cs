/*
 * - Name : Mart_MouseDrag.cs
 * - Writer : 김명현
 * 
 * - Content
 * 마우스 이벤트 스크립트
 * 마우스 드래그시 오브젝트가 따라 움직이게 수정
 * 마우스에서 손을 뗄 경우 오브젝트 원래위치로 이동
 * 
 * -Update Log-
 * 2021-07-09 : 작성 완료
 * 2021-07-21 : 인코딩 형식 수정 및 주석 재작성
 *                  
 * - Variable 
 * mv2_mouseDragPosition : 마우스 위치를 저장하는 벡터
 * mv2_worldObjectPosition : 카메라의 월드좌표로 변환을 위한 벡터
 * 
 * -Function()
 * OnMouseDown() : 오브젝트를 클릭한 경우
 * OnMouseDrag() : 오브젝트를 드래그한 경우
 * OnMouseUp() : 오브젝트에서 손을 떼는 경우
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mart_MouseDrag : MonoBehaviour
{
    private SoundManager msm_soundManager;
    private bool PlayOnce;

    void Start(){
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        PlayOnce = false;

    }

    void Update(){

    }

    /// <summary>
    /// 오브젝트를 클릭한 경우
    /// </summary>
    private void OnMouseDown(){
        Debug.Log("오브젝트 터치");
    }

    /// <summary>
    /// 오브젝트를 드래그한 경우
    /// </summary>
    private void OnMouseDrag(){
        Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
        this.transform.position = mv2_worldObjectPosition;
        Debug.Log("오브젝트 드래그");
        if(PlayOnce == false)
        {
            msm_soundManager.playSound(0);
            PlayOnce = true;
        }
    }

    /// <summary>
    /// 오브젝트에서 손을 떼는 경우
    /// </summary>
    private void OnMouseUp(){
        Debug.Log("오브젝트에서 손 뗌");
        if(this.tag == "Mart_Item1"){                                                       // 오브젝트에 따라
            this.transform.position = new Vector3(6.1f, 2.75f, 0);                          // 원래 위치로 이동
        }
        if (this.tag == "Mart_Item2"){
            this.transform.position = new Vector3(9.5f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item3"){
            this.transform.position = new Vector3(6.1f, 0, 0);
        }
        if (this.tag == "Mart_Item4"){
            this.transform.position = new Vector3(9.5f, 0f, 0);
        }
        if (this.tag == "Mart_Item5"){
            this.transform.position = new Vector3(6.1f, -3f, 0);
        }
        if (this.tag == "Mart_Item6"){
            this.transform.position = new Vector3(9.5f, -3f, 0);
        }
        PlayOnce = false;
    }
}
