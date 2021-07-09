using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Name : BrushYourTeeth_Virus2Generator.cs
 * Content : ���̷���2 ���� ��ũ��Ʈ
 * 
 * 
 * ����
 * mg_Virus2_Prefab : ���̷���1 �������� �ҷ��� ����
 * mf_span : ���� �ֱ�
 * mf_delta : �ð��� �󸶳� �귶���� Ȯ���� ���� �ð��� ��� ����
 * mn_mn_virus2_cnt : �� ������ ���̷��� ī��Ʈ�� ���� ����
 * ma2f_Virus2Position : ���̷��� ������ġ�� �����ϴ� 2���� �迭
 * 
 * n_i : for�� ī��Ʈ�� ���� ����
 * n_j : ��
 * 
 * n_Virus2PositionX : ���̷���1 ��ġ X��
 * n_Virus2PositionY :���̷���1 ��ġ Y��
 * 
 * g_GenerateVirus1 : �������� ���� �����ϴ� ���̷���1 ������Ʈ
 * 
 * 
 * 
 */


public class BrushYourTeeth_Virus2Generator : MonoBehaviour
{
    public GameObject mg_Virus2_Prefab;
    float mf_span = 4.0f;  // ���� �ֱ�
    float mf_delta = 0;    //�ð� ��� ����
    int mn_virus2_cnt = 1; //�� ������ ���̷��� ī��Ʈ�� ����


    float[,] ma2f_Virus2Position = new float[5, 2];


    // Start is called before the first frame update
    void Start()
    {



        while (true)        //���̷��� ���� ��ġ ����
        {
            for (int n_i = 0; n_i < 5; n_i++)         //���̷����� ������ ���� ��ġ�� ma2f_Virus2Position�迭�� ����
            {
                int n_Virus2PositionX = Random.Range(-4, 4);
                float n_Virus2PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus2Position[n_i, 0] = n_Virus2PositionX;
                ma2f_Virus2Position[n_i, 1] = n_Virus2PositionY;
            }

            

            
            for (int n_i = 0; n_i < 4; n_i++)         //�ߺ��� ��ġ�� ������ �ʰԲ� �缳��
            {
                for (int n_j = 1; n_j < 5; n_j++)
                {
                    if (n_i == n_j)
                    {
                        n_j++;
                    }
                    if (Mathf.Abs(ma2f_Virus2Position[n_i, 0]) == Mathf.Abs(ma2f_Virus2Position[n_j, 0]) && (Mathf.Abs(ma2f_Virus2Position[n_i, 1]) - Mathf.Abs(ma2f_Virus2Position[n_j, 1]) < 0.8) && (Mathf.Abs(ma2f_Virus2Position[n_i, 1]) - Mathf.Abs(ma2f_Virus2Position[n_j, 1]) > -0.8))
                    {
                        int n_Virus2PositionX = Random.Range(-4, 4);
                        float n_Virus2PositionY = Random.Range(-0.6f, -3.3f);

                        ma2f_Virus2Position[n_j, 0] = n_Virus2PositionX;
                        ma2f_Virus2Position[n_j, 1] = n_Virus2PositionY;
                        n_i = 0;
                        continue;
                    }
                }
            }
            


            break;


        }


        GameObject g_GenerateVirus1 = Instantiate(mg_Virus2_Prefab) as GameObject;
        g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus2Position[0, 0], ma2f_Virus2Position[0, 1], 0);
        Debug.Log("���̷���2 1��° ��ġ : " + ma2f_Virus2Position[0, 0] + " " + ma2f_Virus2Position[0, 1]);


    }

    // Update is called once per frame
    void Update()
    {

        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > this.mf_span && mn_virus2_cnt < 5)
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus1 = Instantiate(mg_Virus2_Prefab) as GameObject;
            g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus2Position[mn_virus2_cnt, 0], ma2f_Virus2Position[mn_virus2_cnt, 1], 0);
            Debug.Log("���̷���2 " + (mn_virus2_cnt + 1) + "��° ��ġ : " + ma2f_Virus2Position[mn_virus2_cnt, 0] + " " + ma2f_Virus2Position[mn_virus2_cnt, 1]);
            mn_virus2_cnt++;
        }

    }
}
