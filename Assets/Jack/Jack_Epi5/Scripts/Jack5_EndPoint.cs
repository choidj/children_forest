/*
 * - Name : Jack5_EndPoint.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�5 - �ᳪ�� ������ ������Ʈ ��ũ��Ʈ
 *            ��� ��Ӵϰ�ü �浹ó���� ���� ��ũ��Ʈ
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

public class Jack5_EndPoint : MonoBehaviour
{
    GameObject mg_EventManager;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_EventManager = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Destroy(cCollidObj.gameObject);
        Debug.Log("���Ǽҵ� Ŭ����");
    }
}
