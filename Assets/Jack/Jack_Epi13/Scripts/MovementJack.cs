/*
 * - Name : Movement_Jack.cs
 * - Writer : ������
 * - Content : ����ᳪ�� ���Ǽҵ�13 - �� �̵� ��ũ��Ʈ
 * 
 *            -�ۼ� ���-
 *            2021-07-15 : ���� �Ϸ�
 *
 * MoveTowards() : ��� �̵�, �Ű������� {������ġ, ��ǥ��ġ, �ӵ�}�� �Է�           
 *            
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJack : MonoBehaviour
{
    public Vector3 v3_target; //���ϴ� ��ġ ����

    void Update(){
	    transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.2f);

    }
}
