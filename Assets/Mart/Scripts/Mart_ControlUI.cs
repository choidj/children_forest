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

    //트루값 입력 함수
    public void Mart_CheckRandomItemArr(int num)
    {
        Market_RandomItemArr[num] = true;
        Debug.Log(num + "번째 배열 트루값 입력");

    }


    //랜덤값 뽑는 함수
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

    public int HowmanyleftArr()         //남은 false값
    {
        int left = 0;
        for (int i = 0; i < 6; i++)
        {
            if (Market_RandomItemArr[i] == true)
            {
                Debug.Log(i + "번째 배열값 true");
            }
            if (Market_RandomItemArr[i] == false)
            {
                Debug.Log(i + "번째 배열값 false");
                left += 1;
            }
        }
        Debug.Log(left + "번 남았습니다.");
        return left;
    }


    public void testqq()
    {
        Debug.Log("연결확인용~~~");
    }

    public void ChangeFlagTrue()
    {
        ChangeItemFlag = true;
        Debug.Log("Flag값 True");
    }

    public void ChangeFlagFalse()
    {
        ChangeItemFlag = false ;
        Debug.Log("Flag값 False");
    }

    public bool checkFlag()
    {
        return ChangeItemFlag;
    }


}
