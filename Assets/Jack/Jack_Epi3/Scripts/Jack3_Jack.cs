/*
 * - Name : Jack3_Jack.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�3 - �� ������Ʈ ��ũ��Ʈ
 *            ��� ���� ��ü �浹ó���� ���� ��ũ��Ʈ
 * 
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-13 : ���� �Ϸ�
 *            
 *            
 *            
 * 
 * - Variable
 * 
 * ���� ������Ʈ ������ ���� ������Ʈ
 * mg_EventManager
 * 
 * 
 * - Function
 * 
 * �浹���� �Լ�
 * OnTriggerEnter2D(Collider2D cCollidObj) 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack3_Jack : MonoBehaviour
{
    GameObject mg_EventManager;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("Jack3_GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Debug.Log("�浹 ����");
        if (cCollidObj.tag == "Jack3_Bean")
        {
            Destroy(cCollidObj.gameObject);
            this.mg_EventManager.GetComponent<Jack3_EventController>().v_BeanToJack();
        }
    }
}
