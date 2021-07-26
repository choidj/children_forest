/*
 * - Name : Jack3_MouseDrag.cs
 * - Writer : 김명현
 * 
 * - Content
 * 잭과콩나무 에피소드3 - 마우스 이벤트 스크립트
 * 마우스 드래그시 오브젝트가 따라 움직이게 수정
 * 마우스에서 손을 뗄 경우 오브젝트 원래위치로 이동
 * 
 * - Update Log -
 * 2021-07-13 : 작성 완료
 * 2021-07-23 : 주석변경
 *                  
 * - Variable 
 * mv2_mouseDragPosition                마우스 위치를 저장하는 벡터
 * mv2_worldObjectPosition              카메라의 월드좌표로 변환을 위한 벡터
 * mb_flag                              원하는시점에 드래그를 활성화하기 위한 flag
 * - Function()
 * OnMouseDrag()                        오브젝트를 드래그한 경우
 * OnMouseUp()                          오브젝트에서 손을 떼는 경우
 * v_ChangeFlagTrue()                   Flag 값 True
 * v_ChangeFlagTrue()                   Flag 값 False
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jack3_MouseDrag : MonoBehaviour
{
    private bool mb_flag;
    GameObject mg_ScriptManager;
    private SoundManager msm_soundManager;
    private bool PlayOnce;
    void Start()
    {
        mb_flag = false;                                                                                        // Flag값 False로 초기화
        this.mg_ScriptManager = GameObject.Find("Jack3_GameDirector");                                          // 오브젝트 연결
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        PlayOnce = false;
    }

    /// <summary>
    /// 오브젝트를 드래그한 경우
    /// </summary>
    private void OnMouseDrag(){
        if(mb_flag == true)
        {
            Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
            this.transform.position = mv2_worldObjectPosition;
            Debug.Log("오브젝트 드래그");
            if (PlayOnce == false)
            {
                msm_soundManager.playSound(0);
                PlayOnce = true;
            }
        }
        
        if(this.gameObject.tag == "Jack3_Cow")
        {
            mg_ScriptManager.GetComponent<Jack3_EventController>().v_DragCow();
        }
        else if (this.gameObject.tag == "Jack3_Bean")
        {
            mg_ScriptManager.GetComponent<Jack3_EventController>().v_DragBeanFlagTrue();
        }
    }
    /// <summary>
    /// 오브젝트에서 손을 떼는 경우
    /// </summary>
    private void OnMouseUp(){
        Debug.Log("오브젝트에서 손 뗌");
        if(mb_flag == true)
        {
            msm_soundManager.playSound(1);
        }
        if (this.tag == "Jack3_Cow"){
            this.transform.position = new Vector3(-6.7f, -3.26f, 0);
            mg_ScriptManager.GetComponent<Jack3_EventController>().v_NotDragCow();
        }
        else if (this.tag == "Jack3_Bean"){
            this.transform.position = new Vector3(5f, -3.5f, 0);
            mg_ScriptManager.GetComponent<Jack3_EventController>().v_DragBeanFalgFalse();
        }
        PlayOnce = false;
    }
    /// <summary>
    /// Flag값 변경 함수
    /// </summary>
    public void v_ChangeFlagTrue(){                                                                                 // Flag값 True
        mb_flag = true;
    }
    public void v_ChangeFlagFalse(){                                                                                // Flag값 False
        mb_flag = false;
    }

}
