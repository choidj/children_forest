using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1_Generator : MonoBehaviour
{
    public GameObject Virus1_Prefab;
    float span = 3.0f;  // ���� �ֱ�
    float delta = 0;    //�ð� ��� ����
    int virus1_cnt = 1; //�� ������ ���̷��� ī��Ʈ�� ����


    float[,] arr1 = new float[5, 2];


    // Start is called before the first frame update
    void Start()
    {



        while (true)        //���̷��� ���� ��ġ ����
        {
            for (int i = 0; i < 5; i++)         //���̷����� ������ ���� ��ġ�� arr1�迭�� ����
            {
                int x = Random.Range(-4, 4);
                float y = Random.Range(-0.6f, -3.3f);

                arr1[i, 0] = x;
                arr1[i, 1] = y;
            }




            for (int i = 0; i < 4; i++)         //�ߺ��� ��ġ�� ������ �ʰԲ� �缳��
            {
                for (int j = 1; j < 5; j++)
                {
                    if (i == j)
                    {
                        j++;
                    }
                    if (Mathf.Abs(arr1[i, 0]) == Mathf.Abs(arr1[j, 0]) && (Mathf.Abs(arr1[i, 1]) - Mathf.Abs(arr1[j, 1]) < 0.8) && (Mathf.Abs(arr1[i, 1]) - Mathf.Abs(arr1[j, 1]) > -0.8))
                    {
                        int x = Random.Range(-4, 4);
                        float y = Random.Range(-0.6f, -3.3f);

                        arr1[j, 0] = x;
                        arr1[j, 1] = y;
                        i = 0;
                        continue;
                    }
                }
            }



            break;


            
        }


        GameObject go = Instantiate(Virus1_Prefab) as GameObject;
        go.transform.position = new Vector3(arr1[0, 0], arr1[0, 1], 0);
        Debug.Log("���̷���1 1��° ��ġ : " + arr1[0, 0] + " " + arr1[0, 1]);

        
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
            Debug.Log("���̷���1 " + (virus1_cnt+1) + "��° ��ġ : " + arr1[virus1_cnt, 0] + " " + arr1[virus1_cnt, 1]);
            virus1_cnt++;
        }
        
    }
}
