using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Name : BrushYourTeeth_Virus1Generator.cs
 * Content : 바이러스1 생성 스크립트
 * 
 * 
 * 변수
 * mg_Virus1_Prefab : 바이러스1 프리팹을 불러와 생성
 * mf_span : 생성 주기
 * mf_delta : 시간이 얼마나 흘렀는지 확인을 위한 시간을 재는 변수
 * mn_virus1_cnt : 총 생성된 바이러스 카운트를 위한 변수
 * ma2f_Virus1Position : 바이러스 생성위치를 저장하는 2차원 배열
 * 
 * n_i : for문 카운트를 위한 변수
 * n_j : 상동
 * 
 * n_Virus1PositionX : 바이러스1 위치 X값
 * n_Virus1PositionY :바이러스1 위치 Y값
 * 
 * g_GenerateVirus1 : 프리팹을 통해 생성하는 바이러스1 오브젝트
 * 
 * 
 * 
 */



public class BrushYourTeeth_Virus1Generator : MonoBehaviour
{
    public GameObject mg_Virus1_Prefab;
    float mf_span = 3.0f;  // 생성 주기 변경시 이 부분 수정
    float mf_delta = 0;    
    int mn_virus1_cnt = 1;


    float[,] ma2f_Virus1Position = new float[5, 2];


    void Start()
    {
        while (true)        //바이러스 생성 위치 설정
        {
            for (int n_i = 0; n_i < 5; n_i++)         //바이러스를 생성할 랜덤 위치를 ma2f_Virus1Position배열에 저장
            {
                int n_Virus1PositionX = Random.Range(-4, 4);
                float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus1Position[n_i, 0] = n_Virus1PositionX;
                ma2f_Virus1Position[n_i, 1] = f_Virus1PositionY;
            }


            for (int n_i = 0; n_i < 4; n_i++)         //같은 바이러스가 중복된 위치에 생성되지 않도록 설정
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
        g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[0, 0], ma2f_Virus1Position[0, 1], 0);     //첫번쨰 바이러스1 오브젝트 생성
        Debug.Log("생성된 바이러스1 1번째 위치 : " + ma2f_Virus1Position[0, 0] + " " + ma2f_Virus1Position[0, 1]);
    }

    void Update()
    {
        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > this.mf_span && mn_virus1_cnt < 5)  //여기서 설정한 개수 만큼만 바이러스1 생성됨
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;

            g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[mn_virus1_cnt, 0], ma2f_Virus1Position[mn_virus1_cnt, 1], 0);
            Debug.Log("바이러스1 " + (mn_virus1_cnt+1) + "번째 위치 : " + ma2f_Virus1Position[mn_virus1_cnt, 0] + " " + ma2f_Virus1Position[mn_virus1_cnt, 1]); //2~바이러스1 오브젝트 생성
            mn_virus1_cnt++;
        }
        
    }
}
