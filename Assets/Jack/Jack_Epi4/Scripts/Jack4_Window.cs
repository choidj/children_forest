/*
 * - Name : Jack4_Mother.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�4 - â�� ������Ʈ ��ũ��Ʈ
 *            ��� â����ü �浹ó���� ���� ��ũ��Ʈ
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

public class Jack4_Window : MonoBehaviour
{
    GameObject mg_EventManager;
    GameObject mg_Bean;

    bool CheckFlag;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("GameDirector");
        this.mg_Bean = GameObject.Find("Bean");

    }

    // Update is called once per frame
    void Update()
    {
        CheckFlag = this.mg_EventManager.GetComponent<Jack4_EventController>().b_CheckBeanToMother();
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Debug.Log("�浹 ����");
        if (cCollidObj.tag == "Bean" && CheckFlag == true)
        {
            Destroy(cCollidObj.gameObject);
            this.mg_EventManager.GetComponent<Jack4_EventController>().v_BeanToWindow();
        }
    }
}
