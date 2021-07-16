using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Name : BrushYourTeeth_Virus2Generator.cs
 * Content : 바이러스2 생성 스크립트
 * 
 * 
 * 변수
 * mg_Virus2_Prefab : 바이러스1 프리팹을 불러와 생성
 * mf_span : 생성 주기
 * mf_delta : 시간이 얼마나 흘렀는지 확인을 위한 시간을 재는 변수
 * mn_mn_virus2_cnt : 총 생성된 바이러스 카운트를 위한 변수
 * ma2f_Virus2Position : 바이러스 생성위치를 저장하는 2차원 배열
 * 
 * n_i : for문 카운트를 위한 변수
 * n_j : 상동
 * 
 * n_Virus2PositionX : 바이러스1 위치 X값
 * n_Virus2PositionY :바이러스1 위치 Y값
 * 
 * g_GenerateVirus1 : 프리팹을 통해 생성하는 바이러스1 오브젝트
 * 
 * 
 * 
 */


public class BrushYourTeeth_Virus2Generator : MonoBehaviour
{
    public GameObject mg_Virus2_Prefab;
    float mf_span = 4.0f;  // 생성 주기
    float mf_delta = 0;    //시간 재는 변수
    int mn_virus2_cnt = 1; //총 생성된 바이러스 카운트용 변수


    float[,] ma2f_Virus2Position = new float[5, 2];


    // Start is called before the first frame update
    void Start()
    {



        while (true)        //바이러스 생성 위치 설정
        {
            for (int n_i = 0; n_i < 5; n_i++)         //바이러스를 생성할 랜덤 위치를 ma2f_Virus2Position배열에 저장
            {
                int n_Virus2PositionX = Random.Range(-4, 4);
                float n_Virus2PositionY = Random.Range(-0.6f, -3.3f);

                ma2f_Virus2Position[n_i, 0] = n_Virus2PositionX;
                ma2f_Virus2Position[n_i, 1] = n_Virus2PositionY;
            }

            

            
            for (int n_i = 0; n_i < 4; n_i++)         //중복된 위치에 나오지 않게끔 재설정
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
        Debug.Log("바이러스2 1번째 위치 : " + ma2f_Virus2Position[0, 0] + " " + ma2f_Virus2Position[0, 1]);


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
            Debug.Log("바이러스2 " + (mn_virus2_cnt + 1) + "번째 위치 : " + ma2f_Virus2Position[mn_virus2_cnt, 0] + " " + ma2f_Virus2Position[mn_virus2_cnt, 1]);
            mn_virus2_cnt++;
        }

    }
}
