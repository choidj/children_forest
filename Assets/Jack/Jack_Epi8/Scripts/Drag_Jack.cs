/*
 * - Name : Drag_Jack.cs
 * - Writer : ������
 * - Content : ����ᳪ�� ���Ǽҵ�8 - �� �巡�� ��ũ��Ʈ
 * 
 *            -�ۼ� ���-
 *            2021-07-14 : ���� �Ϸ�
 * OnTriggerEnter2D(Collider2D cCollideObject) :������Ʈ�� ����� Ʈ���� �ȿ� �ٸ� ������Ʈ�� ���� �� ȣ��� (2D ������)
 * OnMouseDrag() : ���ӿ�����Ʈ�� �巡�׷� �̵���Ű�� �Լ�
 * OnTriggerEnter2D(Collider2D other) : ������Ʈ�� �浹�� �Ͼ�� ó�� �ѹ��� ȣ��Ǵ� �Լ�
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drag_Jack : MonoBehaviour{   
    void OnTriggerEnter2D(Collider2D cCollideObject){
        OnMouseDrag();
        if(cCollideObject.tag == "Closet"){ //�浹 ������Ʈ�� �±װ� �����̸� -> Jack�� ���� �ڿ� ������
            SceneManager.LoadScene("Jack_Epi9"); //���� �� Epi19�� �̵�
        }
    }
    void OnMouseDrag(){
                Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
                this.transform.position = v2worldObjPos;
    }
}
