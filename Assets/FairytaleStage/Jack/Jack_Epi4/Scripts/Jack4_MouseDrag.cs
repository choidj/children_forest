/*
 * - Name : Jack4_MissionScript.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드4 - 마우스 드래그 스크립트
 *            오브젝트를 드래그할 경우 마우스포인트따라 객체 이동
 * 
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-14 : 제작 완료
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


public class Jack4_MouseDrag : MonoBehaviour
{
    private bool mb_flag;
    private bool mb_BeanPositionFlag;
    private SoundManager msm_soundManager;
    GameObject mg_ScriptManager;
    private bool PlayOnce;

    // Start is called before the first frame update
    void Start()
    {
        mb_BeanPositionFlag = false;
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        this.mg_ScriptManager = GameObject.Find("GameDirector");
        PlayOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

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
            if (PlayOnce == false)
            {
                msm_soundManager.playSound(0);
                PlayOnce = true;
            }
        }

        if(this.tag == "Bean")
        {
            this.mg_ScriptManager.GetComponent<Jack4_EventController>().DragFalgTrue();
        }
    }

    //마우스에서 손을 뗄 경우 원래위치로 돌아가게끔 설정
    private void OnMouseUp()
    {
        Debug.Log("오브젝트에서 손 뗌");
        if (this.tag == "Bean")
        {
            if(mb_BeanPositionFlag == false)
            {
                this.transform.position = new Vector3(-3, -4.5f, 0);
            }
            else
            {
                this.transform.position = new Vector3(5.2f, -3.5f, 0);
            }
            this.mg_ScriptManager.GetComponent<Jack4_EventController>().DragFalgFalse();
            if(mb_flag == true)
            {
                msm_soundManager.playSound(2);
            }
        }
        PlayOnce = false;
    }

    public void v_ChangeFlagTrue()
    {
        mb_flag = true;
    }
    public void v_ChangeFlagFalse()
    {
        mb_flag = false;
    }

    public void v_BeanPositionFlagTrue()
    {
        mb_BeanPositionFlag = true;
    }
}
