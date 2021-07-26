/*
 * - Name : Jack5_MissionScript.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드5 - 마우스 드래그 스크립트
 *            오브젝트를 드래그할 경우 마우스포인트따라 객체 이동
 * 
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-15 : 제작 완료
 *            
 *            
 *            
 * 
 * - Variable 
 * mv2_mouseDragPosition
 * mv2_worldObjectPosition
 * mb_flag : 원하는시점에 드래그를 활성화하기 위한 flag
 * mb_BeanPositionFlag : flag를 통해 콩의 위치를 다르게 설정
 * 
 * - Function
 * 
 * 마우스 조작 함수
 * OnMouseDown() : touch the object
 * OnMouseDrag() : drag
 * OnMouseUp() : When you take your hands off the mouse.
 * 
 * 플래그 설정 함수
 * v_ChangeFlagTrue()
 * v_ChangeFlagTrue()
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jack5_MouseDrag : MonoBehaviour
{
    private bool mb_flag;
    private SoundManager msm_soundManager;
    private bool PlayOnce;
    GameObject mg_ScriptManager;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        PlayOnce = false;
    }

    //드래그할 경우 마우스위치따라 오브젝트 이동
    private void OnMouseDrag()
    {
        if (mb_flag == true)
        {
            Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
            this.transform.position = mv2_worldObjectPosition;
            Debug.Log("오브젝트 드래그");
            this.mg_ScriptManager.GetComponent<Jack5_EventController>().v_DragFalgTrue();
            if (PlayOnce == false)
            {
                msm_soundManager.playSound(0);
                PlayOnce = true;
            }
        }
            
    }

    //마우스에서 손을 뗄 경우 원래위치로 돌아가게끔 설정
    private void OnMouseUp()
    {
        Debug.Log("오브젝트에서 손 뗌");

        if (this.tag == "Jack")
        {
            this.transform.position = new Vector3(-6.22f, -3.69f, 0);
        }
        this.mg_ScriptManager.GetComponent<Jack5_EventController>().v_DragFalgFalse();
        PlayOnce = false;
        if (mb_flag == true)
        {
            msm_soundManager.playSound(1);
        }
    }
    
    public void v_ChangeFlagTrue()
    {
        mb_flag = true;
    }
    public void v_ChangeFlagFalse()
    {
        mb_flag = false;
    }
    
}
