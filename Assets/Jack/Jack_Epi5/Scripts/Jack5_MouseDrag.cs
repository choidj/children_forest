/*
 * - Name : Jack5_MissionScript.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�5 - ���콺 �巡�� ��ũ��Ʈ
 *            ������Ʈ�� �巡���� ��� ���콺����Ʈ���� ��ü �̵�
 * 
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-15 : ���� �Ϸ�
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

public class Jack5_MouseDrag : MonoBehaviour
{
    private bool mb_flag;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
            this.transform.position = mv2_worldObjectPosition;
            Debug.Log("������Ʈ �巡��");
    }

    //���콺���� ���� �� ��� ������ġ�� ���ư��Բ� ����
    private void OnMouseUp()
    {
        Debug.Log("������Ʈ���� �� ��");

        if (this.tag == "Jack")
        {
            this.transform.position = new Vector3(-6.22f, -3.69f, 0);
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
