using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_ControlUI : MonoBehaviour
{
    private bool[] Market_RandomItemArr = new bool[6];
    private int randomValue;


    private bool ChangeItemFlag;
    

    // Start is called before the first frame update
    void Start()
    {
        ChangeItemFlag = false;

        for (int i = 0; i < 6; i++)
        {
            Market_RandomItemArr[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Ʈ�簪 �Է� �Լ�
    public void Mart_CheckRandomItemArr(int num)
    {
        Market_RandomItemArr[num] = true;
        Debug.Log(num + "��° �迭 Ʈ�簪 �Է�");

    }


    //������ �̴� �Լ�
    public int Mart_RandomItemValue()
    {

        while (true)
        {
            randomValue = Random.Range(0, 6);
            if (Market_RandomItemArr[randomValue] == false)
            {
                break;
            }
        }
        return randomValue;
    }

    public int HowmanyleftArr()         //���� false��
    {
        int left = 0;
        for (int i = 0; i < 6; i++)
        {
            if (Market_RandomItemArr[i] == true)
            {
                Debug.Log(i + "��° �迭�� true");
            }
            if (Market_RandomItemArr[i] == false)
            {
                Debug.Log(i + "��° �迭�� false");
                left += 1;
            }
        }
        Debug.Log(left + "�� ���ҽ��ϴ�.");
        return left;
    }


    public void testqq()
    {
        Debug.Log("����Ȯ�ο�~~~");
    }

    public void ChangeFlagTrue()
    {
        ChangeItemFlag = true;
        Debug.Log("Flag�� True");
    }

    public void ChangeFlagFalse()
    {
        ChangeItemFlag = false ;
        Debug.Log("Flag�� False");
    }

    public bool checkFlag()
    {
        return ChangeItemFlag;
    }


}
