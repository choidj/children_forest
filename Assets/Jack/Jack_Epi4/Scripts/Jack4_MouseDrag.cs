/*
 * - Name : Jack4_MissionScript.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�4 - ���콺 �巡�� ��ũ��Ʈ
 *            ������Ʈ�� �巡���� ��� ���콺����Ʈ���� ��ü �̵�
 * 
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-14 : ���� �Ϸ�
 *            
 *            
 *            
 * 
 * - Variable 
 * mv2_mouseDragPosition
 * mv2_worldObjectPosition
 * mb_flag : ���ϴ½����� �巡�׸� Ȱ��ȭ�ϱ� ���� flag
 * mb_BeanPositionFlag : flag�� ���� ���� ��ġ�� �ٸ��� ����
 * 
 * - Function
 * 
 * ���콺 ���� �Լ�
 * OnMouseDown() : touch the object
 * OnMouseDrag() : drag
 * OnMouseUp() : When you take your hands off the mouse.
 * 
 * �÷��� ���� �Լ�
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


    // Start is called before the first frame update
    void Start()
    {
        mb_BeanPositionFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

    }

    //�巡���� ��� ���콺��ġ���� ������Ʈ �̵�
    private void OnMouseDrag()
    {
        if (mb_flag == true)
        {
            Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
            this.transform.position = mv2_worldObjectPosition;
            Debug.Log("������Ʈ �巡��");
        }
    }

    //���콺���� ���� �� ��� ������ġ�� ���ư��Բ� ����
    private void OnMouseUp()
    {
        Debug.Log("������Ʈ���� �� ��");

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

    public void v_BeanPositionFlagTrue()
    {
        mb_BeanPositionFlag = true;
    }
}
