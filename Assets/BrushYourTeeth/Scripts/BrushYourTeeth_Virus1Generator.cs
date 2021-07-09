using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Name : BrushYourTeeth_Virus1Generator.cs
 * Content : ���̷���1 ���� ��ũ��Ʈ
 * 
 * 
 * ����
 * mg_Virus1_Prefab : ���̷���1 �������� �ҷ��� ����
 * mf_span : ���� �ֱ�
 * mf_delta : �ð��� �󸶳� �귶���� Ȯ���� ���� �ð��� ��� ����
 * mn_virus1_cnt : �� ������ ���̷��� ī��Ʈ�� ���� ����
 * ma2f_Virus1Position : ���̷��� ������ġ�� �����ϴ� 2���� �迭
 * 
 * n_i : for�� ī��Ʈ�� ���� ����
 * n_j : ��
 * 
 * n_Virus1PositionX : ���̷���1 ��ġ X��
 * n_Virus1PositionY :���̷���1 ��ġ Y��
 * 
 * g_GenerateVirus1 : �������� ���� �����ϴ� ���̷���1 ������Ʈ
 * 
 * 
 * 
 */



public class BrushYourTeeth_Virus1Generator : MonoBehaviour
{
    public GameObject mg_Virus1_Prefab;
    float mf_span = 3.0f;  // ���� �ֱ� ����� �� �κ� ����
    float mf_delta = 0;    
    int mn_virus1_cnt = 1;


    float[,] ma2f_Virus1Position = new float[5, 2];


    void Start()
    {
        while (true)        //���̷��� ���� ��ġ ����
        {
            for (int n_i = 0; n_i < 5; n_i++)         //���̷����� ������ ���� ��ġ�� ma2f_Virus1Position�迭�� ����
            {
                int n_Virus1PositionX = Random.Range(-4, 4);
                float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus1Position[n_i, 0] = n_Virus1PositionX;
                ma2f_Virus1Position[n_i, 1] = f_Virus1PositionY;
            }


            for (int n_i = 0; n_i < 4; n_i++)         //���� ���̷����� �ߺ��� ��ġ�� �������� �ʵ��� ����
            {
                for (int n_j = 1; n_j < 5; n_j++)
                {
                    if (n_i == n_j)
                    {
                        n_j++;
                    }
                    if (Mathf.Abs(ma2f_Virus1Position[n_i, 0]) == Mathf.Abs(ma2f_Virus1Position[n_j, 0]) && (Mathf.Abs(ma2f_Virus1Position[n_i, 1]) - Mathf.Abs(ma2f_Virus1Position[n_j, 1]) < 0.8) && (Mathf.Abs(ma2f_Virus1Position[n_i, 1]) - Mathf.Abs(ma2f_Virus1Position[n_j, 1]) > -0.8))
                    {
                        int n_Virus1PositionX = Random.Range(-4, 4);
                        float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                        ma2f_Virus1Position[n_j, 0] = n_Virus1PositionX;
                        ma2f_Virus1Position[n_j, 1] = f_Virus1PositionY;
                        n_i = 0;
                        continue;
                    }
                }
            }
            break;  
        }

        GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;
        g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[0, 0], ma2f_Virus1Position[0, 1], 0);     //ù���� ���̷���1 ������Ʈ ����
        Debug.Log("������ ���̷���1 1��° ��ġ : " + ma2f_Virus1Position[0, 0] + " " + ma2f_Virus1Position[0, 1]);
    }

    void Update()
    {
        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > this.mf_span && mn_virus1_cnt < 5)  //���⼭ ������ ���� ��ŭ�� ���̷���1 ������
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;

            g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[mn_virus1_cnt, 0], ma2f_Virus1Position[mn_virus1_cnt, 1], 0);
            Debug.Log("���̷���1 " + (mn_virus1_cnt+1) + "��° ��ġ : " + ma2f_Virus1Position[mn_virus1_cnt, 0] + " " + ma2f_Virus1Position[mn_virus1_cnt, 1]); //2~���̷���1 ������Ʈ ����
            mn_virus1_cnt++;
        }
        
    }
}
