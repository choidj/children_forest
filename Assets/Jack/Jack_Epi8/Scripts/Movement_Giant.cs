/*
 * - Name : Movement_Giant.cs
 * - Writer : ������
 * - Content : ����ᳪ�� ���Ǽҵ�8 - ���� �̵� ��ũ��Ʈ
 * 
 *            -�ۼ� ���-
 *            2021-07-14 : ���� �Ϸ�
 *
 * MoveTowards() : ��� �̵�, �Ű������� {������ġ, ��ǥ��ġ, �ӵ�}�� �Է�  
 *            
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Giant : MonoBehaviour{   
    /* ���� �̵���Ű�� ������Ʈ */
    public GameObject mg_targetPosition; // walkPos ������Ʈ�� �������༭ �� ��ġ�� ���� �̵���Ŵ
    void Update(){
        transform.position = Vector3.MoveTowards(gameObject.transform.position, 
                                                    mg_targetPosition.transform.position, 0.1f); //���� �̵� 
    }
}