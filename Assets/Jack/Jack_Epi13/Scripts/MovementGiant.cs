/*
 * - Name : Movement_Giant.cs
 * - Writer : ������
 * - Content : ����ᳪ�� ���Ǽҵ�13 - ���� �̵� ��ũ��Ʈ
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
public class MovementGiant : MonoBehaviour
{
    float mf_timer; //���� �ð�
    float mf_waitingTime; //���ϴ� �ð� ����

    public Vector3 v3_target; //���ϴ� ��ġ ����
    void Update(){
        /*deltaTime�� �̿��ؼ� �ð� ����*/ 
        mf_timer += Time.deltaTime;
        if (mf_timer > mf_waitingTime){ //-> ���ϴ� �ð�(��) ���� �Լ� ����
            transform.position = Vector3.MoveTowards(transform.position, v3_target, 0.1f); //�����̵�
        }

    }
}
