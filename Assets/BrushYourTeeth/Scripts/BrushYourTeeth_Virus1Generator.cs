/*
 * - Name : BrushYourTeeth_Virus1Generator.cs
 * - Writer : 김명현
 * 
 * - Content : 
 * 세균1 자동생성을 위한 스크립트
 * 생성될 세균수 설정
 * 어느위치에 세균이 생성되게할것인 설정
 *            
 *            
 * -수정 기록-
 * 2021-07-07 : 제작 완료
 * 2021-07-16 : 파일 인코딩 수정
 *                  
 * 
 * - Variable 
 * mg_Virus1_Prefab : 프리팹 연결을 위한 오브젝트
 * mf_span : 생성 주기
 * mf_delta : 시간이 얼마나 흘렀는지 확인을 위한 시간을 재는 변수
 * mn_mn_virus1_cnt : 총 생성된 바이러스 카운트를 위한 변수
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushYourTeeth_Virus1Generator : MonoBehaviour
{
    public GameObject mg_Virus1_Prefab;

    float mf_span = 3.0f;                                                       // 세균1 생성주기 변경을 원할시 이 부분 수정 (단위 : 초)

    float mf_delta = 0;    
    int mn_virus1_cnt = 1;


    float[,] ma2f_Virus1Position = new float[5, 2];


    void Start()
    {
        while (true)                                                            // 세균 생성위치를 설정하는 루프문
        {
            for (int n_i = 0; n_i < 5; n_i++)                                   //세균을 생성할 위치를 ma2f_Virus1Position배열에 저장
            {
                int n_Virus1PositionX = Random.Range(-4, 4);
                float f_Virus1PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus1Position[n_i, 0] = n_Virus1PositionX;
                ma2f_Virus1Position[n_i, 1] = f_Virus1PositionY;
            }

            for (int n_i = 0; n_i < 4; n_i++)                                   // 세균이 중복된 위치에 생성되지 않도록 하기위한 루프문
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

        g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[0, 0], ma2f_Virus1Position[0, 1], 0); // 첫번째 세균1 생성
        Debug.Log("생성된 바이러스1 1번째 위치 : " + ma2f_Virus1Position[0, 0] + " " + ma2f_Virus1Position[0, 1]);
    }

    void Update()
    {
        this.mf_delta += Time.deltaTime;

        if (this.mf_delta > this.mf_span && mn_virus1_cnt < 5)      // 생성할 세균1 개수를 변경하려면 이 부분 수정 (5), 설정한 주기마다 세균1을 생성하는 루프문
        {
            this.mf_delta = 0;
            GameObject g_GenerateVirus1 = Instantiate(mg_Virus1_Prefab) as GameObject;
            g_GenerateVirus1.transform.position = new Vector3(ma2f_Virus1Position[mn_virus1_cnt, 0], ma2f_Virus1Position[mn_virus1_cnt, 1], 0);
            Debug.Log("바이러스1 " + (mn_virus1_cnt+1) + "번째 위치 : " + ma2f_Virus1Position[mn_virus1_cnt, 0] + " " + ma2f_Virus1Position[mn_virus1_cnt, 1]); //2~바이러스1 오브젝트 생성
            mn_virus1_cnt++;
        }
        
    }
}
