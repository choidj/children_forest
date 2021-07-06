using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1_Generator : MonoBehaviour
{
    public GameObject Virus1_Prefab;
    float span = 3.0f;  // 생성 주기
    float delta = 0;    //시간 재는 변수
    int virus1_cnt = 1; //총 생성된 바이러스 카운트용 변수


    float[,] arr1 = new float[5, 2];


    // Start is called before the first frame update
    void Start()
    {
        

        
        while (true)
        {
            for (int i = 0; i < 5; i++)         //바이러스를 생성할 랜덤 위치를 arr1배열에 저장
            {
                int x = Random.Range(-4, 4);
                float y = Random.Range(-0.5f, -3.3f);

                arr1[i, 0] = x;
                arr1[i, 1] = y;
            }



            for (int i=0; i<5; i++)
            {
                for (int j=1; j<5; j++)
                {
                    if (Mathf.Abs(arr1[i, 0]) == Mathf.Abs(arr1[j, 0]) && (Mathf.Abs(arr1[i, 1]) - Mathf.Abs(arr1[j, 1]) < 0.6) && (Mathf.Abs(arr1[i, 1]) - Mathf.Abs(arr1[j, 1]) > -0.6))
                    {
                        int x = Random.Range(-4, 4);
                        float y = Random.Range(-0.5f, -3.3f);

                        arr1[j, 0] = x;
                        arr1[j, 1] = y;
                        continue;
                    }
                }
            }



            break;


            /*
            if(arr1[0, 0] - arr1[1, 0] > 0.5)
            {
                if(arr1[0, 1] - arr1[1, 1] > 0.5)
                {
                    break;
                }
            }
            */
            
        }


        GameObject go = Instantiate(Virus1_Prefab) as GameObject;
        go.transform.position = new Vector3(arr1[0, 0], arr1[0, 1], 0);
        Debug.Log("바이러스1 1번째 위치 : " + arr1[0, 0] + " " + arr1[0, 1]);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.delta += Time.deltaTime;
        if (this.delta > this.span && virus1_cnt < 5)
        {
            this.delta = 0;
            GameObject go = Instantiate(Virus1_Prefab) as GameObject;
            //int x = Random.Range(-3, 3);
            //float y = Random.Range(-1.3f, -3.3f);
            go.transform.position = new Vector3(arr1[virus1_cnt, 0], arr1[virus1_cnt, 1], 0);
            Debug.Log("바이러스1 " + (virus1_cnt+1) + "번째 위치 : " + arr1[virus1_cnt, 0] + " " + arr1[virus1_cnt, 1]);
            virus1_cnt++;
        }
        
    }
}
