/*
 * - Name : Jack9_Sack.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�9 - �ڷ� �̺�Ʈ���� ��ũ��Ʈ
 *              �ڷ縦 ������ Ŭ���� ��� �ڷ簡 ������ �۵�
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
 * mn_SackTouchCount : �Ͷ߸������� �ʿ��� ��ġ Ƚ��
 * 
 * -Function
 * OnMouseDown() : Ŭ���� �۵� �Լ�
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Jack9_Sack : MonoBehaviour
{
    int mn_SackTouchCount;
    GameObject EventController;


    // Start is called before the first frame update
    void Start()
    {
        this.EventController = GameObject.Find("GameDirector");

        mn_SackTouchCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(mn_SackTouchCount <= 0)
        {
            Destroy(gameObject);
            this.EventController.GetComponent<Jack9_EventController>().v_IsSackDestroy();
        }
    }

    private void OnMouseDown()
    {
        mn_SackTouchCount -= 1;
    }


}
